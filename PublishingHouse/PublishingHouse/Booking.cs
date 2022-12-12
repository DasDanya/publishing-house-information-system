using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace PublishingHouse
{
    public class Booking
    {

        int idPrintingHouse, idCustomer;
        double cost;
        string status;
        DateTime startBooking, endBooking;
        int[] idProducts, idEmployees;

        public int IdPrintingHouse { get { return idPrintingHouse; } }
        public int IdCustomer { get { return idCustomer; } }
        public double Cost { get { return cost; } }
        public DateTime StartBooking { get { return startBooking; } }
        public DateTime EndBooking { get { return endBooking; } }
        public int[] IdProducts { get { return idProducts; } }
        public int[] IdEmployees { get { return idEmployees; } }

        public Booking(int idPrintingHouse, int idCustomer, double cost, string status, DateTime startBooking, int[] idProducts, int[] idEmployees)
        {
            this.idPrintingHouse = idPrintingHouse;
            this.idCustomer = idCustomer;
            this.cost = cost;
            this.status = status;
            this.startBooking = startBooking;
            this.idProducts = idProducts;
            this.idEmployees = idEmployees;
        }

        public Booking(int idPrintingHouse, int idCustomer, double cost, string status, DateTime startBooking, DateTime endBooking, int[] idProducts, int[] idEmployees)
        {
            this.idPrintingHouse = idPrintingHouse;
            this.idCustomer = idCustomer;
            this.cost = cost;
            this.status = status;
            this.startBooking = startBooking;
            this.endBooking = endBooking;
            this.idProducts = idProducts;
            this.idEmployees = idEmployees;
        }



        /// <summary>
        /// Метод получения стоимости выполнения заказа
        /// </summary>
        /// <param name="dataGridView">Таблица с печатными продукциями</param>
        /// <returns>Стоимость выполнения заказа</returns>
        public static double GetCostBooking(DataGridView dataGridView) 
        {
            double cost = 0;

            // Проходимся по таблице
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                // Если пользователь выбрал запись
                if (Convert.ToBoolean(dataGridView.Rows[i].Cells[0].Value))
                    // Прибавляем к имеющейся стоимости стоимость печатной продукции
                    cost += Convert.ToDouble(dataGridView.Rows[i].Cells["Стоимость"].Value);
            }

            return cost;
        }

        /// <summary>
        /// Метод получения id заказа
        /// </summary>
        /// <returns>id заказа</returns>
        private static int GetIdBooking() 
        {
            int id = 0;

            try 
            {
                ConnectionToDb.Open();

                // Получаем id заказа
                SqlCommand command = new SqlCommand("SELECT MAX(bkId) FROM booking", ConnectionToDb.Connection);
                id = Convert.ToInt32(command.ExecuteScalar());

                ConnectionToDb.Close();

            }
            catch
            {
                throw new Exception("Ошибка получения уникального номера записи о заказе");
            }

            return id;
        }

        /// <summary>
        /// Метод добавления данных о заказе в бд
        /// </summary>
        /// <returns>1 - если количество добавленных записей равно ожидаемому количеству</returns>
        public int AddBooking() 
        {

            int success = 0;

            try
            {
                ConnectionToDb.Open();

                SqlCommand command = new SqlCommand("INSERT INTO booking (bkDateOfAdd, bkStatus, bkCost, fphId, fcustId) VALUES (@startBooking, N'"+status+"', @cost, '"+idPrintingHouse+"', '"+idCustomer+"')", ConnectionToDb.Connection);
                command.Parameters.Add("@startBooking", SqlDbType.Date).Value = startBooking;
                command.Parameters.Add("@cost", SqlDbType.Float).Value = cost;

                // Если мы успешно успешно добавили запись
                if (command.ExecuteNonQuery() == 1)
                {
                    // Получаем id заказа
                    int idBooking = GetIdBooking();

                    // Если успешно установили печатным продукциям их заказы
                    if (Product.SetBooking(idProducts, idBooking))
                    {
                        // Если добавилось нужное количество строк в таблицу "Заказ-Сотрудник"
                        if (AddBookingEmployee(idEmployees, idBooking))
                            success = 1;
                    }
                }

                ConnectionToDb.Close();
            }
            catch 
            {
                throw new Exception("Ошибка добавления данных о заказе");            
            }

            return success;
        }

        /// <summary>
        /// Метод добавления данных в таблицу "Заказ-Сотрудник"
        /// </summary>
        /// <param name="idEmployees">Массив id сотрудников</param>
        /// <param name="idBooking">id заказа</param>
        /// <returns></returns>
        private static bool AddBookingEmployee(int[] idEmployees, int idBooking) 
        {
            bool success = false;
            int countAddRows = 0;

            try
            {
                ConnectionToDb.Open();

                // Проходим на массиву id сотрудников
                for (int i = 0; i < idEmployees.Length; i++)
                {
                    // Добавляем данные в таблицу
                    SqlCommand command = new SqlCommand("INSERT INTO bookingEmployee (fbkId, fempId) VALUES ('"+idBooking+"', '"+idEmployees[i]+"')", ConnectionToDb.Connection);
                    countAddRows += command.ExecuteNonQuery();
                }

                // Если добавилось нужное количество записей
                if (countAddRows == idEmployees.Length)
                    success = true;

                ConnectionToDb.Close();
            }
            catch 
            {              
                throw new Exception("Ошибка добавления данных в таблицу \"Заказ-Сотрудник\"");
            }

            return success;
        }

        /// <summary>
        /// Загрузка данных о заказе в таблицу
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        public static void LoadBookings(DataGridView dataGridView)
        {
            try 
            {
                ConnectionToDb.Open();

                // Запрос на получение данных о заказе
                SqlCommand command = new SqlCommand("SELECT booking.bkId AS N'Номер заказа', booking.bkDateOfAdd AS N'Дата приёма', booking.bkDateOfComplete AS N'Дата выполнения', booking.bkStatus AS N'Статус', booking.bkCost AS N'Стоимость выполнения', customer.custName AS N'Заказчик', printingHouse.phName AS 'Типография' FROM booking, customer, printingHouse WHERE booking.fcustId = customer.custId AND booking.fphId = printingHouse.phId", ConnectionToDb.Connection);
                SqlDataReader reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();

                // Загружаем данные в таблицу
                dataTable.Load(reader);
                dataGridView.DataSource = dataTable;


                reader.Close();
                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка загрузки данных о заказах");
            }
        }
    }
}

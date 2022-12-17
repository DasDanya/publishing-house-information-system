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

        int idPrintingHouse, idCustomer, numBooking;
        double cost;
        string status, namePrintingHouse;
        DateTime startBooking, endBooking;
        int[] idProducts, idEmployees;

        public int IdPrintingHouse { get { return idPrintingHouse; } }
        public int IdCustomer { get { return idCustomer; } }
        public int NumBooking { get { return numBooking; } }
        public double Cost { get { return cost; } }

        public String NamePrintingHouse { get { return namePrintingHouse; } }
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

        public Booking(int numBooking, int idCustomer, string namePrintingHouse, DateTime startBooking, int[] idProducts, int[] idEmployees)
        {
            this.numBooking = numBooking;
            this.idCustomer = idCustomer;
            this.namePrintingHouse = namePrintingHouse;
            this.startBooking = startBooking;
            this.idProducts = idProducts;
            this.idEmployees = idEmployees;
        }

        public Booking(int numBooking, int idPrintingHouse, int idCustomer, double cost, string status, DateTime startBooking, DateTime endBooking, int[] idProducts, int[] idEmployees)
        {
            this.numBooking = numBooking;
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

            return Math.Round(cost, 2);
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
        /// <returns>Добавились ли данные в таблицу</returns>
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
        /// Метод удаления данных из таблицы "Заказ-Сотрудник"
        /// </summary>
        /// <param name="idBooking">id заказа</param>
        /// <returns>Удалились ли данные из таблицы</returns>
        private static bool DeleteBookingEmployees(int idBooking) 
        {
            bool success = false;

            try
            {
                ConnectionToDb.Open();

                // Удаляем данные из таблицы определенного заказа
                SqlCommand command = new SqlCommand("DELETE FROM bookingEmployee WHERE fbkId = '"+idBooking+"'", ConnectionToDb.Connection);
                if (command.ExecuteNonQuery() > 0)
                    success = true;

                ConnectionToDb.Close();
            }
            catch 
            {
                throw new Exception("Ошибка удаления данных из таблицы \"Заказ-Сотрудник\"");
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

        /// <summary>
        /// Метод проверки статуса заказа
        /// </summary>
        /// <param name="idBooking">id заказа</param>
        /// <returns>Выполняется ли заказ</returns>
        public static bool BookingIsBeingExecuted(int idBooking) 
        {
            bool isBeingExecuted = false;

            try
            {
                ConnectionToDb.Open();

                // Получаем данные о статусе заказа
                SqlCommand command = new SqlCommand("SELECT bkStatus FROM booking WHERE bkId = '"+idBooking+"'", ConnectionToDb.Connection);
                string status = command.ExecuteScalar().ToString();

                // Если статус выполняется
                if (status == "Выполняется")
                    isBeingExecuted = true;
                

                ConnectionToDb.Close();
            }
            catch 
            {
                throw new Exception("Ошибка получения данных о статусе выполнения заказа");
            }

            return isBeingExecuted;
        }

      
        /// <summary>
        /// Метод получения id заказчика 
        /// </summary>
        /// <param name="idBooking">id заказа</param>
        /// <returns>id заказчика</returns>
        public static int GetIdCustomer(int idBooking) 
        {
            int id = -1;

            try
            {
                ConnectionToDb.Open();

                // Получаем id заказчика
                SqlCommand command = new SqlCommand("SELECT fcustId FROM booking WHERE bkId = '"+idBooking+"'", ConnectionToDb.Connection);
                id = Convert.ToInt32(command.ExecuteScalar());

                ConnectionToDb.Close();
            }
            catch 
            {
                throw new Exception("Ошибка получения уникального номера записи о заказчике");
            }

            return id;
        }

        /// <summary>
        /// Метод получения id типографии
        /// </summary>
        /// <param name="idBooking">id заказа</param>
        /// <returns>id типографии</returns>
        public static int GetIdPrintingHouse(int idBooking)
        {
            int id = -1;

            try
            {
                ConnectionToDb.Open();

                // Получаем id типографии
                SqlCommand command = new SqlCommand("SELECT fphId FROM booking WHERE bkId = '" + idBooking + "'", ConnectionToDb.Connection);
                id = Convert.ToInt32(command.ExecuteScalar());

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения уникального номера записи о типографии");
            }

            return id;
        }

        /// <summary>
        /// Метод получения массива id сотрудников
        /// </summary>
        /// <param name="idBooking">id заказа</param>
        /// <returns>Массив id заказов</returns>
        public static int[] GetArrayIdEmployees(int idBooking) 
        {
            List<int> idEmployees = new List<int>();
            int[] arrayId;

            try
            {
                ConnectionToDb.Open();

              
                // Запрос на получение id сотрудников
                SqlCommand command = new SqlCommand("SELECT fempId FROM bookingEmployee WHERE fbkId = '"+idBooking+"'" , ConnectionToDb.Connection);
                SqlDataReader reader = command.ExecuteReader();

                // Записываем данные в массив
                while (reader.Read()) 
                {
                    idEmployees.Add(Convert.ToInt32(reader["fempId"]));
                }

                arrayId = new int[idEmployees.Count];
                idEmployees.CopyTo(arrayId, 0);

                ConnectionToDb.Close();
            }
            catch
            {
               throw new Exception("Ошибка получения массива идентификаторов записей о сотрудниках");
            }

            

            return arrayId; 
        }

        /// <summary>
        /// Метод получения массива id печатных продукций 
        /// </summary>
        /// <param name="idBooking">id заказа</param>
        /// <returns>Массив id печатных продукций</returns>
        public static int[] GetArrayIdProducts(int idBooking)
        {
            List<int> idProducts = new List<int>();
            int[] arrayId;
            try
            {
                ConnectionToDb.Open();

                // Запрос на получение id печатных продукций
                SqlCommand command = new SqlCommand("SELECT prodId FROM product WHERE fbkId = '" + idBooking + "'", ConnectionToDb.Connection);
                SqlDataReader reader = command.ExecuteReader();

                // Записываем данные в массив
                while (reader.Read())
                {
                    idProducts.Add(Convert.ToInt32(reader["prodId"]));
                }

                arrayId = new int[idProducts.Count];
                idProducts.CopyTo(arrayId, 0);

                reader.Close();
                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения массива идентификаторов записей о печатных продукциях");
            }

            

            return arrayId;
        }

        /// <summary>
        /// Метод изменения данных о заказе
        /// </summary>
        /// <param name="idBooking">id заказа</param>
        /// <returns>1 - если изменение прошло успешно </returns>
        public int ChangeBooking(int idBooking) 
        {
            int success = 0;

            try
            {
                ConnectionToDb.Open();

                // Запрос на извенение данных в таблице Заказы
                SqlCommand command = new SqlCommand("UPDATE booking SET bkDateOfAdd = @startBooking, bkCost = @cost, fphId = '"+idPrintingHouse+"', fcustId = '"+idCustomer+"' WHERE bkId = '"+idBooking+"'", ConnectionToDb.Connection);
                command.Parameters.Add("@startBooking", SqlDbType.Date).Value = startBooking;
                command.Parameters.Add("@cost", SqlDbType.Float).Value = cost;

                // Если успешно изменили данные в таблице Заказы
                if (command.ExecuteNonQuery() == 1) 
                {
                    // Если сбросили прошлые заказы
                    if (Product.DeleteBooking(idBooking)) 
                    {
                        // Если мы установили новые заказы 
                        if (Product.SetBooking(idProducts, idBooking))
                        {
                            // Если удалили старые данные из таблицы "Заказ-Сотрудник"
                            if (DeleteBookingEmployees(idBooking)) 
                            {
                                // Если добавили нужное количество записей в таблицу "Заказ-Сотрудник"
                                if (AddBookingEmployee(idEmployees, idBooking))
                                    success = 1;
                            }
                        }
                    }
                }

                ConnectionToDb.Close();
            }
            catch 
            {
                throw new Exception("Ошибка изменения данных о заказе");
            }

            return success;
        }

        /// <summary>
        /// Метод выполнения заказа
        /// </summary>
        /// <param name="idBooking">id заказа</param>
        /// <returns>Количество выполненных заказов</returns>
        public static int BookingIsCompleted(int idBooking) 
        {
            int countCompletedRows = 0;

            try
            {
                ConnectionToDb.Open();

                // Запрос на выполнение заказа
                SqlCommand command = new SqlCommand("UPDATE booking SET bkStatus = N'Выполнен', bkDateOfComplete = @endBooking WHERE bkId = '"+idBooking+"'", ConnectionToDb.Connection);
                command.Parameters.Add("@endBooking", SqlDbType.Date).Value = DateTime.Now.Date;

                // Получаем количество выполненных заказов
                countCompletedRows = command.ExecuteNonQuery();

                ConnectionToDb.Close();
            }
            catch 
            {
                throw new Exception("Ошибка выполнения заказа");
            }

            return countCompletedRows;
        }

        /// <summary>
        /// Метод получения массива id выбранных записей о заказах
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        /// <param name="selectedRows">Список индексов выбранных строк</param>
        /// <returns>Массив id выбранных записей о заказах</returns>
        public static int[] GetArrayIdBookings(DataGridView dataGridView, List<int> selectedRows) 
        {
            int[] arrayId = new int[selectedRows.Count];
            int indexArray = 0;

            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                // Если строка выбрана
                if (selectedRows.Contains(i)) 
                { 
                    arrayId[indexArray++] = Convert.ToInt32(dataGridView.Rows[i].Cells["Номер заказа"].Value);
                }
            }


            return arrayId;
        }

        /// <summary>
        /// Метод удаления данных о заказах
        /// </summary>
        /// <param name="arrayIdBoookings">Массив id заказов</param>
        /// <returns>Количество удаленных строк</returns>
        public static int DeleteBooking(int[] arrayIdBoookings) 
        {
            int countDeletedRows = 0;
          
            try
            {
                ConnectionToDb.Open();

                for (int i = 0; i < arrayIdBoookings.Length; i++)
                {
                                
                    // Хранимая процедура для удаления заказа
                    const string SQLPROCEDURE = "deleteBooking";
                    SqlCommand command = new SqlCommand(SQLPROCEDURE, ConnectionToDb.Connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Передаём данные в хранимую процедуру и выполняем её
                    command.Parameters.Add("@idBooking", SqlDbType.NVarChar).Value = arrayIdBoookings[i];
                    countDeletedRows += command.ExecuteNonQuery();
                }

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка удаления данных о заказе");
            }

            return countDeletedRows;
        }
    }

}

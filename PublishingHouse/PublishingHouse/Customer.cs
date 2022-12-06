using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace PublishingHouse
{

    /// <summary>
    /// Класс сотрудника
    /// </summary>
    public class Customer
    {

        string name, email, phone;

        public string Name { get { return name; } }
        public string Email { get { return email; } }
        public string Phone { get { return phone; } }

        public Customer(string name, string email, string phone)
        {
            this.name = name;
            this.email = email;
            this.phone = phone;
        }

        /// <summary>
        /// Метод добавления заказчика в бд
        /// </summary>
        /// <returns>Количество добавленных заказчиков</returns>
        public int AddCustomer()
        {
            int countCustomers = -1;

            try
            {
                ConnectionToDb.Open();

                // Создаём запрос на добавление заказчика и выполняем его
                SqlCommand command = new SqlCommand("INSERT INTO customer (custName, custPhone, custEmail) VALUES (N'" + name + "', N'" + phone + "', N'" + email + "')", ConnectionToDb.Connection);
                countCustomers = command.ExecuteNonQuery();

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка добавления заказчика");
            }

            return countCustomers;
        }

        /// <summary>
        /// Метод добавления данных о заказчиках в таблицу
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        public static void LoadCustomers(DataGridView dataGridView)
        {

            try
            {
                ConnectionToDb.Open();

                // Запрос на получение заказчиков
                SqlCommand command = new SqlCommand("SELECT custName AS 'Наименование заказчика', custPhone AS 'Номер телефона', custEmail AS 'Электронная почта' FROM customer ORDER BY custName", ConnectionToDb.Connection);
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader();

                // Загружаем данные о заказчиках в таблицу
                DataTable dt = new DataTable();
                dt.Load(dataReader);
                dataGridView.DataSource = dt;

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения данных о заказчиках");
            }

        }

      
        /// <summary>
        /// Метод получения списка id заказов заказчика
        /// </summary>
        /// <param name="idCustomer">id заказчика</param>
        /// <returns>Список id заказов</returns>
        public static List<int> GetNumbersOfOrdersThisCustomer(string email)
        {
            List<int> listIds = new List<int>();

            try
            {

                // Получаем id заказчика
                int id = GetIdCustomerByEmail(email);

                ConnectionToDb.Open();

                // Выполняем запрос на получения списка id заказов и выполняем его
                SqlCommand command = new SqlCommand("SELECT * FROM booking, customer WHERE booking.fcustId = '"+id+"' AND customer.custId = '"+id+"'", ConnectionToDb.Connection);
                SqlDataReader dataReader = command.ExecuteReader();

                // Считываем данные из ридера и записываем в список
                while (dataReader.Read())
                {
                    // Получаем id заказа
                    int idOrder = Convert.ToInt32(dataReader["bkNumber"]);
                    listIds.Add(idOrder);
                }

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения списка уникальных номеров заказов заказчика");
            }

            return listIds;
        }


        /// <summary>
        /// Метод получения id записи о заказчике, зная его номер телефона
        /// </summary>
        /// <param name="phone">Номер телефона</param>
        /// <returns>id записи о заказчике</returns>
        public static int GetIdCustomerByPhone(string phone)
        {
            int id = -1;

            try
            {
                ConnectionToDb.Open();

                // Формируем запрос на получение id заказчика и выполняем его
                SqlCommand command = new SqlCommand("SELECT custId FROM customer WHERE custPhone = '" + phone + "'", ConnectionToDb.Connection);
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
        /// Метод получения id записи о заказчике, зная его электронную почту
        /// </summary>
        /// <param name="email">Электронная почта</param>
        /// <returns>id записи о заказчике</returns>
        public static int GetIdCustomerByEmail(string email)
        {
            int id = -1;

            try
            {
                ConnectionToDb.Open();

                // Формируем запрос на получение id заказчика и выполняем его
                SqlCommand command = new SqlCommand("SELECT custId FROM customer WHERE custEmail = '" + email + "'", ConnectionToDb.Connection);
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
        /// Метод получения количества записей
        /// </summary>
        /// <returns>Количество записей</returns>
        public static int GetCountRecords()
        {
            int count = 0;

            try
            {
                ConnectionToDb.Open();

                // Формируем запрос на получение количества записей и выполняем его
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM customer", ConnectionToDb.Connection);
                command.CommandType = CommandType.Text;
                count = Convert.ToInt32(command.ExecuteScalar());

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения количества заказчиков");
            }

            return count;
        }

        /// <summary>
        /// Метод получения данных о заказчиках по определенному порядку фильтрации
        /// </summary>
        /// <param name="order">Порядок фильтрации</param>
        /// <param name="outStringCount">Количество выводимых строк</param>
        /// <returns>DataTable с отсортированными данными</returns>
        public static DataTable GetTableByOccurrence(string order, int outStringCount)
        {
            DataTable dt = new DataTable();

            try
            {
                ConnectionToDb.Open();

                // Формируем, выполняем запрос на получение данных о заказчиках в определенном порядке
                string query = String.Format("SELECT TOP {0} customer.custName AS N'Наименование заказчика', customer.custPhone AS N'Номер телефона', COUNT(booking.fcustId) AS N'Количество заказов' FROM customer LEFT JOIN booking ON customer.custId = booking.fcustId GROUP BY customer.custName, customer.custPhone ORDER BY COUNT(booking.fcustId) {1} ", outStringCount, order);
                SqlCommand command = new SqlCommand(query, ConnectionToDb.Connection);
                SqlDataReader dataReader = command.ExecuteReader();

                // Загружаем полученные данные в DataTable
                dt.Load(dataReader);



                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения данных о заказчиках");
            }

            return dt;
        }

        /// <summary>
        /// Метод, определяющий есть ли у заказчика заказ
        /// </summary>
        /// <param name="idCustomer">id заказчика</param>
        /// <returns>Есть ли у заказчика заказ</returns>
        public static bool CustomerHasBooking(int idCustomer)
        {
            bool has = false;

            try
            {
                ConnectionToDb.Open();

                // Получаем количество заказов заказчика
                SqlCommand command = new SqlCommand("SELECT COUNT(fcustId) FROM booking WHERE fcustId = '" + idCustomer + "'", ConnectionToDb.Connection);

                if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                    has = true;

                ConnectionToDb.Close();
            }

            catch
            {
                throw new Exception("Ошибка получения данных о том, имеет ли заказчик заказ(-ы)");
            }

            return has;
        }
    }
}

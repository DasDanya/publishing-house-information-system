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
    }
}

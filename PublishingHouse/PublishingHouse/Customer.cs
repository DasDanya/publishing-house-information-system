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
    }
}

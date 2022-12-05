using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

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
    }
}

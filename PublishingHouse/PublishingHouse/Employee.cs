using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace PublishingHouse
{
    public class Employee
    {
        string name, surname, middlename, type, email, phone;

        byte[] photo = null;

        public Employee(string name, string surname, string middlename, string type, string email, string phone, byte[] photo)
        {
            this.name = name;
            this.surname = surname;
            this.middlename = middlename;
            this.type = type;
            this.email = email;
            this.phone = phone;
            this.photo = photo;
        }

        /// <summary>
        /// Метод добавления сотрудника
        /// </summary>
        /// <returns>Количество добавленных сотрудников</returns>
        public int AddEmployee() 
        {
            int countEmployee = -1;

            try
            {
                ConnectionToDb.Open();

                // Создаём запрос на добавление сотрудника и выполняем его
                SqlCommand command = new SqlCommand("INSERT INTO employee (empSurname, empFirstname, empMiddlename, empType, empPhone, empEmail, empVisual) VALUES (N'"+ surname +"', N'"+ name +"', N'"+ middlename +"', N'"+ type +"', N'"+ phone +"', N'"+ email +"', @visual)", ConnectionToDb.Connection);
                command.Parameters.Add("@visual", SqlDbType.Image, 8000).Value = photo;
                countEmployee = command.ExecuteNonQuery();

                ConnectionToDb.Close();
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
                //throw new Exception("Ошибка добавления сотрудника");
            }

            return countEmployee;
        }

        
    }
}

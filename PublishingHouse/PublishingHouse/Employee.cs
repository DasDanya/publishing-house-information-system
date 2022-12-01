using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace PublishingHouse
{
    public class Employee
    {
        string name, surname, middlename, type, email, phone;

        DateTime birthday;
        Image photoAsImage;
        byte[] photo = null;

        public string Name { get { return name; } }
        public string Surname { get { return surname; } }
        public string Middlename { get { return middlename; } }
        public string Type { get { return type; } }
        public string Email { get { return email; } }
        public string Phone { get { return phone; } }
        public DateTime Birthday { get { return birthday; } }
        public Image PhotoAsImage { get { return photoAsImage; } }
        public byte[] Photo { get { return photo; } }


        public Employee(string name, string surname, string middlename, string type, string email, string phone, DateTime birthday, byte[] photo)
        {
            this.name = name;
            this.surname = surname;
            this.middlename = middlename;
            this.type = type;
            this.email = email;
            this.phone = phone;
            this.birthday = birthday;
            this.photo = photo;
        }

        public Employee(string name, string surname, string middlename, string type, string email, string phone, DateTime birthday, Image photoAsImage)
        {
            this.name = name;
            this.surname = surname;
            this.middlename = middlename;
            this.type = type;
            this.email = email;
            this.phone = phone;
            this.birthday = birthday;
            this.photoAsImage = photoAsImage;
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
                SqlCommand command = new SqlCommand("INSERT INTO employee (empSurname, empFirstname, empMiddlename, empType, empPhone, empEmail, empVisual, empBirthday) VALUES (N'"+ surname +"', N'"+ name +"', N'"+ middlename +"', N'"+ type +"', N'"+ phone +"', N'"+ email +"', @visual, @birthday)", ConnectionToDb.Connection);
                command.Parameters.Add("@visual", SqlDbType.Image).Value = photo;
                command.Parameters.Add("@birthday", SqlDbType.Date).Value = birthday;
                countEmployee = command.ExecuteNonQuery();

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка добавления сотрудника");
            }

            return countEmployee;
        }

        /// <summary>
        /// Метод добавления данных о сотрудниках в таблицу
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        public static void LoadEmployees(DataGridView dataGridView) 
        {
           
            try
            {
                ConnectionToDb.Open();

                // Запрос на получение сотрудников
                SqlCommand command = new SqlCommand("SELECT empSurname AS 'Фамилия', empFirstname AS 'Имя', empMiddlename AS 'Отчество', empBirthday AS 'Дата рождения', empType AS 'Должность сотрудника', empPhone AS 'Номер телефона', empEmail AS 'Электронная почта' FROM employee ORDER BY empSurname", ConnectionToDb.Connection);
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader();

                // Загружаем данные о сотрудниках в таблицу
                DataTable dt = new DataTable();
                dt.Load(dataReader);
                dataGridView.DataSource = dt;
                
                ConnectionToDb.Close();
            }
            catch 
            {
                throw new Exception("Ошибка получения данных о сотрудниках");
            }

        }

        /// <summary>
        /// Метод получения фотографии сотрудника, зная его номер телефона
        /// </summary>
        /// <param name="phone">Номер телефона сотрудника</param>
        /// <returns>Фотография сотрудника в виде массива байт</returns>
        public static byte[] GetPhotoEmployeeByPhone(string phone) 
        {
            byte[] photo = null;

            try
            {
                ConnectionToDb.Open();

                // Формируем запрос на получение фотографии сотрудника и выполняем его
                SqlCommand command = new SqlCommand("SELECT empVisual FROM employee WHERE empPhone = '"+ phone +"'", ConnectionToDb.Connection);
                command.CommandType = CommandType.Text;
                photo = (byte[])command.ExecuteScalar();

                ConnectionToDb.Close();
            }
            catch 
            {
                throw new Exception("Ошибка получения фотографии сотрудника");
            }

            return photo;
        }
        
    }
}

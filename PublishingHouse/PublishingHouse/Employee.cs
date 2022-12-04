﻿using System;
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
        /// Метод добавления сотрудника в бд
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

        /// <summary>
        /// Метод получения id записи о сотруднике, зная его номер телефона
        /// </summary>
        /// <param name="phone">Номер телефона</param>
        /// <returns>id записи о сотруднике</returns>
        public static int GetIdEmployeeByPhone(string phone) 
        {
            int id = -1;

            try
            {
                ConnectionToDb.Open();

                // Формируем запрос на получение id сотрудника и выполняем его
                SqlCommand command = new SqlCommand("SELECT empId FROM employee WHERE empPhone = '"+ phone +"'", ConnectionToDb.Connection);
                id = Convert.ToInt32(command.ExecuteScalar());


                ConnectionToDb.Close();
            }
            catch 
            {
                throw new Exception("Ошибка получения уникального номера записи о сотруднике");
            }
            

            return id;
        }

        /// <summary>
        /// Метод получения id записи о сотруднике, зная его электронную почту
        /// </summary>
        /// <param name="email">Электронная почта</param>
        /// <returns>id записи о сотруднике</returns>
        public static int GetIdEmployeeByEmail(string email)
        {
            int id = -1;

            try
            {
                ConnectionToDb.Open();

                // Формируем запрос на получение id сотрудника и выполняем его
                SqlCommand command = new SqlCommand("SELECT empId FROM employee WHERE empEmail = '" + email + "'", ConnectionToDb.Connection);
                id = Convert.ToInt32(command.ExecuteScalar());

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения уникального номера записи о сотруднике");
            }

            return id;
        }

        /// <summary>
        /// Метод изменения данных о сотруднике
        /// </summary>
        /// <param name="id">id записи о сотруднике</param>
        /// <returns>Количество измененных записей</returns>
        public int ChangeEmployee(int id) 
        {
            int countChangedRows = -1;

            try 
            {
                ConnectionToDb.Open();

                // Формируем запрос на изменение данных о сотруднике и выполняем его
                SqlCommand command = new SqlCommand("UPDATE employee SET empSurname = N'"+surname+"', empFirstname = N'"+name+"', empMiddlename = N'"+middlename+"',empType = N'"+type+"', empPhone = N'"+phone+"', empEmail = N'"+email+"', empVisual = @photo, empBirthday = @birthday WHERE empId = '"+id+"' ", ConnectionToDb.Connection);
                command.Parameters.Add("@photo", SqlDbType.Image).Value = photo;
                command.Parameters.Add("@birthday", SqlDbType.Date).Value = birthday;
                countChangedRows = command.ExecuteNonQuery();
               
                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка изменения данных о сотруднике"); 
            }

            return countChangedRows;
        }


        /// <summary>
        /// Метод, проверяющий существование электронной почты cотрудника в бд 
        /// </summary>
        /// <param name="typeWork">Тип работы с данными</param>
        /// <param name="pastEmail">Прошлый Email</param>
        /// <param name="newEmail">Новый Email</param>
        /// <returns>Существует ли Email сотрудника в бд</returns>
        public static bool ExistEmailInDb(char typeWork, string pastEmail, string newEmail)
        {
            bool exist = false;

            try
            {
                ConnectionToDb.Open();
                SqlCommand command = new SqlCommand();

                // Если пользователь добавляет запись
                if (typeWork == 'A')
                    // Запрос на существование email
                    command = new SqlCommand("SELECT COUNT(empEmail) FROM employee WHERE empEmail = '" + newEmail + "'", ConnectionToDb.Connection);

                // Если пользователь редактирует запись
                else if (typeWork == 'C')
                {
                    // Получаем id записи
                    int id = GetIdEmployeeByEmail(pastEmail);

                    ConnectionToDb.Open();

                    //Запрос на существование email, не учитывая изменяемую запись 
                    command = new SqlCommand("SELECT COUNT(empEmail) FROM employee WHERE empEmail = '" + newEmail + "' AND empId != '" + id + "' ", ConnectionToDb.Connection);

                }

                // Если email найден
                if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                    exist = true;

                ConnectionToDb.Close();
            }

            catch
            {
                throw new Exception("Ошибка проверки существования Email сотрудника в базе данных");
            }

            return exist;
        }

        /// <summary>
        /// Метод, проверяющий существование номера телефона cотрудника в бд 
        /// </summary>
        /// <param name="typeWork">Тип работы с данными</param>
        /// <param name="pastPhone">Прошлый номер телефона</param>
        /// <param name="newPhone">Новый номер телефона</param>
        /// <returns>Существует ли номер телефона сотрудника в бд</returns>
        public static bool ExistPhoneInDb(char typeWork, string pastPhone, string newPhone)
        {
            bool exist = false;

            try
            {
                ConnectionToDb.Open();
                SqlCommand command = new SqlCommand();

                // Если пользователь добавляет запись
                if (typeWork == 'A')
                    // Запрос на существование номера телефона
                    command = new SqlCommand("SELECT COUNT(empPhone) FROM employee WHERE empPhone = '" + newPhone + "'", ConnectionToDb.Connection);

                // Если пользователь редактирует запись
                else if (typeWork == 'C')
                {
                    // Получаем id записи
                    int id = GetIdEmployeeByPhone(pastPhone);

                    ConnectionToDb.Open();

                    //Запрос на существование номера телефона, не учитывая изменяемую запись 
                    command = new SqlCommand("SELECT COUNT(empPhone) FROM employee WHERE empPhone = '" + newPhone + "' AND empId != '" + id + "' ", ConnectionToDb.Connection);

                }

                // Если email найден
                if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                    exist = true;

                ConnectionToDb.Close();
            }

            catch
            {
                throw new Exception("Ошибка проверки существования номера телефона сотрудника в базе данных");
            }

            return exist;
        }

    }
}
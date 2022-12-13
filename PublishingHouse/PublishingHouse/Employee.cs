using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

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

        public Employee(string name, string surname, string middlename, string type, string email, string phone, DateTime birthday)
        {
            this.name = name;
            this.surname = surname;
            this.middlename = middlename;
            this.type = type;
            this.email = email;
            this.phone = phone;
            this.birthday = birthday;
        }

        public override string ToString()
        {
            return $"ФИО сотрудника: {surname} {name} {middlename}\nДата рождения: {birthday.Date.ToShortDateString()}\nДолжность сотрудника: {type}\nНомер телефона: {phone}\nЭлектронная почта: {email}";
        }


        /// <summary>
        /// Метод получения данных о сотруднике
        /// </summary>
        /// <param name="idEmployee">id сотрудника</param>
        /// <returns>Данные о сотруднике</returns>
        public static Employee GetEmployee(int idEmployee) 
        {
            Employee employee = null;

            try
            {
                ConnectionToDb.Open();

                // Запрос на получение данных о сотруднике
                SqlCommand command = new SqlCommand("SELECT * FROM employee WHERE empId = '"+idEmployee+"'", ConnectionToDb.Connection);
                SqlDataReader reader = command.ExecuteReader();

                // Считываем полученные данные
                while (reader.Read()) 
                {
                    employee = new Employee(reader["empFirstname"].ToString(), reader["empSurname"].ToString(), reader["empMiddlename"].ToString(), reader["empType"].ToString(), reader["empEmail"].ToString(), reader["empPhone"].ToString(), (DateTime)reader["empBirthday"]);
                }

                reader.Close();
                ConnectionToDb.Close();
            }
            catch 
            {
                throw new Exception("Ошибка получения данных о сотруднике");
            }

            return employee;
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
        private static byte[] GetPhotoEmployeeByPhone(string phone) 
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

        /// <summary>
        /// Метод получения фотографии сотрудника
        /// </summary>
        /// <param name="phone">Номер телефона</param>
        /// <returns>Фотография сотрудника</returns>
        public static Image GetPhotoAsImage(string phone) 
        {
            Image image = null;
            try
            {
                // Получаем фотографию пользователя из бд
                byte[] photo = GetPhotoEmployeeByPhone(phone);


                // Переводим изображение из массива байт в Image 
                MemoryStream stream = new MemoryStream(photo);
                image = Image.FromStream(stream);
            }
            catch
            {
                throw new Exception("Ошибка получения изображения");
            }

            return image;
        }


        /// <summary>
        /// Метод получения списка заказов, выполняемых сотрудником
        /// </summary>
        /// <param name="email">Электронная почта сотрудника</param>
        /// <returns>Список заказов</returns>
        public static List<int> GetNumbersOfOrdersThisEmployee(string email) 
        {
            List<int> orders = new List<int>();
            try
            {
                // Получаем список id заказов
                List<int> ids = GiveListEmployeeOrders(GetIdEmployeeByEmail(email));

                ConnectionToDb.Open();

                for (int i = 0; i < ids.Count; i++)
                {
                    // Получаем номера заказов и добавляем в список
                    SqlCommand command = new SqlCommand("SELECT bkId FROM booking WHERE bkId = '"+ids[i]+"'",ConnectionToDb.Connection);
                    orders.Add(Convert.ToInt32(command.ExecuteScalar()));
                    
                }

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения списка номеров заказов");
            }

            return orders;
        }

        /// <summary>
        /// Метод получения списка id заказов сотрудника
        /// </summary>
        /// <param name="idEmployee">id сотрудника</param>
        /// <returns>Список id заказов</returns>
        private static List<int> GiveListEmployeeOrders(int idEmployee) 
        {
            List<int> listIds = new List<int>();

            try
            {
                ConnectionToDb.Open();

                // Выполняем запрос на получения списка id заказов и выполняем его
                SqlCommand command = new SqlCommand("SELECT fbkId FROM bookingEmployee WHERE fempId = '"+idEmployee+"'", ConnectionToDb.Connection);
                SqlDataReader dataReader = command.ExecuteReader();

                // Считываем данные из ридера и записываем в список
                while (dataReader.Read())
                {
                    // Получаем id заказа
                    int idOrder = Convert.ToInt32(dataReader["fbkId"]);
                    listIds.Add(idOrder);
                }

                ConnectionToDb.Close();
            }
            catch 
            {
                throw new Exception("Ошибка получения списка уникальных номеров заказов сотрудника");
            }

            return listIds;
        }

        /// <summary>
        /// Метод, определяющий работает ли сотрудник над заказом
        /// </summary>
        /// <param name="idEmployee">id сотрудника</param>
        /// <returns>Работает ли сотрудник</returns>
        public static bool EmployeeIsWorking(int idEmployee)
        {
            bool isWorking = false;

            try
            {
                ConnectionToDb.Open();

                // Получаем количество заказов, над которыми работает сотрудник
                SqlCommand command = new SqlCommand("SELECT COUNT(fempId) FROM bookingEmployee WHERE fempId = '" + idEmployee + "'", ConnectionToDb.Connection);

                if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                    isWorking = true;

                ConnectionToDb.Close();
            }

            catch
            {
                throw new Exception("Ошибка получения данных о том, работает ли сотрудник над заказом(-ами)");
            }

            return isWorking;
        }

        /// <summary>
        /// Метод,определяющий работают ли сотрудники над заказом
        /// </summary>
        /// <param name="arrayIdemployees">Массив id сотрудников</param>
        /// <returns>Сотрудники работают</returns>
        public static bool EmployeesIsWorking(int[] arrayIdemployees)
        {
            bool isWorking = false;

            try
            {

                for (int i = 0; i < arrayIdemployees.Length; i++)
                {
                    if (EmployeeIsWorking(arrayIdemployees[i]))
                    {
                        isWorking = true;
                        break;
                    }
                }

            }
            catch
            {
                throw new Exception("Ошибка получения данных о том, работают ли сотрудники над заказом(-ами)");
            }

            return isWorking;
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
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM employee", ConnectionToDb.Connection);
                command.CommandType = CommandType.Text;
                count = Convert.ToInt32(command.ExecuteScalar());

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения количества сотрудников");
            }

            return count;

        }

        /// <summary>
        /// Метод получения данных о сотрудниках по определенному порядку фильтрации
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

                // Формируем, выполняем запрос на получения данных о сотрудниках в определенном порядке
                string query = String.Format("SELECT TOP {0} employee.empSurname AS N'Фамилия', employee.empFirstname AS N'Имя', employee.empMiddlename AS N'Отчество', employee.empType AS N'Должность', COUNT(bookingEmployee.fempId) AS N'Количество заказов' FROM employee LEFT JOIN bookingEmployee ON employee.empId = bookingEmployee.fempId GROUP BY employee.empSurname, employee.empFirstname, employee.empMiddlename, employee.empType ORDER BY COUNT(bookingEmployee.fempId) {1} ", outStringCount, order);
                SqlCommand command = new SqlCommand(query, ConnectionToDb.Connection);
                SqlDataReader dataReader = command.ExecuteReader();

                // Загружаем полученные данные в DataTable
                dt.Load(dataReader);

                ConnectionToDb.Close();
            }
            catch
            {              
                throw new Exception("Ошибка получения данных о сотрудниках");
            }

            return dt;
        }

        /// <summary>
        /// Метод получения массива id сотрудников
        /// </summary>
        /// <param name="dataGridView">Таблица с сотрудниками</param>
        /// <param name="selectedRows">Список выбранных строк</param>
        /// <returns>Массив id сотрудников</returns>
        public static int[] GetArrayIdEmployees(DataGridView dataGridView, List<int> selectedRows)
        {
            int indexArray = 0;
            int[] arrayId = new int[selectedRows.Count];

            SqlCommand command = new SqlCommand();
            try
            {
                ConnectionToDb.Open();

                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    // Если список содержит индекс
                    if (selectedRows.Contains(i))
                    {
                        // Получаем Email
                        string email = dataGridView.Rows[i].Cells["Электронная почта"].Value.ToString();

                        // Получаем id по Email и добавляем в массив
                        command = new SqlCommand("SELECT empId FROM employee WHERE empEmail = '" + email + "'", ConnectionToDb.Connection);
                        arrayId[indexArray++] = Convert.ToInt32(command.ExecuteScalar());
                    }
                }

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения массива идентификаторов записей о сотрудниках");
            }

            return arrayId;
        }

        /// <summary>
        /// Метод удаления сотрудников из бд
        /// </summary>
        /// <param name="arrayId">Массив id сотрудников</param>
        /// <returns>Количество удаленных записей</returns>
        public static int DeleteEmployees(int[] arrayId)
        {
            int countDeleteRows = 0;

            try
            {
                ConnectionToDb.Open();

                // Проходимся по массиву id
                for (int i = 0; i < arrayId.Length; i++)
                {
                    // Удаляем сотрудника с конкретным id
                    SqlCommand command = new SqlCommand("DELETE FROM employee WHERE empId = '"+arrayId[i]+"'", ConnectionToDb.Connection);
                    countDeleteRows += command.ExecuteNonQuery();
                }

                ConnectionToDb.Close();
            }
            catch
            {            
                throw new Exception("Произошла ошибка удаления сотрудников");
            }
            return countDeleteRows;
        }

        /// <summary>
        /// Метод, который подсвечивает строки с данными о сотрудниках
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        /// <param name="idEmployees">Массив id сотрудников</param>
        public static void SelectRowsInTable(DataGridView dataGridView, int[] idEmployees)
        {
            try
            {
                ConnectionToDb.Open();

                // Если нет данных
                if (dataGridView.RowCount < 1)
                    return;

                else
                {
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        for (int j = 0; j < idEmployees.Length; j++)
                        {
                           
                            string phone = dataGridView.Rows[i].Cells["Номер телефона"].Value.ToString();

                            // Если нашли сотрудника
                            if (idEmployees[j] == GetIdEmployeeByPhone(phone))                           
                                dataGridView.Rows[i].Cells[0].Value = true;     
                        }
                    }
                }

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка поиска строк с данными о сотрудниках");
            }
        }

    }
}

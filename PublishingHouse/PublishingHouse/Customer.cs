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

        public override string ToString()
        {
            return $"Наименование заказчика: {name}\nНомер телефона: {phone}\nЭлектронная почта: {email}";
        }

        /// <summary>
        /// Метод получения данных о заказчике
        /// </summary>
        /// <param name="idCustomer">id заказчика</param>
        /// <returns>Данные о заказчике</returns>
        public static Customer GetCustomer(int idCustomer) 
        {
            Customer customer = null;

            try
            {
                ConnectionToDb.Open();

                // Запрос на получение данных о заказчике
                SqlCommand command = new SqlCommand("SELECT * FROM customer WHERE custId = '"+idCustomer+"'", ConnectionToDb.Connection);
                SqlDataReader reader = command.ExecuteReader();

                // Считываем полученные данные
                while (reader.Read()) 
                {
                    customer = new Customer(reader["custName"].ToString(), reader["custEmail"].ToString(), reader["custPhone"].ToString());
                }

                ConnectionToDb.Close();
            }
            catch 
            {
                throw new Exception("Ошибка получения данных о заказчике");
            }

            return customer;
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
        /// Метод получения номеров заказов заказчика
        /// </summary>
        /// <param name="idCustomer">id заказчика</param>
        /// <returns>Список номеров заказов</returns>
        public static List<int> GetNumbersOfOrdersThisCustomer(string email)
        {
            List<int> listNumbers = new List<int>();

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
                    int numberOrder = Convert.ToInt32(dataReader["bkId"]);
                    listNumbers.Add(numberOrder);
                }

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения списка номеров заказов заказчика");
            }

            return listNumbers;
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
            bool haveBooking = false;

            try
            {
                ConnectionToDb.Open();

                // Получаем количество заказов заказчика
                SqlCommand command = new SqlCommand("SELECT COUNT(fcustId) FROM booking WHERE fcustId = '" + idCustomer + "'", ConnectionToDb.Connection);

                if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                    haveBooking = true;

                ConnectionToDb.Close();
            }

            catch
            {
                throw new Exception("Ошибка получения данных о том, имеет ли заказчик заказ(-ы)");
            }

            return haveBooking;
        }

        /// <summary>
        /// Метод,определяющий есть ли у заказчиков заказы
        /// </summary>
        /// <param name="arrayIdCustomers">Массив id заказчиков</param>
        /// <returns>У заказчиков есть заказ</returns>
        public static bool CustomersHaveBooking(int[] arrayIdCustomers)
        {
            bool haveBooking = false;

            try
            {

                for (int i = 0; i < arrayIdCustomers.Length; i++)
                {
                    if (CustomerHasBooking(arrayIdCustomers[i]))
                    {
                        haveBooking = true;
                        break;
                    }
                }

            }
            catch
            {
                throw new Exception("Ошибка получения данных о том, есть ли у заказчиков заказ(-ы)");
            }


            return haveBooking;
        }


        /// <summary>
        /// Метод, проверяющий существование электронной почты заказчика в бд 
        /// </summary>
        /// <param name="typeWork">Тип работы с данными</param>
        /// <param name="pastEmail">Прошлый Email</param>
        /// <param name="newEmail">Новый Email</param>
        /// <returns>Существует ли Email заказчика в бд</returns>
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
                    command = new SqlCommand("SELECT COUNT(custEmail) FROM customer WHERE custEmail = '" + newEmail + "'", ConnectionToDb.Connection);

                // Если пользователь редактирует запись
                else if (typeWork == 'C')
                {
                    // Получаем id записи
                    int id = GetIdCustomerByEmail(pastEmail);

                    ConnectionToDb.Open();

                    //Запрос на существование email, не учитывая изменяемую запись 
                    command = new SqlCommand("SELECT COUNT(custEmail) FROM customer WHERE custEmail = '" + newEmail + "' AND custId != '" + id + "' ", ConnectionToDb.Connection);

                }

                // Если email найден
                if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                    exist = true;

                ConnectionToDb.Close();
            }

            catch
            {
                throw new Exception("Ошибка проверки существования Email заказчика в базе данных");
            }

            return exist;
        }

        /// <summary>
        /// Метод, проверяющий существование номера телефона заказчика в бд 
        /// </summary>
        /// <param name="typeWork">Тип работы с данными</param>
        /// <param name="pastPhone">Прошлый номер телефона</param>
        /// <param name="newPhone">Новый номер телефона</param>
        /// <returns>Существует ли номер телефона заказчика в бд</returns>
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
                    command = new SqlCommand("SELECT COUNT(custPhone) FROM customer WHERE custPhone = '" + newPhone + "'", ConnectionToDb.Connection);

                // Если пользователь редактирует запись
                else if (typeWork == 'C')
                {
                    // Получаем id записи
                    int id = GetIdCustomerByPhone(pastPhone);

                    ConnectionToDb.Open();

                    //Запрос на существование номера телефона, не учитывая изменяемую запись 
                    command = new SqlCommand("SELECT COUNT(custPhone) FROM customer WHERE custPhone = '" + newPhone + "' AND custId != '" + id + "' ", ConnectionToDb.Connection);

                }

                // Если email найден
                if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                    exist = true;

                ConnectionToDb.Close();
            }

            catch
            {
                throw new Exception("Ошибка проверки существования номера телефона заказчика в базе данных");
            }

            return exist;
        }

        /// <summary>
        /// Метод изменения данных о заказчике
        /// </summary>
        /// <param name="id">id заказчика</param>
        /// <returns>Количество измененных данных</returns>
        public int ChangeCustomer(int id)
        {
            int countChangedRows = -1;

            try
            {
                ConnectionToDb.Open();

                // Указываем, что команда является хранимой процедурой
                const string SQLPROCEDURE = "changeCustomer";
                SqlCommand command = new SqlCommand(SQLPROCEDURE, ConnectionToDb.Connection);
                command.CommandType = CommandType.StoredProcedure;

                // Передаём данные для изменения записи
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phone;
                command.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
                command.Parameters.Add("@idCust", SqlDbType.Int).Value = id;

                // Получаем количество измененных записей
                countChangedRows = command.ExecuteNonQuery();

                ConnectionToDb.Close();
            }
            catch 
            {
                throw new Exception("Ошибка изменения данных о заказчике");
            }

            return countChangedRows;
        }

        /// <summary>
        /// Метод получения массива id заказчиков
        /// </summary>
        /// <param name="dataGridView">Таблица с заказчиками</param>
        /// <param name="selectedRows">Список выбранных строк</param>
        /// <returns>Массив id заказчиков</returns>
        public static int[] GetArrayIdCustomers(DataGridView dataGridView, List<int> selectedRows)
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
                        command = new SqlCommand("SELECT custId FROM customer WHERE custEmail = '" + email + "'", ConnectionToDb.Connection);
                        arrayId[indexArray++] = Convert.ToInt32(command.ExecuteScalar());
                    }
                }

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения массива идентификаторов записей о заказчиках");
            }

            return arrayId;
        }

        /// <summary>
        /// Метод удаления заказчиков из бд
        /// </summary>
        /// <param name="arrayId">Массив id заказчиков</param>
        /// <returns>Количество удаленных записей</returns>
        public static int DeleteCustomers(int[] arrayId)
        {
            int countDeleteRows = 0;

            try
            {
                ConnectionToDb.Open();

                // Проходимся по массиву id
                for (int i = 0; i < arrayId.Length; i++)
                {
                    // Удаляем заказчика с конкретным id
                    SqlCommand command = new SqlCommand("DELETE FROM customer WHERE custId = '" + arrayId[i] + "'", ConnectionToDb.Connection);
                    countDeleteRows += command.ExecuteNonQuery();
                }

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Произошла ошибка удаления заказчиков");
            }
            return countDeleteRows;
        }

        /// <summary>
        /// Метод, который подсвечивает строку с данными о заказчике
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        /// <param name="idCustomer">id заказчика</param>
        public static void SelectRowInTable(DataGridView dataGridView, int idCustomer)
        {
            try
            {
                ConnectionToDb.Open();

                if (dataGridView.RowCount < 1)
                    return;

                else
                {
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        string phone = dataGridView.Rows[i].Cells["Номер телефона"].Value.ToString();

                        // Если нашли сотрудника
                        if (idCustomer == GetIdCustomerByPhone(phone))
                            dataGridView.Rows[i].Cells[0].Value = true;
                    }
                }

                ConnectionToDb.Close();
            }
            catch 
            {
                throw new Exception("Ошибка поиска строки с данными о заказчике");
            }
        }
    }
}

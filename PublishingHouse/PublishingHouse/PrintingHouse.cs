using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PublishingHouse
{
    /// <summary>
    /// Класс для работы с типографией
    /// </summary>
    public class PrintingHouse
    {
        string name, numberPhone, email, typeState, nameState, city, typeStreet, nameStreet, numberHouse;

        public string Name { get { return name; } }
        public string NumberPhone { get { return numberPhone; } }
        public string Email { get { return email; } }
        public string TypeState { get { return typeState; } }
        public string NameState { get { return nameState; } }
        public string City { get { return city; } }
        public string TypeStreet { get { return typeStreet; } }
        public string NameStreet { get { return nameStreet; } }
        public string NumberHouse { get { return numberHouse; } }


        public PrintingHouse(string name, string numberPhone, string email, string typeState, string nameState, string city, string typeStreet, string nameStreet, string numberHouse)
        {
            this.name = name;
            this.numberPhone = numberPhone;
            this.email = email;
            this.typeState = typeState;
            this.nameState = nameState;
            this.city = city;
            this.typeStreet = typeStreet;
            this.nameStreet = nameStreet;
            this.numberHouse = numberHouse;
        }

        public override string ToString()
        {
            return $"Название: {name}\nНомер телефона: {numberPhone}\nЭлектронная почта: {email}\nТип субъекта: {typeState}\nНазвание субъекта: {nameState}\nГород: {city}\nТип улицы: {typeStreet}\nНазвание улицы: {nameStreet}\nНомер дома: {numberHouse}";
        }

        /// <summary>
        /// Метод получения данных о типографии
        /// </summary>
        /// <param name="idPrintingHouse">id типографии</param>
        /// <returns>Данные о типографии</returns>
        public static PrintingHouse GetPrintingHouse(int idPrintingHouse) 
        {
            PrintingHouse printingHouse = null;

            try
            {
                ConnectionToDb.Open();
                
                // Запрос на получение данных о типографии
                SqlCommand command = new SqlCommand("SELECT * FROM printingHouse WHERE phId = '"+idPrintingHouse+"'", ConnectionToDb.Connection);
                SqlDataReader reader = command.ExecuteReader();

                // Считываем полученные данные
                while (reader.Read()) 
                {
                    printingHouse = new PrintingHouse(reader["phName"].ToString(), reader["phPhone"].ToString(), reader["phEmail"].ToString(), reader["phTypeState"].ToString(), reader["phState"].ToString(), reader["phCity"].ToString(), reader["phTypeStreet"].ToString(), reader["phStreet"].ToString(), reader["phHouse"].ToString());
                }

                reader.Close();
                ConnectionToDb.Close();
            }
            catch 
            {
                throw new Exception("Ошибка получения данных о типографии");
            }

            return printingHouse;
        }

        /// <summary>
        /// Метод загрузки названий типографий в выпадающий список
        /// </summary>
        /// <param name="comboBox">Выпадающий список</param>
        public static void LoadNamePrintingHouseIntoComboBox(ComboBox comboBox) 
        {
            try
            {
                ConnectionToDb.Open();

                // Запрос на получение данных о названиях типографий
                SqlCommand command = new SqlCommand("SELECT phName FROM printingHouse ORDER BY phName", ConnectionToDb.Connection);
                SqlDataReader dataReader = command.ExecuteReader();

                // Заполняем выпадающий список
                while (dataReader.Read()) 
                {
                    comboBox.Items.Add(dataReader["phName"].ToString());
                }

                dataReader.Close();
                ConnectionToDb.Close();
            }
            catch 
            {
                throw new Exception("Ошибка заполнения выпадающего списка данными о типографиях");
            }
        }

        /// <summary>
        /// Метод добавления типографии в бд
        /// </summary>
        /// <returns>Количество добавленных записей</returns>
        public int AddPrintingHouse()
        {
            int count = 0;

            try
            {
                ConnectionToDb.Open();

                // Указываем, что команда является хранимой процедурой
                const string SQLPROCEDURE = "addPrintingHouse";
                SqlCommand command = new SqlCommand(SQLPROCEDURE, ConnectionToDb.Connection);
                command.CommandType = CommandType.StoredProcedure;

                // Передаём данные для добавления записи
                command.Parameters.Add("@phName", SqlDbType.NVarChar).Value = name;
                command.Parameters.Add("@phPhone", SqlDbType.NVarChar).Value = numberPhone;
                command.Parameters.Add("@phEmail", SqlDbType.NVarChar).Value = email;
                command.Parameters.Add("@phTypeState", SqlDbType.NVarChar).Value = typeState;
                command.Parameters.Add("@phState", SqlDbType.NVarChar).Value = nameState;
                command.Parameters.Add("@phCity", SqlDbType.NVarChar).Value = city;
                command.Parameters.Add("@phStreet", SqlDbType.NVarChar).Value = nameStreet;
                command.Parameters.Add("@phHouse", SqlDbType.NVarChar).Value = numberHouse;
                command.Parameters.Add("@phTypeStreet", SqlDbType.NVarChar).Value = typeStreet;

                count = command.ExecuteNonQuery();

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка добавления типографии");
            }

            return count;
        }

        /// <summary>
        /// Метод добавления данных о типографиях в таблицу
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        public static void LoadPrintingHouse(DataGridView dataGridView)
        {
            try
            {
                DataTable dt = new DataTable();

                ConnectionToDb.Open();

                // Запрос на вывод всех типографий
                SqlCommand command = new SqlCommand("SELECT phName AS N'Название', phPhone AS N'Номер телефона', phEmail AS N'Электронная почта', phTypeState AS N'Тип субъекта'," +
                    " phState AS N'Название субъекта', phCity AS N'Город', phTypeStreet AS N'Тип улицы', phStreet AS N'Название улицы', phHouse AS N'Дом №' FROM printingHouse ORDER BY phName", ConnectionToDb.Connection);
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader();

                // Загружаем данные о типографиях в таблицу
                dt.Load(dataReader);
                dataGridView.DataSource = dt;



                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка загрузки данных о типографиях");
            }
        }

        /// <summary>
        /// Метод получения списка номеров заказов конкретной типографии
        /// </summary>
        /// <param name="email">Электронная почта</param>
        /// <returns>Список номеров заказов</returns>
        public static List<string> GetNumbersOfOrdersThisPrintingHouse(string email)
        {
            List<string> orders = new List<string>();

            try
            {
                // Получаем id типографии
                int id = GetIdPrintingHouseByEmail(email);

                ConnectionToDb.Open();

                // Создаём запрос на получение номеров заказов и получаем их
                SqlCommand command = new SqlCommand($"SELECT * FROM booking, printingHouse WHERE booking.fphId = {id} AND printingHouse.phId = {id}", ConnectionToDb.Connection);
                SqlDataReader dataReader = command.ExecuteReader();


                // Считываем данные из ридера и записываем в список
                while (dataReader.Read())
                {
                    // Получаем номер заказа
                    int numberOfOrder = Convert.ToInt32(dataReader["bkId"]);
                    orders.Add(numberOfOrder.ToString());
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
        /// Метод получения списка с id
        /// </summary>
        /// <returns>Список с id</returns>
        private static List<int> GetListId() 
        {
            List<int> listId = new List<int>();

            try
            {
                ConnectionToDb.Open();

                // Получаем id записей о типографиях
                SqlCommand command = new SqlCommand("SELECT phId FROM printingHouse", ConnectionToDb.Connection);
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read()) 
                {
                    // Добавляем id в список                    
                    listId.Add(Convert.ToInt32(dataReader["phId"]));
                }

                ConnectionToDb.Close();
            }
            catch 
            {
                throw new Exception("Ошибка получения списка уникальных номеров записей о типографиях");
            }

            return listId;
        }

        /// <summary>
        /// Метод получения id записи о типографии по электронной почте
        /// </summary>
        /// <param name="email">Электронная почта</param>
        /// <returns>id записи</returns>
        public static int GetIdPrintingHouseByEmail(string email)
        {
            int id = 0;

            try
            {
                ConnectionToDb.Open();

                // Создаём запрос на получение id записи о типографии
                SqlCommand command = new SqlCommand("Select phId FROM printingHouse WHERE phEmail = N'" + email + "'", ConnectionToDb.Connection);
                // Получаем id записи
                id = Convert.ToInt32(command.ExecuteScalar());
                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Произошла ошибка получения уникального номера записи о типографии");
            }

            return id;
        }

        /// <summary>
        /// Метод получения id записи о типографии по номеру телефона
        /// </summary>
        /// <param name="email">Электронная почта</param>
        /// <returns>id записи</returns>
        private static int GetIdPrintingHouseByNumberPhone(string numberPhone)
        {
            int id = 0;

            try
            {
                ConnectionToDb.Open();

                // Создаём запрос на получение id записи о типографии
                SqlCommand command = new SqlCommand("Select phId FROM printingHouse WHERE phPhone = N'" + numberPhone + "'", ConnectionToDb.Connection);
                // Получаем id записи
                id = Convert.ToInt32(command.ExecuteScalar());
                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Произошла ошибка получения уникального номера записи о типографии");
            }

            return id;
        }

        /// <summary>
        /// Метод получения id записи о типографии по названию
        /// </summary>
        /// <param name="email">Электронная почта</param>
        /// <returns>id записи</returns>
        public static int GetIdPrintingHouseByName(string name)
        {
            int id = 0;

            try
            {
                ConnectionToDb.Open();

                // Создаём запрос на получение id записи о типографии
                SqlCommand command = new SqlCommand("Select phId FROM printingHouse WHERE phName = N'" + name + "'", ConnectionToDb.Connection);
                // Получаем id записи
                id = Convert.ToInt32(command.ExecuteScalar());
                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Произошла ошибка получения уникального номера записи о типографии");
            }

            return id;
        }

        /// <summary>
        /// Метод удаления типографий из бд
        /// </summary>
        /// <param name="arrayId">Массив id типографий</param>
        /// <returns>Количество удаленных записей</returns>
        public static int DeletePrintingHouses(int[] arrayId)
        {
            int countDeleteRows = 0;

            try
            {
                ConnectionToDb.Open();

            // Проходимся по массиву id
            for (int i = 0; i < arrayId.Length; i++)
            {
                // Удаляем типографию с конкретным id
                SqlCommand command = new SqlCommand($"DELETE FROM printingHouse WHERE phId = {arrayId[i]}", ConnectionToDb.Connection);
                countDeleteRows += command.ExecuteNonQuery();
            }

            ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Произошла ошибка удаления типографий");
            }
            return countDeleteRows;
        }

        /// <summary>
        /// Метод изменения данных о типографии
        /// </summary>
        /// <param name="id">id типографии</param>
        /// <returns>Количество измененных строк</returns>
        public int ChangePrintingHouse(int id) 
        {
            int countRows = 0;

            try
            {
                ConnectionToDb.Open();

                // Формируем запрос на изменение данных и выполняем его
                SqlCommand command = new SqlCommand("UPDATE printingHouse SET phName = N'"+ name +"', phPhone = N'"+ numberPhone +"', phEmail = N'"+ email +"', phTypeState = N'"+ typeState +"', phState = N'"+ nameState +"', phCity = N'"+ city +"', phStreet = N'"+ nameStreet +"', phHouse = N'"+ numberHouse +"', phTypeStreet = N'"+ typeStreet +"' WHERE phId = '"+ id +"'", ConnectionToDb.Connection);
                
                // Получаем количество изменненных записей
                countRows = command.ExecuteNonQuery();
                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка изменения данных о типографии");
            }
            return countRows;
        }

        /// <summary>
        /// Метод получения массива id типографий
        /// </summary>
        /// <param name="dataGridView">Таблица с типографиями</param>
        /// <param name="selectedRows">Список выбранных строк</param>
        /// <returns>Массив id типографий</returns>
        public static int[] GetArrayIdPrintingHouse(DataGridView dataGridView, List<int> selectedRows)
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
                    command = new SqlCommand("SELECT phId FROM printingHouse WHERE phEmail = '" + email + "'", ConnectionToDb.Connection);
                    arrayId[indexArray++] = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения массива идентификаторов записей о типографиях");
            }

            return arrayId;
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
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM printingHouse", ConnectionToDb.Connection);
                command.CommandType = CommandType.Text;
                count = Convert.ToInt32(command.ExecuteScalar());

                ConnectionToDb.Close();
            }
            catch 
            {
                throw new Exception("Ошибка получения количества типографий");
            }

            return count;
        }

        /// <summary>
        /// Метод получения данных о типографих по определенному порядку фильтрации
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

                // Формируем, выполняем запрос на получение данных о типографиях в определенном порядке
                string query = String.Format("SELECT TOP {0} printingHouse.phName AS N'Название компании', COUNT(booking.fphId) AS N'Количество заказов' FROM printingHouse LEFT JOIN booking ON printingHouse.phId = booking.fphId GROUP BY printingHouse.phName ORDER BY COUNT(booking.fphId) {1} ", outStringCount, order);
                SqlCommand command = new SqlCommand(query, ConnectionToDb.Connection);
                SqlDataReader dataReader = command.ExecuteReader();
                
                // Загружаем полученные данные в DataTable
                dt.Load(dataReader);

            

            ConnectionToDb.Close();
            }
            catch
            { 
               throw new Exception("Ошибка получения данных о типографиях");
            }

            return dt;
        }

        /// <summary>
        /// Метод, проверяющий существование электронной почты типографии в бд 
        /// </summary>
        /// <param name="typeWork">Тип работы с данными</param>
        /// <param name="pastEmail">Прошлый Email</param>
        /// <param name="newEmail">Новый Email</param>
        /// <returns>Существует ли Email типографии в бд</returns>
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
                    command = new SqlCommand("SELECT COUNT(phEmail) FROM printingHouse WHERE phEmail = '" + newEmail + "'", ConnectionToDb.Connection);
                
                // Если пользователь редактирует запись
                else if (typeWork == 'C') 
                {
                    // Получаем id записи
                    int id = GetIdPrintingHouseByEmail(pastEmail);

                    ConnectionToDb.Open();

                    //Запрос на существование email, не учитывая изменяемую запись 
                    command = new SqlCommand("SELECT COUNT(phEmail) FROM printingHouse WHERE phEmail = '"+ newEmail +"' AND phId != '"+ id +"' ", ConnectionToDb.Connection);

                }
 
                // Если email найден
                if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                    exist = true;

                ConnectionToDb.Close();
            }

            catch
            {               
                throw new Exception("Ошибка проверки существования Email типографии в базе данных");
            }

            return exist;
        }

        /// <summary>
        /// Метод, проверяющий существование номера телефона типографии в бд 
        /// </summary>
        /// <param name="typeWork">Тип работы с данными</param>
        /// <param name="pastPhone">Прошлый номер телефона</param>
        /// <param name="newPhone">Новый номер телефона</param>
        /// <returns>Существует ли номер телефона типографии в бд</returns>
        public static bool ExistPhoneInDb(char typeWork, string pastPhone, string newPhone)
        {
            bool exist = false;

            try
            {
                ConnectionToDb.Open();
                SqlCommand command = new SqlCommand();

                // Если пользователь добавляет запись
                if (typeWork == 'A')
                    // Запрос на существование email
                    command = new SqlCommand("SELECT COUNT(phPhone) FROM printingHouse WHERE phPhone = '" + newPhone + "'", ConnectionToDb.Connection);

                // Если пользователь редактирует запись
                else if (typeWork == 'C')
                {
                    // Получаем id записи
                    int id = GetIdPrintingHouseByNumberPhone(pastPhone);

                    ConnectionToDb.Open();

                    //Запрос на существование номера телефона, не учитывая изменяемую запись 
                    command = new SqlCommand("SELECT COUNT(phPhone) FROM printingHouse WHERE phPhone = '" + newPhone + "' AND phId != '" + id + "' ", ConnectionToDb.Connection);

                }

                // Если номер телефона найден
                if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                    exist = true;

                ConnectionToDb.Close();
            }

            catch
            {
                throw new Exception("Ошибка проверки существования номера телефона типографии в базе данных");
            }

            return exist;
        }

        /// <summary>
        /// Метод, проверяющий существование названия типографии в бд 
        /// </summary>
        /// <param name="typeWork">Тип работы с данными</param>
        /// <param name="pastName">Прошлое название типографии</param>
        /// <param name="newName">Новое название типографии</param>
        /// <returns>Существует ли номер телефона в бд</returns>
        public static bool ExistNameOfPrintingHouseInDb(char typeWork, string pastName, string newName)
        {
            bool exist = false;

            try
            {
                ConnectionToDb.Open();
                SqlCommand command = new SqlCommand();

                // Если пользователь добавляет запись
                if (typeWork == 'A')
                    // Запрос на существование названия типографии
                    command = new SqlCommand("SELECT COUNT(phName) FROM printingHouse WHERE phName = '" + newName + "'", ConnectionToDb.Connection);

                // Если пользователь редактирует запись
                else if (typeWork == 'C')
                {
                    // Получаем id записи
                    int id = GetIdPrintingHouseByName(pastName);

                    ConnectionToDb.Open();

                    //Запрос на существование названия типографии, не учитывая изменяемую запись 
                    command = new SqlCommand("SELECT COUNT(phName) FROM printingHouse WHERE phName = '" + newName + "' AND phId != '" + id + "' ", ConnectionToDb.Connection);

                }

                // Если название типографии найдено
                if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                    exist = true;

                ConnectionToDb.Close();
            }

            catch
            {
                throw new Exception("Ошибка проверки существования названия типографии в базе данных");
            }

            return exist;
        }

        /// <summary>
        /// Метод,определяющий работают ли типографии над заказом
        /// </summary>
        /// <param name="arrayIdPrHouse">Массив id типографий</param>
        /// <returns>Типографии работают</returns>
        public static bool PrintingHousesIsWorking(int[] arrayIdPrHouse) 
        {
            bool isWorking = false;

            try
            {

                for (int i = 0; i < arrayIdPrHouse.Length; i++)
                {
                    if (PrintingHouseIsWorking(arrayIdPrHouse[i])) 
                    {
                        isWorking = true;
                        break;
                    }
                }
                
            }
            catch 
            {
                throw new Exception("Ошибка получения данных о том, работают ли типографии над заказом(-ами)");
            }


            return isWorking;
        }

        /// <summary>
        /// Метод, определяющий работает ли типография над заказом
        /// </summary>
        /// <param name="idPrHouse">id типографии</param>
        /// <returns>Работает ли типография</returns>
        public static bool PrintingHouseIsWorking(int idPrHouse) 
        {
            bool isWorking = false;

            try
            {
                ConnectionToDb.Open();

                // Получаем количество заказов, над которыми работает типография
                SqlCommand command = new SqlCommand("SELECT COUNT(fphId) FROM booking WHERE fphId = '" + idPrHouse + "'", ConnectionToDb.Connection);

                if (Convert.ToInt32(command.ExecuteScalar()) > 0)               
                    isWorking = true;
                   
                ConnectionToDb.Close();
            }

            catch 
            {
                throw new Exception("Ошибка получения данных о том, работает ли типография над заказом(-ами)");
            }

            return isWorking;
        }


    }
}

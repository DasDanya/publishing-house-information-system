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
        public string NumberPhone { get { return  numberPhone; } }
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
            return $"{name}\n {numberPhone}\n {email}\n {typeState}\n {nameState}\n {city}\n {typeStreet}\n {nameStreet}\n {numberHouse}";
        }

        ///// <summary>
        ///// Метод, определяющий заполнены ли поля класса
        ///// </summary>
        ///// <returns>Заполнены ли поля класса</returns>
        //public bool IsFilled() 
        //{
        //    if (name != "" && numberPhone != "" && email != "" && typeState != "" && nameState != "" && city != "" && typeStreet != "" && nameStreet != "" && numberHouse != "")
        //        return true;
        //    else
        //        return false;
        //}

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

        //private static void GetListPerformedOrders(DataGridView dataGridView)
        //{
        //    DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();

        //    column.HeaderText = "Заказы";
        //    column.Name = "Orders";

        //    dataGridView.Columns.Add(column.Name, column.HeaderText);

        //    column.Items.Add("555");
        //    column.Items.Add("666");

        //    for (int i = 0; i < dataGridView.Rows.Count; i++)
        //    {

        //    }   
        //}

        //

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
                int id = GetIdPrintingHouse(email);

                ConnectionToDb.Open();

                // Создаём запрос на получение номеров заказов
                SqlCommand command = new SqlCommand($"SELECT * FROM booking, printingHouse WHERE booking.fphId = {id} AND printingHouse.phId = {id}", ConnectionToDb.Connection);
                SqlDataReader dataReader = command.ExecuteReader();
                

                // Считываем данные из ридера и записываем в список
                while (dataReader.Read())
                {
                    // Получаем номер заказа
                    int numberOfOrder = Convert.ToInt32(dataReader["bkNumber"]);
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
        /// Метод получения id записи о типографии
        /// </summary>
        /// <param name="email">Электронная почта</param>
        /// <returns>id записи</returns>
        private static int GetIdPrintingHouse(string email) 
        {
            int id = 0;

            try
            {
                ConnectionToDb.Open();

                // Создаём запрос на получение id записи о типографии
                SqlCommand command = new SqlCommand("Select phId FROM printingHouse WHERE phEmail = N'"+email+"'", ConnectionToDb.Connection);
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

        public static int DeletePrintingHouses(int[] arrayId) 
        {
            int countDeleteRows = 0;

            //try
            //{
                ConnectionToDb.Open();
                               
                for (int i = 0; i < arrayId.Length; i++)
                {
                    SqlCommand command = new SqlCommand($"DELETE FROM printingHouse WHERE phId = {arrayId[i]}", ConnectionToDb.Connection);
                    countDeleteRows += command.ExecuteNonQuery();
                }

                ConnectionToDb.Close();
            //}
            //catch(Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
            return countDeleteRows;
        }


        public static int[] GetArrayIdPrintingHouse(DataGridView dataGridView, List<int> selectedRows) 
        {
            int indexArray = 0;
            int[] arrayId = new int[selectedRows.Count];

            SqlCommand command = new SqlCommand();
            //try
            //{
                ConnectionToDb.Open();

                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    // Если список содержит индекс
                    if (selectedRows.Contains(i)) 
                    {
                        string email = dataGridView.Rows[i].Cells["Электронная почта"].Value.ToString();

                        command = new SqlCommand("SELECT phId FROM printingHouse WHERE phEmail = '"+email+"'", ConnectionToDb.Connection);                       
                        arrayId[indexArray++] = Convert.ToInt32(command.ExecuteScalar());
                    }
                }

                ConnectionToDb.Close();
            //}
            //catch(Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}

            return arrayId;
        }
    }
}

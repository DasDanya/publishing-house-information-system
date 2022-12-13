using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace PublishingHouse
{
    public class TypeProduct
    {
        string name;
        double margin;

        public string Name { get { return name; } }
        public double Margin { get { return margin; } }

        public TypeProduct(string name, double margin)
        {
            this.name = name;
            this.margin = margin;
        }

        public override string ToString()
        {
            return $"Тип печатной продукции: {name}\nНаценка в %: {margin}";
        }

        /// <summary>
        /// Метод получения id типа печатной продукции
        /// </summary>
        /// <param name="name">Название типа печатной продукции</param>
        /// <param name="margin">Наценка типа печатной продукции</param>
        /// <returns>id типа печатной продукции</returns>
        public static int GetIdTypeProduct(string name,double margin)
        {
            int id = -1;

            try
            {
                ConnectionToDb.Open();

                //Указываем,что команда является хранимой процедурой
                const string SQLPROCEDURE = "GetIdTypeProduct";
                SqlCommand command = new SqlCommand(SQLPROCEDURE, ConnectionToDb.Connection);
                command.CommandType = CommandType.StoredProcedure;

                //Передаём данные типа печатной продукции
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@margin", margin);

                //Получаем id                 
                id = Convert.ToInt32(command.ExecuteScalar());

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения уникального номера записи о типе печатной продукции");
            }


            return id;
        }


        /// <summary>
        /// Метод получения данных о типе печатных продукций
        /// </summary>
        /// <param name="idTypeProduct">id типа печатной продукции</param>
        /// <returns>Данные о типе печатных продукций</returns>
        public static TypeProduct GetTypeProduct(int idTypeProduct) 
        {
            TypeProduct typeProduct = null;

            try
            {
                ConnectionToDb.Open();

                // Запрос на получение данных о типе печатных продукций
                SqlCommand command = new SqlCommand("SELECT * FROM typeProduct WHERE typeProdId = '"+idTypeProduct+"'", ConnectionToDb.Connection);
                SqlDataReader reader = command.ExecuteReader();

                // Считываем полученные данные
                while (reader.Read()) 
                {
                    typeProduct = new TypeProduct(reader["typeProdName"].ToString(), Convert.ToDouble(reader["typeProdMargin"]));
                }

                reader.Close();
                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения данных о типе печатной продукции");
            }

            return typeProduct;
        }


        /// <summary>
        /// Метод получения id типа печатной продукции
        /// </summary>
        /// <param name="idProduct">id печатной продукции</param>
        /// <returns>id типа печатной продукции</returns>
        public static int GetIdTypeProduct(int idProduct) 
        {
            int id = 0;

            try
            {
                ConnectionToDb.Open();

                // Запрос на получение id типа печатной продукции
                SqlCommand command = new SqlCommand("SELECT ftypeProdId FROM product WHERE prodId = '"+idProduct+"'", ConnectionToDb.Connection);
                id = Convert.ToInt32(command.ExecuteScalar());

                ConnectionToDb.Close();
            }
            catch 
            {
                throw new Exception("Ошибка получение уникального номера записи о типе печатной продукции");
            }

            return id;
        }

        ///// <summary>
        ///// Метод получения id типа печатной продукции
        ///// </summary>
        ///// <param name="idProduct">id печатной продукции</param>
        ///// <returns>id типа печатной продукции</returns>
        //public static int GetIdTypeProduct(int idProduct)
        //{
        //    int idTypeProduct = 0;

        //    try
        //    {
        //        ConnectionToDb.Open();

        //        // Формируем запрос на получение id типа печатной продукции
        //        SqlCommand command = new SqlCommand("SELECT ftypeProdId FROM product WHERE prodId = '"+idProduct+"'", ConnectionToDb.Connection);
        //        idTypeProduct = Convert.ToInt32(command.ExecuteScalar());

        //        ConnectionToDb.Close();
        //    }
        //    catch
        //    {
        //        throw new Exception("Ошибка получения id типа печатной продукции");
        //    }

        //    return idTypeProduct;
        //}


        /// <summary>
        /// Метод проверки существования типа печатной продукции в бд
        /// </summary>
        /// <param name="typeWork">Тип работы с данными</param>
        /// <param name="pastMargin">Старая наценка</param>
        /// <param name="newMargin">Новая наценка</param>
        /// <param name="pastName">Прошлое название</param>
        /// <param name="newName">Новое название</param>
        /// <returns>Существует ли тип печатной продукции в бд</returns>
        public static bool ExistTypeProductInDb(char typeWork, double pastMargin, double newMargin, string pastName, string newName)
        {
            bool exist = false;

            try
            {
                ConnectionToDb.Open();
                SqlCommand command = new SqlCommand();

                // Если пользователь добавляет запись
                if (typeWork == 'A')
                {
                    // Запрос на существование типа печатной продукции
                    command = new SqlCommand("SELECT typeProdId FROM typeProduct WHERE typeProdName = N'" + newName + "' AND typeProdMargin = @margin", ConnectionToDb.Connection);
                    command.Parameters.Add("@margin", SqlDbType.Float).Value = newMargin;
                }


                // Если пользователь редактирует запись
                else if (typeWork == 'C')
                {
                    // Получаем id записи
                    int id = GetIdTypeProduct(pastName, pastMargin);
                    ConnectionToDb.Open();

                    //Запрос на существование типа печатной продукции, не учитывая изменяемую запись 
                    command = new SqlCommand("SELECT COUNT(typeProdId) FROM typeProduct WHERE typeProdMargin = @newMargin AND typeProdName = N'" + newName + "' AND typeProdId != '" + id + "' ", ConnectionToDb.Connection);
                    command.Parameters.Add("@newMargin", SqlDbType.Float).Value = newMargin;

                }

                // Если тип печатной продукции найден
                if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                    exist = true;


                ConnectionToDb.Close();
            }

            catch
            {
                throw new Exception("Ошибка проверки существования типа печатной продукции в базе данных");
            }

            return exist;
        }


        /// <summary>
        /// Метод добавления типа печатной продукции в бд
        /// </summary>
        /// <returns>Количество добавленных типов печатной продукции</returns>
        public int AddTypeProduct()
        {
            int countTypesProducts = -1;

            try
            {
                ConnectionToDb.Open();

                // Создаём запрос на добавление типа печатной продукции и выполняем его
                SqlCommand command = new SqlCommand("INSERT INTO typeProduct (typeProdName, typeProdMargin) VALUES (N'" + name + "', @margin)", ConnectionToDb.Connection);
                command.Parameters.Add("@margin", SqlDbType.Float).Value = margin;
                countTypesProducts = command.ExecuteNonQuery();

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка добавления типа печатной продукции");
            }

            return countTypesProducts;
        }

        /// <summary>
        /// Метод добавления данных о типах печатной продукции в таблицу
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        public static void LoadTypesProduct(DataGridView dataGridView)
        {

            try
            {
                ConnectionToDb.Open();

                // Запрос на получение типов печатной продукции
                SqlCommand command = new SqlCommand("SELECT typeProdName AS 'Тип печатной продукции', typeProdMargin AS 'Наценка в %' FROM typeProduct ORDER BY typeProdName", ConnectionToDb.Connection);
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader();

                // Загружаем данные о типах печатной продукции в таблицу
                DataTable dt = new DataTable();
                dt.Load(dataReader);
                dataGridView.DataSource = dt;

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения данных о типах печатной продукции");
            }

        }


        /// <summary>
        /// Метод, определяющий указан ли тип печатной продукции
        /// </summary>
        /// <param name="idTypeProduct">id типа печатной продукции</param>
        /// <returns>Указан ли тип печатной продукции</returns>
        public static bool TypeProductIsIndicated(int idTypeProduct)
        {
            bool isIndicated = false;

            try
            {
                ConnectionToDb.Open();

                // Получаем количество использований
                SqlCommand command = new SqlCommand("SELECT COUNT(ftypeProdId) FROM product WHERE ftypeProdId = '" + idTypeProduct + "'", ConnectionToDb.Connection);

                if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                    isIndicated = true;

                ConnectionToDb.Close();
            }

            catch
            {
                throw new Exception("Ошибка получения данных о том, указан ли тип печатной продукции");
            }

            return isIndicated;
        }

        /// <summary>
        /// Метод,определяющий указаны ли типы печатной продукции
        /// </summary>
        /// <param name="arrayIdTypesProduct">Массив id типов печатной продукции</param>
        /// <returns>Указан ли хоть один тип печатной продукции</returns>
        public static bool TypeProductAreIndicated(int[] arrayIdTypesProduct)
        {
            bool areIndicated = false;

            try
            {

                for (int i = 0; i < arrayIdTypesProduct.Length; i++)
                {
                    if (TypeProductIsIndicated(arrayIdTypesProduct[i]))
                    {
                        areIndicated = true;
                        break;
                    }
                }

            }
            catch
            {
                throw new Exception("Ошибка получения данных о том, указаны ли типы печатной продукции");
            }


            return areIndicated;
        }


        /// <summary>
        /// Метод изменения данных о типе печатной продукции
        /// </summary>
        /// <param name="id">id записи о типе печатной продукции</param>
        /// <returns>Количество измененных записей</returns>
        public int ChangeTypeProduct(int id)
        {
            int countChangedRows = -1;

            try
            {
                ConnectionToDb.Open();

                // Формируем запрос на изменение данных о типе печатной продукции и выполняем его
                SqlCommand command = new SqlCommand("UPDATE typeProduct SET typeProdName = N'" + name + "', typeProdMargin = @margin WHERE typeProdId = '" + id + "' ", ConnectionToDb.Connection);
                command.Parameters.Add("@margin", SqlDbType.Float).Value = margin;
                countChangedRows = command.ExecuteNonQuery();

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка изменения данных о типе печатной продукции");
            }

            return countChangedRows;
        }

        /// <summary>
        /// Метод получения массива id типов печатной продукции
        /// </summary>
        /// <param name="dataGridView">Таблица с типами печатной продукции</param>
        /// <param name="selectedRows">Список выбранных строк</param>
        /// <returns>Массив id типов печатной продукции</returns>
        public static int[] GetArrayIdTypesProduct(DataGridView dataGridView, List<int> selectedRows)
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
                        // Получаем id и добавляем в список
                        arrayId[indexArray++] = GetIdTypeProduct(dataGridView.Rows[i].Cells["Тип печатной продукции"].Value.ToString(), Convert.ToDouble(dataGridView.Rows[i].Cells["Наценка в %"].Value));
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
        /// Метод удаления типов печатной продукции из бд
        /// </summary>
        /// <param name="arrayId">Массив id типов печатной продукции</param>
        /// <returns>Количество удаленных записей</returns>
        public static int DeleteTypesProduct(int[] arrayId)
        {
            int countDeleteRows = 0;

            try
            {
                ConnectionToDb.Open();

                // Проходимся по массиву id
                for (int i = 0; i < arrayId.Length; i++)
                {
                    // Удаляем тип печатной продукции с конкретным id
                    SqlCommand command = new SqlCommand("DELETE FROM typeProduct WHERE typeProdId = '" + arrayId[i] + "'", ConnectionToDb.Connection);
                    countDeleteRows += command.ExecuteNonQuery();
                }

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Произошла ошибка удаления типов печатной продукции");
            }
            return countDeleteRows;
        }

        /// <summary>
        /// Метод получения печатных продукций выбранного типа печатной продукции
        /// </summary>
        /// <param name="name">Название типа печатной продукции</param>
        /// <param name="margin">Наценка</param>
        /// <returns>Список печатных продукций</returns>
        public static List<Product> GetListProductsThisTypeProduct(string name, double margin)
        {
            List<Product> products = new List<Product>();

            try
            {

                // Получаем id типа печатной продукции
                int id = GetIdTypeProduct(name, margin);

                ConnectionToDb.Open();

                // Выполняем запрос на получения списка печатных продукций
                SqlCommand command = new SqlCommand("SELECT * FROM typeProduct, product WHERE product.ftypeProdId = '" + id + "' AND typeProduct.typeProdId = '" + id + "'", ConnectionToDb.Connection);
                SqlDataReader dataReader = command.ExecuteReader();

                // Считываем данные из ридера и записываем в список
                while (dataReader.Read())
                {
                    // Получаем данные о печатной продукции и добавляем в список
                    string nameProduct = dataReader["prodName"].ToString();
                    int numberEdition = Convert.ToInt32(dataReader["prodNumEdition"]);
                    products.Add(new Product(nameProduct, numberEdition));
                }

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения списка печатных продукций конкретного типа печатной продукции");
            }

            return products;
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
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM typeProduct", ConnectionToDb.Connection);
                command.CommandType = CommandType.Text;
                count = Convert.ToInt32(command.ExecuteScalar());

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения количества типов печатной продукции");
            }

            return count;
        }

        /// <summary>
        /// Метод получения данных о типах печатной продукции по определенному порядку фильтрации
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

                // Формируем, выполняем запрос на получение данных о типах печатной продукции в определенном порядке
                string query = String.Format("SELECT TOP {0} typeProduct.typeProdName AS N'Название типа печатной продукции', typeProduct.typeProdMargin AS N'Наценка в %', COUNT(product.ftypeProdId) AS N'Количество упоминаний' FROM typeProduct LEFT JOIN product ON typeProduct.typeProdId = product.ftypeProdId GROUP BY typeProduct.typeProdName, typeProduct.typeProdMargin ORDER BY COUNT(product.ftypeProdId) {1} ", outStringCount, order);
                SqlCommand command = new SqlCommand(query, ConnectionToDb.Connection);
                SqlDataReader dataReader = command.ExecuteReader();

                // Загружаем полученные данные в DataTable
                dt.Load(dataReader);

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения данных о типах печатной продукции");
            }

            return dt;
        }

        /// <summary>
        /// Метод поиска строки о типе печатной продукции в таблице
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        /// <param name="idTypeProduct">id типа печатной продукции</param>
        public static void SelectRowTypeProduct(DataGridView dataGridView, int idTypeProduct)
        {
            string name = "";
            double margin = 0;
            try
            {
                ConnectionToDb.Open();

                // Запрос на получение данных о типе печатной продукции
                SqlCommand command = new SqlCommand("SELECT typeProdName, typeProdMargin FROM typeProduct WHERE typeProdId = '"+idTypeProduct+"'", ConnectionToDb.Connection);
                SqlDataReader reader = command.ExecuteReader();

                // Получаем данные о типе печатной продукции
                while (reader.Read()) 
                {
                    name = reader["typeProdName"].ToString();
                    margin = Convert.ToDouble(reader["typeProdMargin"]);
                }

                ConnectionToDb.Close();

                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    // Если найдена строка с данными о типе печатной продукции
                    if (dataGridView.Rows[i].Cells["Тип печатной продукции"].Value.ToString() == name && Convert.ToDouble(dataGridView.Rows[i].Cells["Наценка в %"].Value) == margin)
                        // Выделяем строку о типе печатной продукции
                        dataGridView.Rows[i].Cells[0].Value = true;
                        
                }
            }
            catch 
            {
                throw new Exception("Ошибка поиска строки о указанном типе печатной продукции");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PublishingHouse
{
    /// <summary>
    /// Класс для работы с материалом
    /// </summary>
    public class Material
    {
        string type, color, size;
        double cost;
        int id, count;

        public int Id { get { return id; } }
        public int Count { get { return count; } }

        //public string Type { get { return type; } }


        ///// <summary>
        ///// Конструктор для заполнения определенного поля
        ///// </summary>
        ///// <param name="value">Значение</param>
        ///// <param name="field">Поле</param>
        //public Material(string value, string field) 
        //{
        //    if (field == "type")
        //        type = value;
        //    if (field == "color")
        //        color = value;
        //    if (field == "size")
        //        size = value;
        //}


        public Material(string type, string color, string size, double cost)
        {
            this.type = type;
            this.color = color;
            this.size = size;
            this.cost = Math.Round(cost, 2);
        }

        public Material(int id, int count) 
        {
            this.id = id;
            this.count = count;
        }

        public Material(string type, string color, string size, double cost, int count) 
        {
            this.type = type;
            this.color = color;
            this.size = size;
            this.cost = cost;
            this.count = count;

        }

        /// <summary>
        /// Метод получения материала
        /// </summary>
        /// <param name="idMaterial">id материала</param>
        /// <param name="count">Количество использований</param>
        /// <returns>Материал</returns>
        public static Material GetMaterial(int idMaterial, int count) 
        {
            Material material = null;

            try
            {
                ConnectionToDb.Open();

                // Запос на получение данных о материале
                SqlCommand command = new SqlCommand("SELECT matType, matColor, matSize, matCost FROM Material WHERE matId = '"+idMaterial+"' ", ConnectionToDb.Connection);
                SqlDataReader reader = command.ExecuteReader();

                // Получаем данные о материале
                while (reader.Read()) 
                {
                    material = new Material(reader["matType"].ToString(), reader["matColor"].ToString(), reader["matSize"].ToString(), Convert.ToDouble(reader["matCost"]), count);
                }

                reader.Close();
                ConnectionToDb.Close();
            }
            catch 
            {
                throw new Exception("Ошибка получения данных о материале");
            }

            return material;
        }

        public override string ToString()
        {
            return $"Тип: {type}\nЦвет: {color}\nРазмер: {size}\nСтоимость: {cost}\nКоличество: {count}";
        }

        /// <summary>
        /// Метод загрузки данных из базы данных
        /// </summary>
        /// <returns>Данные из базы данных</returns>
        public static DataTable LoadMaterial()
        {
            DataTable data = new DataTable();

            try
            {
                ConnectionToDb.Open();

                //Выполняем запрос на загрузку всех данных из бд
                const string SQLPROCEDURE = "selectMaterial";
                SqlCommand command = new SqlCommand(SQLPROCEDURE, ConnectionToDb.Connection);

                //Указываем,что команда является хранимой процедурой
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader dataReader = command.ExecuteReader();

                // Загружаем считанные данные в DataTable
                data.Load(dataReader);

                ConnectionToDb.Close();

            }
            catch
            {
                throw new Exception("Ошибка загрузки данных из базы данных");
            }

            return data;
        }

        /// <summary>
        /// Метод заполнения таблицы данными о материалах
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        /// <param name="materials">Массив материалов</param>
        public static void FillTableWithMaterials(DataGridView dataGridView, Material[] materials) 
        {
                      
            // Проходимся по массиву материалов
            for (int i = 0; i < materials.Length; i++)
            {

                // Создаём строку
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView);

                // Заполняем строку данными и добавляем в таблицу
                row.Cells[1].Value = materials[i].type;
                row.Cells[2].Value = materials[i].color;
                row.Cells[3].Value = materials[i].size;
                row.Cells[4].Value = materials[i].cost;
                row.Height = 50;
                dataGridView.Rows.Add(row);

            }
           
        }

        /// <summary>
        /// Метод заполнения таблицы данными о материалах
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        /// <param name="materials">Список материалов</param>
        public static void FillTableWithMaterials(DataGridView dataGridView, List<Material> materials) 
        {
            string type = "";
            string color = "";
            string size = "";   
            double cost = 0;

            try
            {
                ConnectionToDb.Open();

                for (int i = 0; i < materials.Count; i++)
                {
                    // Запрос на получение данных о материале
                    SqlCommand command = new SqlCommand("SELECT matType, matColor, matSize, matCost FROM material WHERE matId = '"+materials[i].Id+"'", ConnectionToDb.Connection);
                    SqlDataReader reader = command.ExecuteReader();

                    // Получаем данные о материалах
                    while (reader.Read()) 
                    {
                        type = reader["matType"].ToString();
                        color = reader["matColor"].ToString();
                        size = reader["matSize"].ToString();
                        cost = Convert.ToDouble(reader["matCost"]);
                    }

                    // Создаём строку
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dataGridView);

                    // Заполняем строку данными и добавляем в таблицу
                    row.Cells[1].Value = type;
                    row.Cells[2].Value = color;
                    row.Cells[3].Value = size;
                    row.Cells[4].Value = cost;
                    row.Cells[5].Value = materials[i].Count;
                    row.Height = 50;
                    dataGridView.Rows.Add(row);

                    reader.Close();
                }

                ConnectionToDb.Close();
            }
            catch
            {    
                throw new Exception("Ошибка заполнения таблицы данными о материалах");
            }
        
        }

        /// <summary>
        /// Метод получения массива выбранных материалов
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        /// <param name="indexes">Список индексов записей</param>
        /// <returns>Массив выбранных материалов</returns>
        public static Material[] GetArrayMaterials(DataGridView dataGridView, List<int> indexes)
        {
            int indexArray = 0;
            Material[] materials = new Material[indexes.Count];

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                // Если номер строки есть в списке индексов
                if (indexes.Contains(i))
                {
                    // Создаём материал и добавляем его в массив
                    Material material = new Material(dataGridView.Rows[i].Cells["Тип"].Value.ToString(), dataGridView.Rows[i].Cells["Цвет"].Value.ToString(), dataGridView.Rows[i].Cells["Размер"].Value.ToString(), Convert.ToDouble(dataGridView.Rows[i].Cells["Стоимость"].Value));
                    materials[indexArray++] = material;
                }
            }
            return materials;
        }

        /// <summary>
        /// Метод проверки существования записи в базе данных
        /// </summary>
        /// <returns>True,если существует, в противном случае - false</returns>
        public bool ExistMaterial(DataGridView dataGridView)
        {
            bool exist = false;
            try
            {
                if (dataGridView.Rows.Count == 0)
                {
                    return exist;
                }
                else
                {
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {

                        if (dataGridView.Rows[i].Cells["Тип"].Value.ToString() == type && dataGridView.Rows[i].Cells["Цвет"].Value.ToString() == color && dataGridView.Rows[i].Cells["Размер"].Value.ToString() == size && Convert.ToDouble(dataGridView.Rows[i].Cells["Стоимость"].Value) == cost)
                        {
                            exist = true;
                            break;
                        }
                    }
                }

            }
            catch
            {
                throw new Exception("Ошибка проверки записи");
            }

            return exist;
        }

        /// <summary>
        /// Метод получения id материала
        /// </summary>
        /// <returns>id материала</returns>
        public int GetIdMaterial()
        {
            int id = -1;
            try
            {
                ConnectionToDb.Open();

                // Составим запрос на получение id материала и выполним его
                SqlCommand command = new SqlCommand("SELECT matId FROM material WHERE matType = N'" + type + "' AND matColor = N'" + color + "' AND matSize = N'" + size + "' AND matCost = @cost", ConnectionToDb.Connection);
                command.Parameters.Add("@cost", SqlDbType.Float).Value = cost;
                id = Convert.ToInt32(command.ExecuteScalar());

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения id материала");
            }

            return id;
        }

        /// <summary>
        /// Метод добавления материала в базу данных
        /// </summary>
        /// <returns>Количество добавленных записей в базу данных</returns>
        public int AddMaterial()
        {
            int count = 0;
            try
            {
                ConnectionToDb.Open();

                // Создаём запрос на добавление данных и выполняем запрос
                SqlCommand command = new SqlCommand("INSERT INTO material (matType, matColor, matSize, matCost) VALUES (N'" + type + "', N'" + color + "', N'" + size + "', @cost) ", ConnectionToDb.Connection);
                command.Parameters.Add("@cost", SqlDbType.Float).Value = cost;
                count = command.ExecuteNonQuery();

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка добавления материала");
            }

            return count;

        }

        /// <summary>
        /// Метод удаления материала из базы данных
        /// </summary>
        /// <param name="materials">Массив материалов</param>
        /// <returns>Количество удалённых записей</returns>
        public static int DeleteMaterial(Material[] materials)
        {
            int count = 0;
            try
            {
                ConnectionToDb.Open();

                for (int i = 0; i < materials.Length; i++)
                {
                    // Создаём запрос на удаление записи из базы данных и выполняем запрос
                    SqlCommand command = new SqlCommand("DELETE FROM material WHERE matType = N'" + materials[i].type + "' AND matColor = N'" + materials[i].color + "' AND matSize = N'" + materials[i].size + "' AND matCost = @cost ", ConnectionToDb.Connection);
                    command.Parameters.Add("@cost", SqlDbType.Float).Value = materials[i].cost;
                    count += command.ExecuteNonQuery();

                }

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка удаления записи");
            }

            return count;
        }

        /// <summary>
        /// Метод изменения данных материала 
        /// </summary>
        /// <returns>Количество изменённых данных</returns>
        public int ChangeMaterial(int id)
        {
            int count = 0;
            try
            {
                ConnectionToDb.Open();

                // Создаём запрос на изменение данных и выполняем запрос
                SqlCommand command = new SqlCommand("UPDATE material SET matType = N'" + type + "', matColor = N'" + color + "', matSize = N'" + size + "', matCost = @cost WHERE matId = '" + id + "'", ConnectionToDb.Connection);
                command.Parameters.Add("@cost", SqlDbType.Float).Value = cost;
                count = command.ExecuteNonQuery();

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка изменения записи");
            }

            return count;
        }

        /// <summary>
        /// Метод получения количества уникальных записей
        /// </summary>
        /// <param name="columnNameInDb">Название столбца</param>
        /// <returns>Количество уникальных записей</returns>
        public static int GetCountUniqueRecords(string columnNameInDb)
        {
            int count = -1;
            try
            {
                ConnectionToDb.Open();

                // Формируем запрос на получение количества уникальных записей и возвращаем их
                string query = string.Format("SELECT COUNT(DISTINCT {0}) FROM material", columnNameInDb);
                SqlCommand command = new SqlCommand(query, ConnectionToDb.Connection);
                command.CommandType = CommandType.Text;
                count = Convert.ToInt32(command.ExecuteScalar());

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения количества строк");
            }

            return count;
        }

        /// <summary>
        /// Метод,возвращающий таблицу с определенным количеством строк по определенному порядку вывода
        /// </summary>
        /// <param name="columnName">Название столбца</param>
        /// <param name="order">Порядок вывода</param>
        /// <param name="countString">Количество строк</param>
        /// <returns>DataTable с отсортированными данными</returns>
        public static DataTable GetTableByOccurrence(string columnName, string order, int countString)
        {
            string nameColumnDb = "";
            DataTable table = new DataTable();

            try
            {
                ConnectionToDb.Open();

                // В зависимости от названия столбца
                switch (columnName)
                {
                    // Получаем соответствующие названия столбцов бд
                    case "Тип":
                        nameColumnDb = "matType";
                        break;
                    case "Цвет":
                        nameColumnDb = "matColor";
                        break;
                    case "Размер":
                        nameColumnDb = "matSize";
                        break;
                    case "Стоимость":
                        nameColumnDb = "matCost";
                        break;


                }

                // Формируем запрос на получение данных нужного столбца определенного количества и определенного порядка
                //string query = string.Format("select TOP {0} {1} AS N'{2}' FROM material GROUP BY {3} ORDER BY COUNT({4}) {5}", countString, nameColumnDb, columnName, nameColumnDb, nameColumnDb, order);
                string query = string.Format("select TOP {0} {1} AS N'{2}', COUNT({3}) AS N'Количество' FROM material GROUP BY {4} ORDER BY COUNT({5}) {6}", countString, nameColumnDb, columnName, nameColumnDb, nameColumnDb, nameColumnDb, order);
                SqlCommand command = new SqlCommand(query, ConnectionToDb.Connection);

                // Выполняем запрос и заполняем таблицу данными
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader();
                table.Load(dataReader);

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception(string.Format("Ошибка получения таблицы - {0}", columnName));
            }

            return table;
        }


        /// <summary>
        /// Метод получения id материала
        /// </summary>
        /// <param name="type">Тип материала</param>
        /// <param name="color">Цвет материала</param>
        /// <param name="size">Размер материала</param>
        /// <param name="cost">Стоимость материала</param>
        /// <returns>id материала</returns>
        public static int GetIdMaterial(string type, string color, string size, double cost) 
        {
            int id = -1;

            try
            {
                ConnectionToDb.Open();

                // Формируем запрос на получение id и получаем его
                SqlCommand command = new SqlCommand("SELECT matId FROM material WHERE matType = N'"+type+"' AND matColor = N'"+color+"' AND matSize = N'"+size+"' AND matCost = @cost", ConnectionToDb.Connection);
                command.Parameters.Add("@cost", SqlDbType.Float).Value = cost;
                id = Convert.ToInt32(command.ExecuteScalar());

                ConnectionToDb.Close();
            }
            catch 
            {
                throw new Exception("Ошибка получения уникального номера материала");
            }

            return id;

        }

        /// <summary>
        /// Метод получения массива id материалов
        /// </summary>
        /// <param name="dataGridView">Таблица с материалами</param>
        /// <param name="selectedRows">Список выбранных строк</param>
        /// <returns>Массив id материалов</returns>
        public static int[] GetArrayIdMaterials(DataGridView dataGridView, List<int> selectedRows)
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
                        // Получаем данные
                        string type = dataGridView.Rows[i].Cells["Тип"].Value.ToString();
                        string color = dataGridView.Rows[i].Cells["Цвет"].Value.ToString();
                        string size = dataGridView.Rows[i].Cells["Размер"].Value.ToString();
                        double cost = Convert.ToDouble(dataGridView.Rows[i].Cells["Стоимость"].Value);

                        // Получаем id и добавляем в массив
                        command = new SqlCommand("SELECT matId FROM material WHERE matType = N'" + type + "' AND matColor = N'" + color + "' AND matSize = N'" + size + "' AND matCost = @cost", ConnectionToDb.Connection);
                        command.Parameters.Add("@cost", SqlDbType.Float).Value = cost;
                        arrayId[indexArray++] = Convert.ToInt32(command.ExecuteScalar());
                    }
                }

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения массива идентификаторов записей о материалах");
            }

            return arrayId;
        }


        /// <summary>
        /// Метод, определяющий используется ли материал
        /// </summary>
        /// <param name="idMaterial">id материала</param>
        /// <returns>Используется ли материал</returns>
        public static bool MaterialIsUsed(int idMaterial)
        {
            bool isUsed = false;

            try
            {
                ConnectionToDb.Open();

                // Получаем количество заказов заказчика
                SqlCommand command = new SqlCommand("SELECT COUNT(fmatId) FROM productMaterial WHERE fmatId = '" + idMaterial + "'", ConnectionToDb.Connection);

                if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                    isUsed = true;

                ConnectionToDb.Close();
            }

            catch
            {
                throw new Exception("Ошибка получения данных о том, используется ли материал");
            }

            return isUsed;
        }


        /// <summary>
        /// Метод,определяющий используются ли материалы
        /// </summary>
        /// <param name="arrayIdMaterials">Массив id материалов</param>
        /// <returns>Используются ли материалы</returns>
        public static bool MaterialsAreUsed(int[] arrayIdMaterials)
        {
            bool areUsed = false;

            try
            {

                for (int i = 0; i < arrayIdMaterials.Length; i++)
                {
                    if (MaterialIsUsed(arrayIdMaterials[i]))
                    {
                        areUsed = true;
                        break;
                    }
                }

            }
            catch
            {
                throw new Exception("Ошибка получения данных о том, используются ли материалы");
            }


            return areUsed;
        }

        /// <summary>
        /// Метод, проверяющий,что все материалы из массива имеют одинаковый размер
        /// </summary>
        /// <param name="materials">Массив материалов</param>
        /// <returns>Все материалы их масства имеют одинаковый размер</returns>
        public static bool SameSizeMaterials(Material[] materials) 
        {
            if (materials.Length == 1)
                return true;
            else
            {
                // Получаем данные о материале
                string size = materials[0].size;

                // Сравниваем первый материал с остальными
                for (int i = 1; i < materials.Length; i++)
                {
                    if (materials[i].size != size)
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Метод, проверяющий есть ли в массиве материалы с одинаковым типом, цветом и размером
        /// </summary>
        /// <param name="materials">Массив материалов</param>
        /// <returns>Есть ли в массиве материалы с одинаковым типом, цветом и размером</returns>
        public static bool SameSizeColorTypeMaterial(Material[] materials) 
        {
            bool same = false;

            if (materials.Length == 1)
                return same;
            else
            {
                // Проходимся по массиву
                for (int i = 0; i < materials.Length - 1; i++)
                {
                    string type = materials[i].type;
                    string color = materials[i].color;
                    string size = materials[i].size;

                    for (int j = 1; j < materials.Length; j++)
                    {
                        // Если материалы имеют разный индекс
                        if (i != j)
                        {
                            // Если существуют материалы с одинаковым типом, цветом и размером
                            if (type == materials[j].type && color == materials[j].color && size == materials[j].size)
                            {
                                same = true;
                                goto exit;
                            }
                        }
                    }
                }
            }
            exit:
            return same;
        }

        /// <summary>
        /// Метод получения списка материалов
        /// </summary>
        /// <param name="dataGridView">Таблица с данными о материалах</param>
        /// <returns>Список материалов</returns>
        public static List<Material> GetListMaterials(DataGridView dataGridView) 
        {
            List<Material> materials = new List<Material>();

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                // Получаем id материала
                int id = GetIdMaterial(dataGridView.Rows[i].Cells["type"].Value.ToString(), dataGridView.Rows[i].Cells["color"].Value.ToString(), dataGridView.Rows[i].Cells["size"].Value.ToString(), Convert.ToDouble(dataGridView.Rows[i].Cells["cost"].Value));
                
                // Создаём материал и добавляем в список
                Material material = new Material(id, Convert.ToInt32(dataGridView.Rows[i].Cells["Count"].Value));
                materials.Add(material);
            }


            return materials;
        }

        /// <summary>
        /// Метод получения списка материалов
        /// </summary>
        /// <param name="idProduct">id печатной продукции</param>
        /// <returns>Список материалов</returns>
        public static List<Material> GetListMaterials(int idProduct) 
        {
            List<Material> materials = new List<Material>();

            try 
            {
                ConnectionToDb.Open();

                // Формируем запрос на получение материалов, их количества и выполняем его
                SqlCommand command = new SqlCommand("SELECT matCount, fmatId FROM productMaterial WHERE fprodId = '"+idProduct+"'", ConnectionToDb.Connection);
                SqlDataReader dataReader = command.ExecuteReader();

                // Заносим полученные данные в список
                while (dataReader.Read()) 
                {
                    int idMaterial = Convert.ToInt32(dataReader["fmatId"]);
                    int count = Convert.ToInt32(dataReader["matCount"]);
                    materials.Add(new Material(idMaterial, count));
                }

                ConnectionToDb.Close();
            }
            catch 
            {
                throw new Exception("Ошибка получения списка материалов");
            }

            return materials;
        }
    }
}

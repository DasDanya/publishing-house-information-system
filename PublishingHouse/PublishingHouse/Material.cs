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

        /// <summary>
        /// Конструктор для заполнения определенного поля
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="field">Поле</param>
        public Material(string value, string field) 
        {
            if (field == "type")
                type = value;
            if (field == "color")
                color = value;
            if (field == "size")
                size = value;
        }

        
        public Material(string type, string color, string size, double cost)
        {
            this.type = type;
            this.color = color;
            this.size = size;
            this.cost = Math.Round(cost,2);
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
                SqlCommand command = new SqlCommand("SELECT matId FROM material WHERE matType = N'"+ type + "' AND matColor = N'"+ color +"' AND matSize = N'"+ size +"' AND matCost = @cost", ConnectionToDb.Connection);
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
                SqlCommand command = new SqlCommand("INSERT INTO material (matType, matColor, matSize, matCost) VALUES (N'" + type + "', N'" + color + "', '" + size + "', @cost) ", ConnectionToDb.Connection);
                command.Parameters.Add("@cost", SqlDbType.Float).Value = cost;
                count = command.ExecuteNonQuery();

                ConnectionToDb.Close();
            }
            catch 
            {
                throw new Exception("Ошибка добавления записи");
            }

            return count;

        }

        /// <summary>
        /// Метод удаления материала материала из базы данных
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
                    SqlCommand command = new SqlCommand("DELETE FROM material WHERE matType = N'" + materials[i].type + "' AND matColor = N'" + materials[i].color + "' AND matSize = '" + materials[i].size + "' AND matCost = @cost ", ConnectionToDb.Connection);
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
                SqlCommand command = new SqlCommand("UPDATE material SET matType = N'"+ type +"', matColor = N'"+ color +"', matSize = N'"+ size +"', matCost = @cost WHERE matId = '"+ id +"'", ConnectionToDb.Connection);
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
        /// Метод получения списка популярных данных определенного столбца
        /// </summary>
        /// <param name="columnName">Столбец</param>
        /// <returns>Список популярных данных</returns>
        public static List<Material> PopularDataAboutMaterial(string columnName) 
        {
            string nameColumnDb = "";
            List<Material> popularData = new List<Material>();

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

                }

                // Создаём запрос на получение популярных данных и получаем их 
                SqlCommand command = new SqlCommand("select '"+nameColumnDb+"', COUNT('"+nameColumnDb+"') FROM material GROUP BY '"+nameColumnDb+"' ORDER BY '"+nameColumnDb+"' LIMIT 1", ConnectionToDb.Connection);
                SqlDataReader reader = command.ExecuteReader();

                // Считываем данные из ридера и записываем в список
                while (reader.Read()) 
                {
                    // Создаём материал и добавляем его в список популярных
                    Material material = new Material((string)reader["'" + nameColumnDb + "'"], columnName);
                    popularData.Add(material);
                }

            }
            catch 
            {
                throw new Exception(string.Format("Ошибка получения данных столбца {0}", columnName));
            }

            return popularData;
        }

    }
}

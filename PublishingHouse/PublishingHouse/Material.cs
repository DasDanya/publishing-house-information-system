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
      

        public Material(string type, string color, string size, double cost)
        {
            this.type = type;
            this.color = color;
            this.size = size;
            this.cost = Math.Round(cost,2);
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
        /// Метод загрузки данных из базы данных
        /// </summary>
        /// <returns>Данные из базы данных</returns>
        public static DataTable LoadMaterial() 
        {
            DataTable data = new DataTable();

            try
            {
                ConnectionToDb.Open();

                // Выполняем запрос на загрузку всех данных из бд
                const string SQLPROCEDURE = "selectMaterial";
                SqlCommand command = new SqlCommand(SQLPROCEDURE, ConnectionToDb.Connection);

               // Указываем,что команда является хранимой процедурой 
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
                        if (dataGridView.Rows[i].Cells["Тип"].Value.ToString() == type && dataGridView.Rows[i].Cells["Цвет"].Value.ToString() == color && dataGridView.Rows[i].Cells["Размер в мм"].Value.ToString() == size && Convert.ToDouble(dataGridView.Rows[i].Cells["Стоимость в ₽"].Value) == cost) 
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
                    Material material = new Material(dataGridView.Rows[i].Cells["Тип"].Value.ToString(), dataGridView.Rows[i].Cells["Цвет"].Value.ToString(), dataGridView.Rows[i].Cells["Размер в мм"].Value.ToString(), Convert.ToDouble(dataGridView.Rows[i].Cells["Стоимость в ₽"].Value));
                    materials[indexArray++] = material;
                }
            }
            return materials;
        }
    }
}

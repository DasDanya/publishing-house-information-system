using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;

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
                throw new Exception();
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
                SqlCommand command = new SqlCommand("SELECT matType AS N'Тип', matColor AS N'Цвет', matSize AS N'Размер в мм', matCost AS N'Стоимость в ₽' FROM material ORDER BY matType",ConnectionToDb.Connection);
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader();

                // Загружаем считанные данные в DataTable
                data.Load(dataReader);

                ConnectionToDb.Close();

            }
            catch 
            {
                throw new Exception();
            }

            return data;
        }
    }
}

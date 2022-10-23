using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace PublishingHouse
{
    /// <summary>
    /// Класс для работы со строками DataGridView
    /// </summary>
    public static class WorkWithRows
    {
       /// <summary>
       /// Метод подсчёта выбранных строк
       /// </summary>
       /// <param name="dataGridView">Таблица</param>
       /// <returns>Количество выбранных строк</returns>
        public static int CountSelectedRows(DataGridView dataGridView)
        {
            int count = 0;

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                // Если строка выбрана -> увеличиваем значение переменной количества выбранных строк
                if (Convert.ToBoolean(dataGridView.Rows[i].Cells["Select"].Value))
                    count++;
            }

            return count;
        }

        /// <summary>
        /// Метод, возвращающий номер выбранной строки 
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        /// <returns>Номер выбранной строки в DataGridView</returns>
        public static int NumberSelectedRows(DataGridView dataGridView) 
        {
            int number = -1;

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                // Если строка выбрана -> Получаем её порядковый номер
                if (Convert.ToBoolean(dataGridView.Rows[i].Cells["Select"].Value))
                    number = i;
            }
            return number;
            
        }

        /// <summary>
        /// Метод, возвращающий список выбранных индексы выбранных строк
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        /// <returns>Список индексов выбранных строк</returns>
        public static List<int> GetListIndexesSelectedRows(DataGridView dataGridView) 
        {
            List<int> indexes = new List<int>();

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                // Если строка выбрана пользователем -> Добавляем её в список 
                if (Convert.ToBoolean(dataGridView.Rows[i].Cells["Select"].Value))
                    indexes.Add(i);
            }
            return indexes;
        }

        public static void SetHeightRows(DataGridView dataGridView) 
        {
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                // Получаем строку и задаём высоту
                DataGridViewRow row = dataGridView.Rows[i];
                row.Height = 45;
            }
        }
    }
}

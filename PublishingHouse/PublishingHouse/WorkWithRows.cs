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
       /// Метод подсчёта выбранных строк в DataGridView
       /// </summary>
       /// <param name="dataGridView">Таблица</param>
       /// <returns>Количество выбранных строк</returns>
        public static int CountSelectedRows(DataGridView dataGridView)
        {
            int count = 0;

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView.Rows[i].Cells["Select"].Value))
                    count++;
            }

            return count;
        }

        /// <summary>
        /// Метод, возвращающий номер выбранной строки в DataGridView
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        /// <returns>Номер выбранной строки в DataGridView</returns>
        public static int NumberSelectedRows(DataGridView dataGridView) 
        {
            int number = -1;

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView.Rows[i].Cells["Select"].Value))
                    number = i;
            }
            return number;
            
        }
        
    }
}

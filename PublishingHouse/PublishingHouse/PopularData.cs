using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PublishingHouse
{
    /// <summary>
    /// Класс для работы с популярными данными
    /// </summary>
    public static class PopularData
    {
        /// <summary>
        /// Метод вывода популярных данных
        /// </summary>
        /// <param name="labels">Список полей для заполнения</param>
        /// <param name="popularData">Список популярных данных</param>
        public static void GetPopularData(List<Label> labels, List<string> popularData) 
        {
            // Если отсутствуют популярные данные
            if (popularData.Count == 0)
                return;
            // Выводим популярные данные
            else
            {
                for (int i = 0; i < popularData.Count; i++)
                {                 
                    labels[i].Text = string.Format("{0}. {1}", i + 1, popularData[i]);
                }
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace PublishingHouse
{
    /// <summary>
    /// Класс для работы с данными DataGridView
    /// </summary>
    public static class WorkWithDataDgv
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
        /// Метод, возвращающий список индексов выбранных строк
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

        //public static void SetHeightRows(DataGridView dataGridView)
        //{
        //    for (int i = 0; i < dataGridView.Rows.Count; i++)
        //    {
        //        // Получаем строку и задаём высоту
        //        DataGridViewRow row = dataGridView.Rows[i];
        //        row.Height = 45;
        //    }
        //}

        /// <summary>
        /// Метод, возвращаюший ComboBox столбцов для поиска данных
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        /// <returns>ComboBox столбцов для поиска данных</returns>
        private static void SetRowOfColumnsIntoComboBox(DataGridView dataGridView, ComboBox comboBox) 
        {

            comboBox.Items.Clear();

            // Если DataGridView пустой
            if (dataGridView.Rows.Count < 1)
            {
                comboBox.Items.Add("Отсутствуют данные для поиска");
            }

            else
            {
                // Проходим каждый столбец
                for (int i = 1; i < dataGridView.Columns.Count; i++)
                {
                    // Если данные в этом столбце имеют строковой тип данных
                    if (dataGridView.Rows[0].Cells[i].Value.GetType() == typeof(string)) 
                    {
                        // Добавляем имя этого столбца в ComboBox
                        comboBox.Items.Add(dataGridView.Columns[i].Name);
                    }
                }
            }

          
        }

       
        /// <summary>
        /// Метод, выводящий строки, удовлетворяющие запросу пользователя
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        /// <param name="comboBox">Список столбцов</param>
        /// <param name="textBox">Поле,хранящее запрос пользователя</param>
        public static void GetLikeString(DataGridView dataGridView, ComboBox comboBox, TextBox textBox) 
        {
            (dataGridView.DataSource as DataTable).DefaultView.RowFilter = String.Format("[{0}] LIKE '%{1}%'", comboBox.Text, textBox.Text);
        }

        /// <summary>
        /// Метод поиска данных по диапазону
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        /// <param name="column">Столбец</param>
        /// <param name="from">Левое пороговое значение</param>
        /// <param name="to">Правое пороговое значение</param>
        public static void SearchByDifference(DataGridView dataGridView, string column, double from, double to) 
        {

            (dataGridView.DataSource as DataTable).DefaultView.RowFilter = "["+column+"] >= '" + from.ToString() + "' AND ["+column+"] <= '" + to.ToString() + "'";
        }

        /// <summary>
        /// Метод поиска данных по диапазону
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        /// <param name="column">Столбец</param>
        /// <param name="from">Левое пороговое значение</param>
        /// <param name="to">Правое пороговое значение</param>
        public static void SearchByDifference(DataGridView dataGridView, string column, DateTime from, DateTime to)
        {

            (dataGridView.DataSource as DataTable).DefaultView.RowFilter = "[" + column + "] >= '" + from.ToString() + "' AND [" + column + "] <= '" + to.ToString() + "'";
        }

        /// <summary>
        /// Сброс поиска данных
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        public static void ResetSearch(DataGridView dataGridView) 
        {
            (dataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
        }

        /// <summary>
        /// Метод установки элементов для поиска строковых данных
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        /// <param name="comboBox">Список столбцов</param>
        /// <param name="textBox">Поле для поиска</param>
        public static void SetElementsForSearchStringData(DataGridView dataGridView, ComboBox comboBox,TextBox textBox) 
        {
            // Устанавливаем список столбцов
            SetRowOfColumnsIntoComboBox(dataGridView, comboBox);
            comboBox.SelectedIndex = 0;

            // Если таблица пустая
            if (dataGridView.Rows.Count < 1)
                textBox.Enabled = false;
            else
                textBox.Enabled = true;    
        }

        /// <summary>
        /// Метод, который устанавливает или сбрасывает выбор строк
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        /// <param name="select">True - установка, False - сброс</param>
        public static void SelectOrCancelSelectAllRows(DataGridView dataGridView, bool select) 
        {
            if (dataGridView.Rows.Count < 1)
                return;
            else 
            {
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                   dataGridView.Rows[i].Cells["Select"].Value = select;
                }    
            }
        }

        /// <summary>
        /// Метод,возвращающий порядок фильтрации 
        /// </summary>
        /// <param name="desc">RadioButton "По убыванию"</param>
        /// <param name="asc">RadioButton "По возрастанию"</param>
        /// <returns>Порядок фильтрации</returns>
        public static string GetOrderFilter(RadioButton desc, RadioButton asc)
        {
            string order = "";
            if (desc.Checked)
                order = "DESC";
            else if (asc.Checked)
                order = "ASC";

            return order;
        }

        /// <summary>
        /// Метод, устанавливающий для столбцов нужное значение свойства ReadOnly
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        public static void SetReadOnlyColumns(DataGridView dataGridView) 
        {
            dataGridView.Columns[0].ReadOnly = false;

            for (int i = 1; i < dataGridView.Columns.Count; i++)
            {
                dataGridView.Columns[i].ReadOnly = true;
            }
        
        }
    }
}

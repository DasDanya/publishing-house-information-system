﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PublishingHouse
{
    public partial class OccurrenceMaterialData : Form
    {
        public OccurrenceMaterialData()
        {
            InitializeComponent();
        }


        private void PopularMaterialData_Load(object sender, EventArgs e)
        {
            //Загружаем иконки для вкладок
            IconImage.LoadIconBackTab(backTab);

            // Заполняем таблицы
            FillingTable(typeDataGridView, "Тип", "DESC", Material.GetCountUniqueRecords("matType"));
            FillingTable(colorDataGridView, "Цвет", "DESC", Material.GetCountUniqueRecords("matColor"));
            FillingTable(sizeDataGridView, "Размер", "DESC", Material.GetCountUniqueRecords("matSize"));

            // Делаем radioButton выбранными
            ButtonIsChecked();
    
        }

        private void backTab_Click(object sender, EventArgs e)
        {
            // Переход к меню материалов
            MaterialMenu materialMenu = new MaterialMenu();
            Transition.TransitionByForms(this, materialMenu);
        }

        private void PopularMaterialData_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        
        /// <summary>
        /// Заполняем таблицу согласно пользовательскому запросу
        /// </summary>
        /// <param name="countTextBox">Поле, в которое записано количество строк</param>
        /// <param name="dataGridView">Таблица</param>
        /// <param name="descRadioButton">RadioButton "По убыванию"</param>
        /// <param name="ascRadioButton">RadioButton "По возврастанию"</param>
        /// <param name="columnName">Имя столбца в таблице</param>
        /// <param name="columnNameInDb">Имя столбца в бд</param>
        private void OutputTableByUserQuery(TextBox countTextBox, DataGridView dataGridView, RadioButton descRadioButton, RadioButton ascRadioButton, string columnName, string columnNameInDb) 
        {
            try
            {
                // Получаем общее количество строк и количество,введенное пользователем
                int count = Material.GetCountUniqueRecords(columnNameInDb);
                int inputCount = int.Parse(countTextBox.Text);

                if (inputCount > count || inputCount < 1)
                    MessageBox.Show(string.Format("Необходимо ввести количество строк, не превышая максимальное значение: {0}. Количество выводимых строк должно быть больше нуля", count), "Получение данных", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    // Получаем таблицу и выводим её
                    FillingTable(dataGridView, columnName, GetOrderFilter(descRadioButton, ascRadioButton), inputCount);
                    MessageBox.Show("Данные изменены", "Получение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Некорректный ввод данных", "Получение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод заполнения таблицы
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        /// <param name="columnName">Столбец</param>
        /// <param name="order">Порядок сортировки</param>
        /// <param name="count">Количество выводимых строк</param>
        private void FillingTable(DataGridView dataGridView, string columnName, string order, int count) 
        {
            try
            {
                // Заполняем таблицы полностью по убыванию повторяемости
                dataGridView.DataSource = Material.GetTableByOccurrence(columnName, order, count);

                // Устанавливаем ширину столбца и делаем первую строку без выделения
                dataGridView.Columns[0].Width = 310;
                dataGridView.ClearSelection();
            }
            catch 
            {
                throw new Exception("Ошибка загрузки таблицы");
            }
        }

        /// <summary>
        /// Метод,делающий radioButton выбранным
        /// </summary>
        private void ButtonIsChecked() 
        {
            descTypeRadioButton.Checked = true;
            descColorRadioButton.Checked = true;
            descSizeRadioButton.Checked = true;
        }

        /// <summary>
        /// Метод,возвращающий порядок фильтрации 
        /// </summary>
        /// <param name="desc">RadioButton "По убыванию"</param>
        /// <param name="asc">RadioButton "По возрастанию"</param>
        /// <returns>Порядок фильтрации</returns>
        private string GetOrderFilter(RadioButton desc, RadioButton asc) 
        {
            string order = "";
            if (desc.Checked)
                order = "DESC";
            else if (asc.Checked)
                order = "ASC";

            return order;
        }

        private void getTypesButton_Click(object sender, EventArgs e)
        {
            OutputTableByUserQuery(countTypeTextBox, typeDataGridView, descTypeRadioButton, ascTypeRadioButton, "Тип", "matType");
        }

        private void getColorsButton_Click(object sender, EventArgs e)
        {
            OutputTableByUserQuery(countColorTextBox, colorDataGridView, descColorRadioButton, ascColorRadioButton, "Цвет", "matColor");
        }

        private void getSizesButton_Click(object sender, EventArgs e)
        {
            OutputTableByUserQuery(countSizeTextBox, sizeDataGridView, descSizeRadioButton, ascSizeRadioButton, "Размер", "matSize");
        }



        //private void FillingTable(DataGridView dataGridView, string columnName, string order) 
        //{            
        //    //if (int.Parse(countTypeTextBox.Text) > count)
        //    //    MessageBox.Show(string.Format("Необходимо ввести количество строк, не превышая максимальное значение: {0}", count), "Получение типов материалов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    //else
        //        dataGridView.DataSource = Material.GetTableByOccurrence(columnName, order, count);
        //}
    }
}
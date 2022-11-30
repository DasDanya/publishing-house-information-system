using System;
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


            // Заполняем таблицы
            FillingTable(typeDataGridView, "Тип", "DESC", Material.GetCountUniqueRecords("matType"));
            FillingTable(colorDataGridView, "Цвет", "DESC", Material.GetCountUniqueRecords("matColor"));
            FillingTable(sizeDataGridView, "Размер", "DESC", Material.GetCountUniqueRecords("matSize"));
            FillingTable(costDataGridView, "Стоимость", "DESC", Material.GetCountUniqueRecords("matCost"));

            // Делаем radioButton выбранными
            ButtonIsChecked();
    
        }

        private void backTab_Click(object sender, EventArgs e)
        {
            // Переход в меню материалов
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
                    FillingTable(dataGridView, columnName, WorkWithDataDgv.GetOrderFilter(descRadioButton, ascRadioButton), inputCount);
                    MessageBox.Show("Запрос успешно выполнен!", "Получение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка получения данных. Убедитесь, что вы заполнили нужные текстовые поля, и повторите попытку", "Получение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Заполняем таблицу полностью по определенному порядку
                dataGridView.DataSource = Material.GetTableByOccurrence(columnName, order, count);

                // Устанавливаем ширину столбцов и делаем первую строку без выделения
                dataGridView.Columns[0].Width = 200;
                dataGridView.Columns[1].Width = 110;
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
            descCostRadioButton.Checked = true;
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

        private void getCostsButton_Click(object sender, EventArgs e)
        {
            OutputTableByUserQuery(countCostTextBox, costDataGridView, descCostRadioButton, ascCostRadioButton, "Стоимость", "matCost");
        }

        private void DataGridView_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Получаем символ, который ввёл пользователь
            char number = e.KeyChar;

            // Если пользователь ввёл не цифру и не нажал на Backspace, то не отображаем символ в textbox
            if (!Char.IsDigit(number) && number != 8)
                e.Handled = true;
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

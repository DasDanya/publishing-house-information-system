using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PublishingHouse
{
    public partial class FashionDataPrHouseMenu : Form
    {
        public FashionDataPrHouseMenu()
        {
            InitializeComponent();
        }

        private void FashionDataPrHouseMenu_Load(object sender, EventArgs e)
        {
            try
            {
                // Выводим все типографии по убыванию их использования и делаем RadioButton для сортировки по убыванию выбранным
                descRadioButton.Checked = true;
                FillTable("DESC", PrintingHouse.GetCountRecords());
            }
            catch 
            {
                MessageBox.Show("Ошибка загрузки моды данных о типографиях", "Загрузка моды данных о типографиях", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backTab_Click(object sender, EventArgs e)
        {
            // Переход в меню типографий
            PrintingHouseMenu printingHouseMenu = new PrintingHouseMenu();
            Transition.TransitionByForms(this, printingHouseMenu);
        }

        private void FashionDataPrHouseMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void getPrHouseButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем количество записей для поиска и общее количество записей
                int count = PrintingHouse.GetCountRecords();
                int inputCount = int.Parse(countTextBox.Text);

                if (inputCount < 1 || inputCount > count)
                    MessageBox.Show(String.Format("Количество отображаемых записей должно быть больше нуля и не больше максимального значения: {0}", count), "Получение типографий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else 
                {
                    FillTable(WorkWithDataDgv.GetOrderFilter(descRadioButton, ascRadioButton), inputCount);
                    MessageBox.Show("Запрос успешно выполнен!", "Получение типографий", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка получения типографий. Убедитесь, что вы заполнили нужные текстовые поля, и повторите попытку", "Получение типографий", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод заполнения таблицы
        /// </summary>
        /// <param name="order">Порядок сортировки</param>
        /// <param name="outCount">Количество выводимых строк</param>
        private void FillTable(string order, int outCount)
        {
            try
            {
                // Заполняем таблицу полностью по определенному порядку
                fashionPrHouseDataGridView.DataSource = PrintingHouse.GetTableByOccurrence(order, outCount);

                // Устанавливаем ширину столбцов и делаем первую строку без выделения
                fashionPrHouseDataGridView.Columns[0].Width = 300;
                fashionPrHouseDataGridView.Columns[1].Width = 140;
                fashionPrHouseDataGridView.ClearSelection();
            }

            catch
            {
                throw new Exception("Ошибка загрузки таблицы");
            }
        }

        private void countTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Получаем символ, который ввёл пользователь
            char number = e.KeyChar;

            // Если пользователь ввёл не цифру и не нажал на Backspace, то не отображаем символ в textbox
            if (!Char.IsDigit(number) && number != 8)
                e.Handled = true;
        }

        private void fashionPrHouseDataGridView_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}

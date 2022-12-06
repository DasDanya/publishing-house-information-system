using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PublishingHouse
{
    public partial class FashionCustomersMenu : Form
    {
        public FashionCustomersMenu()
        {
            InitializeComponent();
        }

        private void FashionCustomersMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void backTab_Click(object sender, EventArgs e)
        {
            CustomersMenu customersMenu = new CustomersMenu();
            Transition.TransitionByForms(this, customersMenu);
        }

        private void fashionCustomersDataGridView_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void countTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Получаем символ, который ввёл пользователь
            char number = e.KeyChar;

            // Если пользователь ввёл не цифру и не нажал на Backspace, то не отображаем символ в textbox
            if (!Char.IsDigit(number) && number != 8)
                e.Handled = true;
        }

        private void FashionCustomersMenu_Load(object sender, EventArgs e)
        {
            try
            {
                // Выводим всех заказчиков по убыванию количества заказов и делаем RadioButton для сортировки по убыванию выбранным
                descRadioButton.Checked = true;
                FillTable("DESC", Customer.GetCountRecords());
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки моды данных о заказчиках", "Загрузка моды данных о заказчиках", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getCustomersButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем количество записей для поиска и общее количество записей
                int count = Customer.GetCountRecords();
                int inputCount = int.Parse(countTextBox.Text);

                if (inputCount < 1 || inputCount > count)
                    MessageBox.Show(String.Format("Количество отображаемых записей должно быть больше нуля и не больше максимального значения: {0}", count), "Получение заказчиков", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    FillTable(WorkWithDataDgv.GetOrderFilter(descRadioButton, ascRadioButton), inputCount);
                    MessageBox.Show("Запрос успешно выполнен!", "Получение заказчиков", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка получения заказчиков. Убедитесь, что вы заполнили нужные текстовые поля, и повторите попытку", "Получение заказчиков", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                fashionCustomersDataGridView.DataSource = Customer.GetTableByOccurrence(order, outCount);

                // Устанавливаем ширину столбцов и делаем первую строку без выделения
                fashionCustomersDataGridView.Columns[0].Width = 180;
                fashionCustomersDataGridView.Columns[1].Width = 180;
                fashionCustomersDataGridView.Columns[2].Width = 150;
                fashionCustomersDataGridView.ClearSelection();
            }

            catch
            {
                throw new Exception("Ошибка загрузки таблицы");
            }
        }
    }
}

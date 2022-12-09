using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PublishingHouse
{
    public partial class FashionTypeProductMenu : Form
    {
        public FashionTypeProductMenu()
        {
            InitializeComponent();
        }

        private void backTab_Click(object sender, EventArgs e)
        {
            TypesProductMenu typesProductMenu = new TypesProductMenu();
            Transition.TransitionByForms(this, typesProductMenu);
        }

        private void FashionTypeProductMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void FashionTypeProductMenu_Load(object sender, EventArgs e)
        {
            try
            {
                // Выводим все типы печатной продукции по убыванию количества указаний и делаем RadioButton для сортировки по убыванию выбранным
                descRadioButton.Checked = true;
                FillTable("DESC", TypeProduct.GetCountRecords());
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки моды данных о типах печатной продукции", "Загрузка моды данных о типах печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void fashionTypeProductDataGridView_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
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
                fashionTypeProductDataGridView.DataSource = TypeProduct.GetTableByOccurrence(order, outCount);

                // Устанавливаем ширину столбцов и делаем первую строку без выделения
                fashionTypeProductDataGridView.Columns[0].Width = 300;
                fashionTypeProductDataGridView.Columns[2].Width = 170;
                fashionTypeProductDataGridView.ClearSelection();
            }

            catch
            {
                throw new Exception("Ошибка загрузки таблицы");
            }
        }

        private void getTypeProductButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем количество записей для поиска и общее количество записей
                int count = TypeProduct.GetCountRecords();
                int inputCount = int.Parse(countTextBox.Text);

                if (inputCount < 1 || inputCount > count)
                    MessageBox.Show(String.Format("Количество отображаемых записей должно быть больше нуля и не больше максимального значения: {0}", count), "Получение типов печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    FillTable(WorkWithDataDgv.GetOrderFilter(descRadioButton, ascRadioButton), inputCount);
                    MessageBox.Show("Запрос успешно выполнен!", "Получение типов печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка получения типов печатной продукции. Убедитесь, что вы заполнили нужные текстовые поля, и повторите попытку", "Получение типов печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

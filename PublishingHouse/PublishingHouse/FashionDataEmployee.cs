using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PublishingHouse
{
    public partial class FashionDataEmployee : Form
    {
        public FashionDataEmployee()
        {
            InitializeComponent();
        }

        private void FashionDataEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void backTab_Click(object sender, EventArgs e)
        {
            EmployeeMenu adminMenu = new EmployeeMenu();
            Transition.TransitionByForms(this, adminMenu);
        }

        private void FashionDataEmployee_Load(object sender, EventArgs e)
        {
            try
            {
                // Выводим всех сотрудников по убыванию количества выполняемых заказов и делаем RadioButton для сортировки по убыванию выбранным
                descRadioButton.Checked = true;
                FillTable("DESC", Employee.GetCountRecords());
            }
            catch 
            {
                MessageBox.Show("Ошибка загрузки моды данных о сотрудниках", "Загрузка моды данных о сотрудниках", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void getEmployeesButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем количество записей для поиска и общее количество записей
                int count = Employee.GetCountRecords();
                int inputCount = int.Parse(countTextBox.Text);

                if (inputCount < 1 || inputCount > count)
                    MessageBox.Show(String.Format("Количество отображаемых записей должно быть больше нуля и не больше максимального значения: {0}", count), "Получение сотрудников", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    FillTable(WorkWithDataDgv.GetOrderFilter(descRadioButton, ascRadioButton), inputCount);
                    MessageBox.Show("Запрос успешно выполнен!", "Получение сотрудников", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка получения сотрудников. Убедитесь, что вы заполнили нужные текстовые поля, и повторите попытку", "Получение сотрудников", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                fashionEmployeesDataGridView.DataSource = Employee.GetTableByOccurrence(order, outCount);

                // Устанавливаем ширину столбцов и делаем первую строку без выделения
                fashionEmployeesDataGridView.Columns[3].Width = 180;
                fashionEmployeesDataGridView.ClearSelection();
            }

            catch
            {               
                throw new Exception("Ошибка загрузки таблицы");
            }
        }

        private void fashionEmployeesDataGridView_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}

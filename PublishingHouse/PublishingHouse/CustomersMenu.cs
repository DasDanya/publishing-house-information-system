using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PublishingHouse
{
    public partial class CustomersMenu : Form
    {

        Customer customer = null;
        char state = ' ';
        int id = -1;

        public CustomersMenu()
        {
            InitializeComponent();
        }

        public CustomersMenu(Customer customer, char state) 
        {
            InitializeComponent();
            this.customer = customer;
            this.state = state;
        }

        private void backTab_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            Transition.TransitionByForms(this, mainMenu);
        }

        private void CustomersMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void processingTab_Click(object sender, EventArgs e)
        {
            inputDataButton.Visible = true;
            addButton.Visible = true;
            selectForChangeButton.Visible = true;
            resetAddOrChangeButton.Visible = true;
            deleteButton.Visible = true;
            changeButton.Visible = true;
            selectAllRowsButton.Visible = false;
            resetSelectRowsButton.Visible = false;
            ordersTreeView.Visible = false;
            fashionCustomersButton.Visible = false;
            getOrdersButton.Visible = false;
            columnLabel.Visible = false;
            columnsComboBox.Visible = false;
            dataAboutCustomerLabel.Visible = false;
            searchTextBox.Visible = false;
            addCustomerLabel.Visible = true;
            changeCustomerLabel.Visible = true;
        }

        private void searchTab_Click(object sender, EventArgs e)
        {
            inputDataButton.Visible = false;
            addButton.Visible = false;
            selectForChangeButton.Visible = false;
            resetAddOrChangeButton.Visible = false;
            deleteButton.Visible = false;
            changeButton.Visible = false;
            selectAllRowsButton.Visible = false;
            resetSelectRowsButton.Visible = false;
            ordersTreeView.Visible = true;
            fashionCustomersButton.Visible = true;
            getOrdersButton.Visible = true;
            columnLabel.Visible = true;
            columnsComboBox.Visible = true;
            dataAboutCustomerLabel.Visible = true;
            searchTextBox.Visible = true;
            addCustomerLabel.Visible = false;
            changeCustomerLabel.Visible = false;

            // Устанавливаем значения и свойства полям для поиска
            WorkWithDataDgv.SetElementsForSearchStringData(customersDataGridView, columnsComboBox, searchTextBox);
        }

        private void selectTab_Click(object sender, EventArgs e)
        {
            inputDataButton.Visible = false;
            addButton.Visible = false;
            selectForChangeButton.Visible = false;
            resetAddOrChangeButton.Visible = false;
            deleteButton.Visible = false;
            changeButton.Visible = false;
            selectAllRowsButton.Visible = true;
            resetSelectRowsButton.Visible = true;
            ordersTreeView.Visible = false;
            fashionCustomersButton.Visible = false;
            getOrdersButton.Visible = false;
            columnLabel.Visible = false;
            columnsComboBox.Visible = false;
            dataAboutCustomerLabel.Visible = false;
            searchTextBox.Visible = false;
            addCustomerLabel.Visible = false;
            changeCustomerLabel.Visible = false;
        }

        /// <summary>
        /// Метод,который приводит компоненты и переменные в состояние по умолчанию
        /// </summary>
        private void DefaultStateOfMenu()
        {
            ClearBuffer();
            addCustomerLabel.Text = "";
            changeCustomerLabel.Text = "";
            addButton.Enabled = true;
            deleteButton.Enabled = true;
            changeButton.Enabled = false;

        }

        /// <summary>
        /// Метод очистки значений для буфферных переменных
        /// </summary>
        private void ClearBuffer()
        {
            customer = null;
            state = ' ';
            id = -1;
        }

        /// <summary>
        /// Метод вывода новых данных из бд
        /// </summary>
        private void ReloadData()
        {
            // Удаляем все строки из таблицы
            while (customersDataGridView.Rows.Count != 0)
            {
                customersDataGridView.Rows.Remove(customersDataGridView.Rows[customersDataGridView.Rows.Count - 1]);
            }

            // Загружаем новые данные
            LoadTable();

        }

        private void selectForChangeButton_Click(object sender, EventArgs e)
        {

        }

        private void resetAddOrChangeButton_Click(object sender, EventArgs e)
        {
            // Приводим буфферные данные и компоненты в состояние по умолчанию
            DefaultStateOfMenu();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }

        private void changeButton_Click(object sender, EventArgs e)
        {

        }

        private void selectAllRowsButton_Click(object sender, EventArgs e)
        {
            if (customersDataGridView.Rows.Count < 1)
                MessageBox.Show("Отсутствуют строки для выбора", "Выбрать всё", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                WorkWithDataDgv.SelectOrCancelSelectAllRows(customersDataGridView, true);
        }

        private void resetSelectRowsButton_Click(object sender, EventArgs e)
        {
            if (customersDataGridView.Rows.Count < 1)
                MessageBox.Show("Отсутствуют строки", "Отменить выбор строк", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                WorkWithDataDgv.SelectOrCancelSelectAllRows(customersDataGridView, false);
        }

        private void inputDataButton_Click(object sender, EventArgs e)
        {
            // Переходим в меню для ввода данных
            FillDataCustomerMenu fillDataCustomerMenu = new FillDataCustomerMenu('A');
            Transition.TransitionByForms(this, fillDataCustomerMenu);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (customer == null || state != 'A')
                    MessageBox.Show("Перед добавлением заказчика необходимо ввести данные о нём", "Добавление заказчика", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    if (customer.AddCustomer() == 1)
                    {
                        MessageBox.Show("Запись успешно добавлена!", "Добавление заказчика", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Выводим новые данные и делаем комноненты и переменные в состояние по умолчанию
                        ReloadData();
                        DefaultStateOfMenu();
                       

                    }
                    else
                        MessageBox.Show("Количество добавленных записей не равно единице", "Добавление заказчика", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch
            {
                MessageBox.Show("Ошибка добавления заказчика", "Добавление заказчика", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getOrdersButton_Click(object sender, EventArgs e)
        {
            try
            {
                ordersTreeView.Nodes.Clear();
                // Если пользователь выбрал 0 или несколько записей
                if (WorkWithDataDgv.CountSelectedRows(customersDataGridView) != 1)
                    MessageBox.Show("Неодходимо выбрать одну запись", "Поиск заказов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    // Получаем список заказов
                    List<int> orders = Customer.GetNumbersOfOrdersThisCustomer(customersDataGridView.Rows[WorkWithDataDgv.NumberSelectedRows(customersDataGridView)].Cells["Электронная почта"].Value.ToString());

                    // Если список пуст
                    if (orders.Count == 0)
                        MessageBox.Show("У выбранного заказчика нет заказов", "Поиск заказов", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        // Выводим номера заказов
                        foreach (int order in orders)
                        {
                            ordersTreeView.Nodes.Add(order.ToString());
                        }
                    }


                }
            }
            catch
            {
                MessageBox.Show("Ошибка поиска заказов", "Поиск заказов", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void fashionCustomersButton_Click(object sender, EventArgs e)
        {

        }

        private void CustomersMenu_Load(object sender, EventArgs e)
        {
            try
            {
                LoadTable();

                // Выводим сообщение о доступности действия в зависимости от действия
                if (customer != null && state == 'A')
                    addCustomerLabel.Text = "Вы можете добавить запись";
            }
            catch 
            {
                MessageBox.Show("Ошибка отображения стартовых данных", "Отображение стартовых данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTable()
        {
            // Загружаем данные о заказчиках в таблицу
            Customer.LoadCustomers(customersDataGridView);
            WorkWithDataDgv.SetReadOnlyColumns(customersDataGridView);

            customersDataGridView.Columns["Наименование заказчика"].Width = 230;
            customersDataGridView.Columns["Номер телефона"].Width = 195;
            customersDataGridView.Columns["Электронная почта"].Width = 230;
        }

        private void customersDataGridView_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            // Ищём запрашиваемые данные в таблице
            WorkWithDataDgv.GetLikeString(customersDataGridView, columnsComboBox, searchTextBox);
        }


    }
}

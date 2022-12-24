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

        public CustomersMenu(Customer customer, char state, int id) 
        {
            InitializeComponent();
            this.customer = customer;
            this.state = state;
            this.id = id;
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
            try
            {
                // Если количество выбранный записей не равно 1
                if (WorkWithDataDgv.CountSelectedRows(customersDataGridView) != 1)
                    MessageBox.Show("Неодходимо выбрать одну запись", "Выбор записи для её изменения", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    int numberRow = WorkWithDataDgv.NumberSelectedRows(customersDataGridView);

                    if (!Customer.CustomerHasBooking(Customer.GetIdCustomerByPhone(customersDataGridView.Rows[numberRow].Cells["Номер телефона"].Value.ToString())))
                    {

                        //Cоздаём объект заказчика               
                        Customer customer = new Customer(customersDataGridView.Rows[numberRow].Cells["Наименование заказчика"].Value.ToString(), customersDataGridView.Rows[numberRow].Cells["Электронная почта"].Value.ToString(), customersDataGridView.Rows[numberRow].Cells["Номер телефона"].Value.ToString());

                        // Переходим в меню ввода данных для изменения этих самых данных
                        FillDataCustomerMenu fillDataCustomerMenu = new FillDataCustomerMenu(customer, 'C');
                        Transition.TransitionByForms(this, fillDataCustomerMenu);
                    }
                    else
                        MessageBox.Show("Невозможно изменить запись, так как у выбранного заказчика имеются заказы. Удалите заказы, в которых фигурируется выбранный заказчик, или создайте нового заказчика", "Выбор записи для её изменения", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch 
            {
                MessageBox.Show("Ошибка выбора записи", "Выбор записи для её изменения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetAddOrChangeButton_Click(object sender, EventArgs e)
        {
            // Приводим буфферные данные и компоненты в состояние по умолчанию
            DefaultStateOfMenu();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

            try
            {
                // Если пользователь выбрал 0 записей
                if (WorkWithDataDgv.CountSelectedRows(customersDataGridView) < 1)
                    MessageBox.Show("Неодходимо выбрать одну или несколько записей", "Удаление заказчиков", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    // Если пользователь соглашается на удаление записи(-ей)
                    if (MessageBox.Show("Вы точно хотите удалить эту(-и) запись(-и)?", "Удаление заказчиков", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        // Получаем массив id
                        int[] arrayId = Customer.GetArrayIdCustomers(customersDataGridView, WorkWithDataDgv.GetListIndexesSelectedRows(customersDataGridView));

                        // Если у заказчика(-ов) нет заказа(-ов)
                        if (!Customer.CustomersHaveBooking(arrayId))
                        {
                            // Если мы удалили указанное количество записей
                            if (Customer.DeleteCustomers(arrayId) == arrayId.Length)
                            {
                                MessageBox.Show("Записи успешно удалены!", "Удаление заказчиков", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ReloadData();
                            }
                            else
                            {
                                MessageBox.Show("Количество удаленных записей не совпадает с количеством выбранных записей", "Удаление заказчиков", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                            MessageBox.Show("Невозможно удалить запись(-и), так как у заказчика(-ов) существует заказ. Удалите все заказы заказчика и повторите попытку", "Удаление заказчиков", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
            }
            catch
            {

                MessageBox.Show("Произошла ошибка удаления сотрудников", "Удаление сотрудников", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Если пользователь изменяет запись
                if (MessageBox.Show("Вы точно хотите изменить запись?", "Изменение данных о заказчике", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    // Если изменилась только одна запись 
                    if (customer.ChangeCustomer(id) == 1)
                        MessageBox.Show("Запись успешно изменена!", "Изменение данных о заказчике", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    else
                        MessageBox.Show("Количество измененных записей не равно единице", "Изменение данных о заказчике", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    ReloadData();
                    DefaultStateOfMenu();

                }
            }
            catch
            {
                MessageBox.Show("Ошибка изменения данных о заказчике", "Изменение данных о заказчике", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                        // Выводим наименование заказчика
                        ordersTreeView.Nodes.Add(customersDataGridView.Rows[WorkWithDataDgv.NumberSelectedRows(customersDataGridView)].Cells["Наименование заказчика"].Value.ToString());

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
            if (customersDataGridView.Rows.Count > 0)
            {
                FashionCustomersMenu fashionCustomersMenu = new FashionCustomersMenu();
                Transition.TransitionByForms(this, fashionCustomersMenu);

            }
            else
                MessageBox.Show("Невозможно вывести моду данных о заказчиках, так они отсутствуют!", "Вывод моды данных о заказчиках", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CustomersMenu_Load(object sender, EventArgs e)
        {
            try
            {
                LoadTable();

                // Если пользователь добавляет запись
                if (customer != null && state == 'A')
                    addCustomerLabel.Text = "Вы можете добавить запись";

                // Если пользователь изменяет запись
                else if (customer != null && state == 'C')
                {
                    addButton.Enabled = false;
                    deleteButton.Enabled = false;
                    changeButton.Enabled = true;

                    changeCustomerLabel.Text = "Вы можете изменить запись";
                }
            }
            catch 
            {
                MessageBox.Show("Ошибка отображения стартовых данных", "Отображение стартовых данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод загрузки данных
        /// </summary>
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

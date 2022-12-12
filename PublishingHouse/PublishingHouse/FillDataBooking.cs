using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PublishingHouse
{
    public partial class FillDataBooking : Form
    {
        Booking booking = null;
        char state = ' ';
        int id = -1;

        public FillDataBooking()
        {
            InitializeComponent();
        }

        public FillDataBooking(char state) 
        {
            InitializeComponent();
            this.state = state;
        }

        public FillDataBooking(Booking booking, char state) 
        {
            InitializeComponent();
            this.booking = booking;
            this.state = state;
        }

        private void backTab_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            Transition.TransitionByForms(this, mainMenu);
        }

        private void FillDataBooking_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void FillDataBooking_Load(object sender, EventArgs e)
        {
            try
            {
                //Загружаем данные в компоненты
                LoadStartData();

                
                // Если пользователь изменяет запись
                if (booking != null && state == 'C')
                {
                    //LoadDataAboutProduct();
                    id = this.booking.NumBooking;
                    dateAddBookingTimePicker.Enabled = true;
                    dateAddBookingTimePicker.Value = booking.StartBooking;
                }
            }
            catch
            {
               MessageBox.Show("Ошибка загрузки формы ввода данных о заказе", "Ввод данных о заказе", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Метод загрузки стартовых данных
        /// </summary>
        private void LoadStartData() 
        {
            // Данные о сотрудниках
            Employee.LoadEmployees(employeesDataGridView);
            WorkWithDataDgv.SetReadOnlyColumns(employeesDataGridView);
            

            // Данные о заказчиках
            Customer.LoadCustomers(customerDataGridView);
            WorkWithDataDgv.SetReadOnlyColumns(customerDataGridView);
            

            // Данные о типографиях
            PrintingHouse.LoadNamePrintingHouseIntoComboBox(printingHouseComboBox);
            printingHouseComboBox.SelectedIndex = 0;

            if (state == 'A')
            {
                // Данные о печатной продукции
                Product.LoadProductsWithoutOrdersInTable(productsDataGridView);              

            }
            else if (state == 'C') 
            {
                // Метод, который учитывает id
                Product.LoadProductsWithoutOrdersInTable(productsDataGridView, booking.NumBooking);               
                LoadDataForChange();
            }

            WorkWithDataDgv.SetReadOnlyColumns(productsDataGridView);
            productsDataGridView.Columns[1].Width = 200;
        }

        /// <summary>
        /// Метод загрузки стартовых данных при изменении данных
        /// </summary>
        private void LoadDataForChange() 
        {
            printingHouseComboBox.Text = booking.NamePrintingHouse;
            Customer.SelectRowInTable(customerDataGridView, booking.IdCustomer);
            Employee.SelectRowsInTable(employeesDataGridView, booking.IdEmployees);
            employeesDataGridView.CurrentCell = employeesDataGridView.Rows[0].Cells[1];
            Product.SelectRowsInTable(productsDataGridView, booking.IdProducts);

        }

        private void employeesDataGridView_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = null;
            Booking booking = null;

            try
            {
                // Если пользователь правильно ввёл данные
                if (CorrectInputData())
                {
                   
                    // Получаем данные для формирования заказа
                    int idPrintingHouse = PrintingHouse.GetIdPrintingHouseByName(printingHouseComboBox.Text);
                    DateTime startBooking = DateTime.Now.Date;
                    int idCustomer = Customer.GetIdCustomerByPhone(customerDataGridView.Rows[WorkWithDataDgv.NumberSelectedRows(customerDataGridView)].Cells["Номер телефона"].Value.ToString());
                    string status = "Выполняется";
                    double cost = Booking.GetCostBooking(productsDataGridView);
                    int[] idProducts = Product.GetArrayIdProducts(productsDataGridView, WorkWithDataDgv.GetListIndexesSelectedRows(productsDataGridView));
                    int[] idEmployees = Employee.GetArrayIdEmployees(employeesDataGridView, WorkWithDataDgv.GetListIndexesSelectedRows(employeesDataGridView));

                    // Если пользователь добавляет запись
                    if (state == 'A')
                    {
                        booking = new Booking(idPrintingHouse, idCustomer, cost, status, startBooking, idProducts, idEmployees);
                        mainMenu = new MainMenu(booking, state);
                    }

                    // Если пользователь изменяет запись
                    else if (state == 'C') 
                    {
                        booking = new Booking(idPrintingHouse, idCustomer, cost, status, dateAddBookingTimePicker.Value.Date, idProducts, idEmployees);
                        mainMenu = new MainMenu(booking, state, id);
                    }

                    Transition.TransitionByForms(this, mainMenu);

                }
                else
                    MessageBox.Show("Необходимо выбрать одного заказчика, хотя бы одного сотрудника, одну печатную продукцию. Если вы изменяете данные, то вы должны выбрать дату, которая не превышает значение сегодняшней даты", "Ввод данных о заказе", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch 
            {
                MessageBox.Show("Ошибка ввода данных о заказе", "Ввод данных о заказе", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод проверки правильности введенных данных
        /// </summary>
        /// <returns>Правильно ли пользователь ввёл данные</returns>
        private bool CorrectInputData()
        {
            if (state == 'A')
            {
                if (WorkWithDataDgv.CountSelectedRows(customerDataGridView) != 1 || WorkWithDataDgv.CountSelectedRows(employeesDataGridView) < 1 || WorkWithDataDgv.CountSelectedRows(productsDataGridView) < 1)
                    return false;

            }
            else if (state == 'C') 
            {
                if (WorkWithDataDgv.CountSelectedRows(customerDataGridView) != 1 || WorkWithDataDgv.CountSelectedRows(employeesDataGridView) < 1 || WorkWithDataDgv.CountSelectedRows(productsDataGridView) < 1 || dateAddBookingTimePicker.Value.Date > DateTime.Now.Date)
                    return false;
            }

            return true;
        }

       
    }
}

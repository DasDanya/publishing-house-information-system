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
                    //id = Product.GetIdProduct(product.Name, product.NumberEdition);
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

            // Данные о печатных продукциях (неиспользуемые)
            Product.LoadProductsWithoutOrdersInTable(productsDataGridView);
            WorkWithDataDgv.SetReadOnlyColumns(productsDataGridView);
            productsDataGridView.Columns[1].Width = 200;

            // Данные о типографиях
            PrintingHouse.LoadNamePrintingHouseIntoComboBox(printingHouseComboBox);
            printingHouseComboBox.SelectedIndex = 0;

        }

        private void employeesDataGridView_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}

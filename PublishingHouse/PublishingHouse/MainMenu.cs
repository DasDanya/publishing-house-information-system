using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PublishingHouse
{
    public partial class MainMenu : Form
    {
        Booking booking = null;
        char state = ' ';
        int id = -1;

        public MainMenu()
        {
            InitializeComponent();
        }

        public MainMenu(Booking booking, char state) 
        {
            InitializeComponent();
            this.booking = booking;
            this.state = state;
        }

        public MainMenu(Booking booking, char state, int id) 
        {
            InitializeComponent();
            this.booking = booking;
            this.state = state;
            this.id = id;
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            try
            {
                //LoadTable();

                // Если пользователь добавляет запись
                if (booking != null && state == 'A')
                    addLabel.Text = "Вы можете добавить запись";

                // Если пользователь изменяет запись
                else if (booking != null && state == 'C')
                {
                    addButton.Enabled = false;
                    //deleteButton.Enabled = false;
                    //changeButton.Enabled = true;

                    //changeLabel.Text = "Вы можете изменить запись";
                }
            }
            catch
            {
                MessageBox.Show("Ошибка отображения стартовых данных", "Отображение стартовых данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void employeeTab_Click(object sender, EventArgs e)
        {
            EmployeeMenu employeeMenu = new EmployeeMenu();
            Transition.TransitionByForms(this, employeeMenu); // Переход между формами
           
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {           
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void materialTab_Click(object sender, EventArgs e)
        {
            MaterialMenu materialMenu = new MaterialMenu();
            Transition.TransitionByForms(this, materialMenu); // Переход между формами
        }

        private void printingHouseTab_Click(object sender, EventArgs e)
        {
            PrintingHouseMenu printingHouseMenu = new PrintingHouseMenu();
            Transition.TransitionByForms(this, printingHouseMenu); // Переход между формами
        }

        private void customersTab_Click(object sender, EventArgs e)
        {
            CustomersMenu customersMenu = new CustomersMenu();
            Transition.TransitionByForms(this, customersMenu); // Переход между формами
        }

        private void productTab_Click(object sender, EventArgs e)
        {
            ProductMenu productMenu = new ProductMenu();
            Transition.TransitionByForms(this, productMenu); // Переход между формами
        }

        private void inputDataButton_Click(object sender, EventArgs e)
        {
            FillDataBooking fillDataBooking = new FillDataBooking('A');
            Transition.TransitionByForms(this, fillDataBooking);
        }

        private void bookingDataGridView_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (booking == null || state != 'A')
                    MessageBox.Show("Перед добавлением заказа необходимо ввести данные о нем", "Добавление заказа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    if (booking.AddBooking() == 1)
                    {
                        MessageBox.Show("Запись успешно добавлена!", "Добавление печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Выводим новые данные и делаем комноненты и переменные в состояние по умолчанию
                        //ReloadData();
                        //DefaultStateOfMenu();
                        //DisplayStartPhoto();

                    }
                    else
                        MessageBox.Show("Количество добавленных записей не равно должному количеству", "Добавление заказа", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch
            {
                MessageBox.Show("Ошибка добавления заказа", "Добавление заказа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

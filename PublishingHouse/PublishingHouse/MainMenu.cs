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
                LoadTable();

                // Если пользователь добавляет запись
                if (booking != null && state == 'A')
                    addLabel.Text = "Вы можете добавить запись";

                // Если пользователь изменяет запись
                else if (booking != null && state == 'C')
                {
                    addButton.Enabled = false;
                    deleteButton.Enabled = false;
                    changeButton.Enabled = true;

                    changeLabel.Text = "Вы можете изменить запись";
                }
            }
            catch
            {               
                MessageBox.Show("Ошибка отображения стартовых данных", "Отображение стартовых данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Метод загрузки данных в таблицу
        /// </summary>
        private void LoadTable()
        {
            // Загружаем данные о заказах в таблицу
            Booking.LoadBookings(bookingDataGridView);
            WorkWithDataDgv.SetReadOnlyColumns(bookingDataGridView);
            bookingDataGridView.Columns["Заказчик"].Width = 240;

        }

        /// <summary>
        /// Метод,который приводит компоненты и переменные в состояние по умолчанию
        /// </summary>
        private void DefaultStateOfMenu()
        {
            ClearBuffer();
            addLabel.Text = "";
            changeLabel.Text = "";
            addButton.Enabled = true;
            deleteButton.Enabled = true;
            changeButton.Enabled = false;

        }

        /// <summary>
        /// Метод очистки значений для буфферных переменных
        /// </summary>
        private void ClearBuffer()
        {
            booking = null;
            state = ' ';
            id = -1;
        }


        /// <summary>
        /// Метод вывода новых данных из бд
        /// </summary>
        private void ReloadData()
        {
            // Удаляем все строки из таблицы
            while (bookingDataGridView.Rows.Count != 0)
            {
                bookingDataGridView.Rows.Remove(bookingDataGridView.Rows[bookingDataGridView.Rows.Count - 1]);
            }

            // Загружаем новые данные
            LoadTable();

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
                        MessageBox.Show("Запись успешно добавлена!", "Добавление заказа", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Выводим новые данные и делаем комноненты и переменные в состояние по умолчанию
                        ReloadData();
                        DefaultStateOfMenu();
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

        private void resetAddOrChangeButton_Click(object sender, EventArgs e)
        {
            // Приводим буфферные данные и компоненты в состояние по умолчанию
            DefaultStateOfMenu();
        }
    }
}

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
            bookingDataGridView.Columns["Заказчик"].Width = 270;
            bookingDataGridView.Columns["Дата выполнения"].Width = 170;
            bookingDataGridView.Columns["Стоимость выполнения"].Width = 200;
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

        private void selectAllRowsButton_Click(object sender, EventArgs e)
        {
            if (bookingDataGridView.Rows.Count < 1)
                MessageBox.Show("Отсутствуют строки для выбора", "Выбрать всё", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                WorkWithDataDgv.SelectOrCancelSelectAllRows(bookingDataGridView, true);
        }

        private void resetSelectRowsButton_Click(object sender, EventArgs e)
        {
            if (bookingDataGridView.Rows.Count < 1)
                MessageBox.Show("Отсутствуют строки", "Отменить выбор строк", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                WorkWithDataDgv.SelectOrCancelSelectAllRows(bookingDataGridView, false);
        }

        private void selectForChangeButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Если количество выбранный записей не равно 1
                if (WorkWithDataDgv.CountSelectedRows(bookingDataGridView) != 1)
                    MessageBox.Show("Неодходимо выбрать одну запись", "Выбор записи для её изменения", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    int numberRow = WorkWithDataDgv.NumberSelectedRows(bookingDataGridView);
                    int idBooking = Convert.ToInt32((bookingDataGridView.Rows[numberRow].Cells["Номер заказа"].Value));
                    if (Booking.BookingIsBeingExecuted(idBooking))
                    {

                        // Получаем данные о заказе
                        int idCustomer = Booking.GetIdCustomer(idBooking);
                        int[] idEmployees = Booking.GetArrayIdEmployees(idBooking);
                        int[] idProducts = Booking.GetArrayIdProducts(idBooking);

                        Booking booking = new Booking(idBooking,idCustomer, bookingDataGridView.Rows[numberRow].Cells["Типография"].Value.ToString(), (DateTime)bookingDataGridView.Rows[numberRow].Cells["Дата приёма"].Value, idProducts, idEmployees);

                        // Переходим в меню ввода данных для изменения этих самых данных
                        FillDataBooking fillDataBooking = new FillDataBooking(booking, 'C');
                        Transition.TransitionByForms(this, fillDataBooking);
                    }
                    else
                        MessageBox.Show("Невозможно изменить заказ, потому что он выполнен", "Выбор записи для её изменения", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка выбора записи для её изменения", "Выбор записи для её изменения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Если пользователь изменяет запись
                if (MessageBox.Show("Вы точно хотите изменить запись?", "Изменение данных о заказе", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    // Если изменилась только выбранная запись
                    if (booking.ChangeBooking(id) == 1)
                        MessageBox.Show("Запись успешно изменена!", "Изменение данных о заказе", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Количество измененных записей не равно ожидаемому количеству изменяемых записей", "Изменение данных о заказе", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    // Выводим новые данные и делаем комноненты и переменные в состояние по умолчанию
                    ReloadData();
                    DefaultStateOfMenu();
                  
                }
            }
            catch
            {
                MessageBox.Show("Ошибка изменения данных о заказе", "Изменение данных о заказе", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void completeBookingButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Количество выбранных заказов
                int numberSelectedRows = WorkWithDataDgv.CountSelectedRows(bookingDataGridView);

                if ( numberSelectedRows < 1)
                    MessageBox.Show("Необходимо выбрать хотя бы одну запись", "Выполнить заказ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    // Если пользователь подтвердил выполнение заказа
                    if (MessageBox.Show("Вы точно хотите выполнить заказ? После выполнения заказа изменение его данных станет невозможным", "Выполнить заказ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        int countCompleBookings = 0;

                        // Проходимся по таблице
                        for (int i = 0; i < bookingDataGridView.RowCount; i++)
                        {
                            // id заказа
                            int idBooking = Convert.ToInt32(bookingDataGridView.Rows[i].Cells["Номер заказа"].Value);

                            // Если заказ выбран
                            if (Convert.ToBoolean(bookingDataGridView.Rows[i].Cells[0].Value))
                            {
                                // Если заказ выполняется
                                if (Booking.BookingIsBeingExecuted(idBooking))
                                    countCompleBookings += Booking.BookingIsCompleted(idBooking);
                            }
                        }

                        if (countCompleBookings != numberSelectedRows)
                            MessageBox.Show("Некоторые выбранные заказы уже выполнены!", "Выполнить заказ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Выбранные заказы выполнены!", "Выполнить заказ", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        ReloadData();
                        DefaultStateOfMenu();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка выполнения заказа", "Выполнить заказ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (WorkWithDataDgv.CountSelectedRows(bookingDataGridView) < 1)
                {
                    MessageBox.Show("Необходимо выбрать хотя бы одну запись", "Удаление заказа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else 
                {
                    if (MessageBox.Show("Вы точно хотите удалить выбранные заказы?", "Удаление заказа", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        // Получаем массив выбранных строк
                        int[] arrayIdBookings = Booking.GetArrayIdBookings(bookingDataGridView, WorkWithDataDgv.GetListIndexesSelectedRows(bookingDataGridView));

                        bool executed = false;
                        for (int i = 0; i < arrayIdBookings.Length; i++)
                        {
                            if (Booking.BookingIsBeingExecuted(arrayIdBookings[i]))
                            {
                                executed = true;
                                break;
                            }
                        }

                        // Если хоть один из выбранных заказов выполняется
                        if (executed)
                            MessageBox.Show("Невозможно удалить заказы, так как присутствует заказ, который ещё выполняется", "Удаление заказа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        else
                        {
                            if (Booking.DeleteBooking(arrayIdBookings) == arrayIdBookings.Length)
                            {
                                MessageBox.Show("Заказы успешно удалены!", "Удаление заказов", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ReloadData();
                            }
                            else
                                MessageBox.Show("Количество удаленных заказов не равно выбранному количеству записей", "Удаление заказов", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
            catch
            {
                MessageBox.Show("Ошибка удаления заказа", "Удаление заказа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void processingTab_Click(object sender, EventArgs e)
        {
            inputDataButton.Visible = true;
            addLabel.Visible = true;
            addButton.Visible = true;
            selectForChangeButton.Visible = true;
            resetAddOrChangeButton.Visible = true;
            deleteButton.Visible = true;
            changeLabel.Visible = true;
            changeButton.Visible = true;
            selectAllRowsButton.Visible = true;
            resetSelectRowsButton.Visible = true;
            completeBookingButton.Visible = true;
            generateReportButton.Visible = true;
            stringColumnLabel.Visible = false;
            stringComboBox.Visible = false;
            stringDataLabel.Visible = false;
            stringTextBox.Visible = false;
            intLabel.Visible = false;
            numberComboBox.Visible = false;
            toLabel.Visible = false;
            toTextBox.Visible = false;
            fromLabel.Visible = false;
            fromTextBox.Visible = false;
            searchNumbersButton.Visible = false;
            searchDateButton.Visible = false;
            dateLabel.Visible = false;
            dateComboBox.Visible = false;
            toDataLabel.Visible = false;
            toDateTimePicker.Visible = false;
            fromDataLabel.Visible = false;
            fromDateTimePicker.Visible = false;
            resetSearchButton.Visible = false;
        }

        private void searchTab_Click(object sender, EventArgs e)
        {
            
            inputDataButton.Visible = false;
            addLabel.Visible = false;
            addButton.Visible = false;
            selectForChangeButton.Visible = false;
            resetAddOrChangeButton.Visible = false;
            deleteButton.Visible = false;
            changeLabel.Visible = false;
            changeButton.Visible = false;
            selectAllRowsButton.Visible = false;
            resetSelectRowsButton.Visible = false;
            completeBookingButton.Visible = false;
            generateReportButton.Visible = false;
            stringColumnLabel.Visible = true;
            stringComboBox.Visible = true;
            stringDataLabel.Visible = true;
            stringTextBox.Visible = true;
            intLabel.Visible = true;
            numberComboBox.Visible = true;
            toLabel.Visible = true;
            toTextBox.Visible = true;
            fromLabel.Visible = true;
            fromTextBox.Visible = true;
            searchNumbersButton.Visible = true;
            searchDateButton.Visible = true;
            dateLabel.Visible = true;
            dateComboBox.Visible = true;
            toDataLabel.Visible = true;
            toDateTimePicker.Visible = true;
            fromDataLabel.Visible = true;
            fromDateTimePicker.Visible = true;
            resetSearchButton.Visible = true;

            try
            {
                // Устанавливаем значения и свойства полям для поиска
                WorkWithDataDgv.SetElementsForSearchStringData(bookingDataGridView, stringComboBox, stringTextBox);
                WorkWithDataDgv.SetRowOfIntComboBox(bookingDataGridView, numberComboBox, fromTextBox, toTextBox);
                WorkWithDataDgv.SetDateForSearch(bookingDataGridView, dateComboBox, fromDateTimePicker, toDateTimePicker);
            }
            catch 
            {
                MessageBox.Show("Ошибка отображения компонентов для поиска данных", "Поиск данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void stringTextBox_TextChanged(object sender, EventArgs e)
        {
            // Ищём запрашиваемые данные в таблице
            WorkWithDataDgv.GetLikeString(bookingDataGridView, stringComboBox, stringTextBox);
        }

        private void fromTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Получаем символ, который ввёл пользователь
            char number = e.KeyChar;

            // Если пользователь ввёл не цифру, не нажал на Backspace или запятую, то не отображаем символ в textbox
            if (!Char.IsDigit(number) && number != 8 && number != 44)
                e.Handled = true;
        }

        private void searchNumbersButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (bookingDataGridView.RowCount < 1)
                    MessageBox.Show("Отсутствуют строки для поиска", "Поиск числовых данных", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    double from = Convert.ToDouble(fromTextBox.Text);
                    double to = Convert.ToDouble(toTextBox.Text);

                    if (from >= to)
                        MessageBox.Show("Данные в поле \"От\" должны быть меньше данных в поле \"До\"", "Поиск числовых данных", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                    {
                        // Производим поиск числовых данных
                        WorkWithDataDgv.SearchByDifference(bookingDataGridView, numberComboBox.Text, from, to);
                        
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка поиска числовых данных. Возможно, что вы ввели нецелые числа для поиска данных из столбца, которых хранит в себе только целые числа", "Поиск числовых данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetSearchButton_Click(object sender, EventArgs e)
        {
            WorkWithDataDgv.ResetSearch(bookingDataGridView);
            stringTextBox.Text = "";
            toTextBox.Text = "";
            fromTextBox.Text = "";
            fromDateTimePicker.Value = DateTime.Now.Date;
            toDateTimePicker.Value = DateTime.Now.Date;
        }

        private void searchDateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (bookingDataGridView.RowCount < 1)
                    MessageBox.Show("Отсутствуют строки для поиска", "Поиск по дате", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    DateTime from = fromDateTimePicker.Value.Date;
                    DateTime to = toDateTimePicker.Value.Date;

                    if (from >= to || from > DateTime.Now.Date || to > DateTime.Now.Date)
                        MessageBox.Show("Дата \"с\", дата \"по\" не должны превышать сегодняшний день. Дата \"с\" должна быть мешьше даты \"по\"", "Поиск по дате", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                    {
                        // Производим поиск по дате
                        WorkWithDataDgv.SearchByDifference(bookingDataGridView, dateComboBox.Text, from, to);
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Ошибка поиска по дате", "Поиск по дате", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void generateReportButton_Click(object sender, EventArgs e)
        {
            if (WorkWithDataDgv.CountSelectedRows(bookingDataGridView) != 1)
                MessageBox.Show("Необходимо выбрать одну запись", "Генерация отчёта", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                int numberRow = WorkWithDataDgv.NumberSelectedRows(bookingDataGridView);                
                int idBooking = Convert.ToInt32(bookingDataGridView.Rows[numberRow].Cells["Номер заказа"].Value);

                // Если заказ выполнен
                if (!Booking.BookingIsBeingExecuted(idBooking))
                {
                    int idCustomer = Booking.GetIdCustomer(idBooking);
                    int idPrintingHouse = Booking.GetIdPrintingHouse(idBooking);
                    double cost = Convert.ToDouble(bookingDataGridView.Rows[numberRow].Cells["Стоимость выполнения"].Value);
                    DateTime startBooking = (DateTime)bookingDataGridView.Rows[numberRow].Cells["Дата приёма"].Value;
                    DateTime endBooking = (DateTime)bookingDataGridView.Rows[numberRow].Cells["Дата выполнения"].Value;
                    int[] idProducts = Booking.GetArrayIdProducts(idBooking);
                    int[] idEmployees = Booking.GetArrayIdEmployees(idBooking);

                    // Создаём объект заказа
                    Booking booking = new Booking(idBooking, idPrintingHouse, idCustomer, cost, bookingDataGridView.Rows[numberRow].Cells["Статус"].Value.ToString(), startBooking, endBooking, idProducts, idEmployees);

                    // Переходим в меню формирования отчёта
                    OutputDataBooking outputDataBooking = new OutputDataBooking(booking);
                    Transition.TransitionByForms(this, outputDataBooking);

                }
                else
                    MessageBox.Show("Необходимо выбрать выполненный заказ", "Генерация отчёта", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }
    }
}

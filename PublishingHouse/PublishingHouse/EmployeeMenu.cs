using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PublishingHouse
{
    public partial class EmployeeMenu : Form
    {
        Employee employee = null;
        char state = ' ';
        int id = -1;

        public EmployeeMenu()
        {
            InitializeComponent();
        }

        public EmployeeMenu(Employee employee, char state) 
        {
            InitializeComponent();
            this.employee = employee;
            this.state = state;

        }

        public EmployeeMenu(Employee employee, char state, int id) 
        {
            InitializeComponent();
            this.employee = employee;
            this.state = state;
            this.id = id;      
        }

        private void AdminMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void inputButton_Click(object sender, EventArgs e)
        {
            FillEmployeeMenu fillEmployeeMenu = new FillEmployeeMenu('A');
            Transition.TransitionByForms(this, fillEmployeeMenu);
        }

        private void addEmployeeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (employee == null || state != 'A')
                    MessageBox.Show("Перед добавлением сотрудника необходимо ввести данные о нём", "Добавление сотрудника", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else 
                {
                    if (employee.AddEmployee() == 1)
                    {
                        MessageBox.Show("Запись успешно добавлена!", "Добавление сотрудника", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Выводим новые данные и делаем комноненты и переменные в состояние по умолчанию
                        ReloadData();
                        DefaultStateOfMenu();
                        DisplayStartPhoto();

                    }
                    else
                        MessageBox.Show("Количество добавленных записей не равно единице", "Добавление сотрудника", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
            catch 
            {
                MessageBox.Show("Ошибка добавления сотрудника", "Добавление сотрудника", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод загрузки данных в таблицу
        /// </summary>
        private void LoadTable() 
        {
            // Загружаем данные о сотрудниках в таблицу
            Employee.LoadEmployees(employeeDataGridView);
            WorkWithDataDgv.SetReadOnlyColumns(employeeDataGridView);
        }

        private void AdminMenu_Load(object sender, EventArgs e)
        {
            try
            {
                LoadTable();

                // Отображаем изображение первого сотрудника
                DisplayStartPhoto();

                // Выводим сообщение о доступности действия в зависимости от действия
                if (employee != null && state == 'A')
                    addLabel.Text = "Вы можете добавить запись";
                else if (employee != null && state == 'C')
                {
                    changeLabel.Text = "Вы можете изменить запись";
                    addEmployeeButton.Enabled = false;
                    deleteButton.Enabled = false;
                    changeButton.Enabled = true;
                }
            }
            catch 
            {
                MessageBox.Show("Ошибка отображения стартовых данных", "Отображение стартовых данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void employeeDataGridView_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void employeeDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Исключаем заголовок DataGridView
                if (e.RowIndex > -1)
                    // Получаем фотографию сотрудника из бд и отображаем её в PictureBox
                    DisplayEmployeePhoto(e.RowIndex);
                
            }
            catch 
            {
                MessageBox.Show("Ошибка отображения фотографии сотрудника", "Отображение фотографии сотрудника", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       /// <summary>
       /// Метод отображения фото сотрудника
       /// </summary>
       /// <param name="rowIndex">Номер строки в таблице</param>
        private void DisplayEmployeePhoto(int rowIndex) 
        {
            try
            {

                employeePictureBox.BackColor = SystemColors.Control;
                employeePictureBox.Image = Employee.GetPhotoAsImage(employeeDataGridView.Rows[rowIndex].Cells["Номер телефона"].Value.ToString());
            }
            catch
            {
                throw new Exception("Ошибка получения изображения");
            }
        }

        

        /// <summary>
        /// Метод,который приводит компоненты и переменные в состояние по умолчанию
        /// </summary>
        private void DefaultStateOfMenu()
        {
            ClearBuffer();
            addLabel.Text = "";
            changeLabel.Text = "";
            addEmployeeButton.Enabled = true;
            deleteButton.Enabled = true;
            changeButton.Enabled = false;

        }

        /// <summary>
        /// Метод очистки значений для буфферных переменных
        /// </summary>
        private void ClearBuffer()
        {
            employee = null;
            state = ' ';
            id = -1;
        }

        /// <summary>
        /// Метод вывода новых данных из бд
        /// </summary>
        private void ReloadData()
        {
            // Удаляем все строки из таблицы
            while (employeeDataGridView.Rows.Count != 0)
            {
                employeeDataGridView.Rows.Remove(employeeDataGridView.Rows[employeeDataGridView.Rows.Count - 1]);
            }

            // Загружаем новые данные
            LoadTable();

        }

        /// <summary>
        /// Метод отображения фото первого сотрудника
        /// </summary>
        private void DisplayStartPhoto() 
        {
            try
            {
                // Отображаем изображение первого сотрудника
                if (employeeDataGridView.RowCount >= 1)
                {
                    DisplayEmployeePhoto(0);
                    employeeDataGridView.CurrentCell = employeeDataGridView.Rows[0].Cells["Фамилия"];
                }
            }
            catch 
            {
                MessageBox.Show("Ошибка отображения стартого изображения", "Отображение стартового изображения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void selectForChangeButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Если количество выбранный записей не равно 1
                if (WorkWithDataDgv.CountSelectedRows(employeeDataGridView) != 1)
                    MessageBox.Show("Неодходимо выбрать одну запись", "Выбор записи для её изменения", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    int numberRow = WorkWithDataDgv.NumberSelectedRows(employeeDataGridView);

                    if (!Employee.EmployeeIsWorking(Employee.GetIdEmployeeByPhone(employeeDataGridView.Rows[numberRow].Cells["Номер телефона"].Value.ToString())))
                    {

                        //Cоздаём объект типографии               
                        Employee employee = new Employee(employeeDataGridView.Rows[numberRow].Cells["Имя"].Value.ToString(), employeeDataGridView.Rows[numberRow].Cells["Фамилия"].Value.ToString(), employeeDataGridView.Rows[numberRow].Cells["Отчество"].Value.ToString(), employeeDataGridView.Rows[numberRow].Cells["Должность сотрудника"].Value.ToString(),
                            employeeDataGridView.Rows[numberRow].Cells["Электронная почта"].Value.ToString(), employeeDataGridView.Rows[numberRow].Cells["Номер телефона"].Value.ToString(), (DateTime)employeeDataGridView.Rows[numberRow].Cells["Дата рождения"].Value, Employee.GetPhotoAsImage(employeeDataGridView.Rows[WorkWithDataDgv.NumberSelectedRows(employeeDataGridView)].Cells["Номер телефона"].Value.ToString()));

                        // Переходим в меню ввода данных для изменения этих самых данных
                        FillEmployeeMenu fillEmployeeMenu = new FillEmployeeMenu(employee, 'C');
                        Transition.TransitionByForms(this, fillEmployeeMenu);
                    }
                    else
                        MessageBox.Show("Невозможно изменить запись, так как существует заказ(-ы), над которым(-и) работает сотрудник. Удалите заказ(-ы), над которым(-и) работает сотрудник, или создайте нового сотрудника", "Выбор записи для её изменения", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);



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
                if (MessageBox.Show("Вы точно хотите изменить запись?", "Изменение данных о сотруднике", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {                  
                    // Если изменилась только выбранная запись
                    if (employee.ChangeEmployee(id) == 1)
                        MessageBox.Show("Запись успешно изменена!", "Изменение данных о сотруднике", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Количество измененных записей не равно единице", "Изменение данных о сотруднике", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    // Выводим новые данные и делаем комноненты и переменные в состояние по умолчанию
                    ReloadData();
                    DefaultStateOfMenu();
                    DisplayStartPhoto();

                }
            }
            catch
            {
                MessageBox.Show("Ошибка изменения данных о сотруднике", "Изменение данных о сотруднике", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetaddChangeButton_Click(object sender, EventArgs e)
        {
            // Приводим буфферные данные и компоненты в состояние по умолчанию
            DefaultStateOfMenu();
        }

        private void searchTab_Click(object sender, EventArgs e)
        {
            // Отображаем необходимые компоненты для поиска
            inputButton.Visible = false;
            addEmployeeButton.Visible = false;
            selectForChangeButton.Visible = false;
            changeButton.Visible = false;
            deleteButton.Visible = false;
            resetaddChangeButton.Visible = false;
            columnLabel.Visible = true;
            columnsComboBox.Visible = true;
            dataForSearchLabel.Visible = true;
            searchTextBox.Visible = true;
            selectDatelabel.Visible = true;
            fromLabel.Visible = true;
            toLabel.Visible = true;
            startDateTimePicker.Visible = true;
            endDateTimePicker.Visible = true;
            searchDataButton.Visible = true;
            resetSearchDataButton.Visible = true;
            selectAllButton.Visible = false;
            resetSelectAllButton.Visible = false;
            ordersTreeView.Visible = true;
            searchEmployeeOrdersButton.Visible = true;
            fashionButton.Visible = true;
            addLabel.Visible = false;
            changeLabel.Visible = false;

            // Устанавливаем значения и свойства полям для поиска
            WorkWithDataDgv.SetElementsForSearchStringData(employeeDataGridView, columnsComboBox, searchTextBox);
        }

        private void processingTab_Click(object sender, EventArgs e)
        {
            // Отображаем необходимые компоненты для обработки данных
            inputButton.Visible = true;
            addEmployeeButton.Visible = true;
            selectForChangeButton.Visible = true;
            changeButton.Visible = true;
            deleteButton.Visible = true;
            resetaddChangeButton.Visible = true;
            columnLabel.Visible = false;
            columnsComboBox.Visible = false;
            dataForSearchLabel.Visible = false;
            searchTextBox.Visible = false;
            selectDatelabel.Visible = false;
            fromLabel.Visible = false;
            toLabel.Visible = false;
            startDateTimePicker.Visible = false;
            endDateTimePicker.Visible = false;
            searchDataButton.Visible = false;
            resetSearchDataButton.Visible = false;
            selectAllButton.Visible = false;
            resetSelectAllButton.Visible = false;
            ordersTreeView.Visible = false;
            searchEmployeeOrdersButton.Visible = false;
            fashionButton.Visible = false;
            addLabel.Visible = true;
            changeLabel.Visible = true;
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            // Ищём запрашиваемые данные в таблице
            WorkWithDataDgv.GetLikeString(employeeDataGridView, columnsComboBox, searchTextBox);
            DisplayStartPhoto();
        }

        private void resetSearchDataButton_Click(object sender, EventArgs e)
        {
            // Сбрасываем поиск
            WorkWithDataDgv.ResetSearch(employeeDataGridView);
            searchTextBox.Text = "";
            startDateTimePicker.Value = DateTime.Now;
            endDateTimePicker.Value = DateTime.Now;
            DisplayStartPhoto();
        }

        private void searchDataButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (employeeDataGridView.RowCount < 1)
                    MessageBox.Show("Отсутствуют строки для поиска", "Поиск по дате", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    DateTime from = startDateTimePicker.Value.Date;
                    DateTime to = endDateTimePicker.Value.Date;

                    if (from >= to || from > DateTime.Now.Date || to > DateTime.Now.Date)
                        MessageBox.Show("Дата \"с\", дата \"по\" не должны превышать сегодняшний день. Дата \"с\" должна быть мешьше даты \"по\"", "Поиск по дате", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                    {
                        // Производим поиск по дате рождения
                        WorkWithDataDgv.SearchByDifference(employeeDataGridView, "Дата рождения", from, to);
                        DisplayStartPhoto();
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Ошибка поиска по дате", "Поиск по дате", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void selectTab_Click(object sender, EventArgs e)
        {
            selectAllButton.Visible = true;
            resetSelectAllButton.Visible = true;
            inputButton.Visible = false;
            addEmployeeButton.Visible = false;
            selectForChangeButton.Visible = false;
            changeButton.Visible = false;
            deleteButton.Visible = false;
            resetaddChangeButton.Visible = false;
            columnLabel.Visible = false;
            columnsComboBox.Visible = false;
            dataForSearchLabel.Visible = false;
            searchTextBox.Visible = false;
            selectDatelabel.Visible = false;
            fromLabel.Visible = false;
            toLabel.Visible = false;
            startDateTimePicker.Visible = false;
            endDateTimePicker.Visible = false;
            searchDataButton.Visible = false;
            resetSearchDataButton.Visible = false;
            ordersTreeView.Visible = false;
            searchEmployeeOrdersButton.Visible = false;
            fashionButton.Visible = false;
            addLabel.Visible = false;
            changeLabel.Visible = false;
        }

        private void selectAllButton_Click(object sender, EventArgs e)
        {
            if (employeeDataGridView.Rows.Count < 1)
                MessageBox.Show("Отсутствуют строки для выбора", "Выбрать всё", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                WorkWithDataDgv.SelectOrCancelSelectAllRows(employeeDataGridView, true);
        }

        private void resetSelectAllButton_Click(object sender, EventArgs e)
        {
            if (employeeDataGridView.Rows.Count < 1)
                MessageBox.Show("Отсутствуют строки", "Отменить выбор строк", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                WorkWithDataDgv.SelectOrCancelSelectAllRows(employeeDataGridView, false);
        }

        private void searchEmployeeOrdersButton_Click(object sender, EventArgs e)
        {
            try
            {
                ordersTreeView.Nodes.Clear();
                // Если пользователь выбрал 0 или несколько записей
                if (WorkWithDataDgv.CountSelectedRows(employeeDataGridView) != 1)
                    MessageBox.Show("Неодходимо выбрать одну запись", "Поиск заказов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    // Получаем список заказов
                    List<int> orders = Employee.GetNumbersOfOrdersThisEmployee(employeeDataGridView.Rows[WorkWithDataDgv.NumberSelectedRows(employeeDataGridView)].Cells["Электронная почта"].Value.ToString());

                    // Если список пуст
                    if (orders.Count == 0)
                        MessageBox.Show("Выбранный сотрудник не выполняет заказы", "Поиск заказов", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {

                        string fio = employeeDataGridView.Rows[WorkWithDataDgv.NumberSelectedRows(employeeDataGridView)].Cells["Фамилия"].Value.ToString() + " " + employeeDataGridView.Rows[WorkWithDataDgv.NumberSelectedRows(employeeDataGridView)].Cells["Имя"].Value.ToString() +
                            " " + employeeDataGridView.Rows[WorkWithDataDgv.NumberSelectedRows(employeeDataGridView)].Cells["Отчество"].Value.ToString();

                        // Выводим ФИО сотрудника
                        ordersTreeView.Nodes.Add(fio);

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

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Если пользователь выбрал 0 записей
                if (WorkWithDataDgv.CountSelectedRows(employeeDataGridView) < 1)
                    MessageBox.Show("Неодходимо выбрать одну или несколько записей", "Удаление сотрудников", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    // Если пользователь соглашается на удаление записи(-ей)
                    if (MessageBox.Show("Вы точно хотите удалить эту(-и) запись(-и)?", "Удаление сотрудников", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        // Получаем массив id
                        int[] arrayId = Employee.GetArrayIdEmployees(employeeDataGridView, WorkWithDataDgv.GetListIndexesSelectedRows(employeeDataGridView));

                        // Если сотрудник(-и) не выполняет(-ют) заказ
                        if (!Employee.EmployeesIsWorking(arrayId))
                        {
                            // Если мы удалили указанное количество записей
                            if (Employee.DeleteEmployees(arrayId) == arrayId.Length)
                            {
                                MessageBox.Show("Записи успешно удалены!", "Удаление сотрудников", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ReloadData();
                                DisplayStartPhoto();

                                // Очищаем поле для фото сотрудника, если таблица пустая
                                if (employeeDataGridView.RowCount < 1)
                                    WorkWithDataDgv.EmptyPictureBox(employeePictureBox);
                            }
                            else
                            {
                                MessageBox.Show("Количество удаленных записей не совпадает с количеством выбранных записей", "Удаление сотрудников", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                            MessageBox.Show("Невозможно удалить запись(-и), так как существует заказ(-ы), над которым(-и) работает сотрудник. Удалите заказ(-ы), над которым(-и) работает сотрудник, и повторите попытку", "Удаление сотрудников", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
            }
            catch
            {
             
                MessageBox.Show("Произошла ошибка удаления сотрудников", "Удаление сотрудников", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fashionButton_Click(object sender, EventArgs e)
        {
            if (employeeDataGridView.Rows.Count > 0)
            {
                FashionDataEmployee fashionDataEmployee = new FashionDataEmployee();
                Transition.TransitionByForms(this, fashionDataEmployee);

            }
            else
                MessageBox.Show("Невозможно вывести моду данных о сотрудниках, так они отсутствуют!", "Вывод моды данных о сотрудниках", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void backTab_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            Transition.TransitionByForms(this, mainMenu);
        }
    }
}

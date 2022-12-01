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
    public partial class AdminMenu : Form
    {
        Employee employee = null;
        char state = ' ';
        int id = -1;

        public AdminMenu()
        {
            InitializeComponent();
        }

        public AdminMenu(Employee employee, char state) 
        {
            InitializeComponent();
            this.employee = employee;
            this.state = state;

        }

        public AdminMenu(Employee employee, char state, int id) 
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

        private void LoadTable() 
        {
            // Загружаем данные о сотрудниках в таблицу
            Employee.LoadEmployees(employeeDataGridView);
            WorkWithDataDgv.SetReadOnlyColumns(employeeDataGridView);
        }

        private void AdminMenu_Load(object sender, EventArgs e)
        {
            LoadTable();

            // Отображаем изображение первого сотрудника
            DisplayStartPhoto();

            // Выводим сообщение о доступности действия в зависимости от действия
            if (employee != null && state == 'A')
                addLabel.Visible = true;
            else if (employee != null && state == 'C')
                changeLabel.Visible = true;
            
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

       
        private void DisplayEmployeePhoto(int rowIndex) 
        {
            try
            {
                // Получаем фотографию пользователя из бд
                byte[] photo = Employee.GetPhotoEmployeeByPhone(employeeDataGridView.Rows[rowIndex].Cells["Номер телефона"].Value.ToString());
                employeePictureBox.BackColor = SystemColors.Control;

                // Переводим изображение из массива байт в Image и отображаем в PictureBox
                MemoryStream stream = new MemoryStream(photo);
                employeePictureBox.Image = Image.FromStream(stream);
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
            addLabel.Visible = false;
            changeLabel.Visible = false;
            
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

        private void DisplayStartPhoto() 
        {
            // Отображаем изображение первого сотрудника
            if (employeeDataGridView.RowCount >= 1)
            {
                DisplayEmployeePhoto(0);
                employeeDataGridView.CurrentCell = employeeDataGridView.Rows[0].Cells["Фамилия"];
            }

        }

        private void selectForChangeButton_Click(object sender, EventArgs e)
        {
            // Если количество выбранный записей не равно 1
            if (WorkWithDataDgv.CountSelectedRows(employeeDataGridView) != 1)
                MessageBox.Show("Неодходимо выбрать одну запись", "Выбор записи для её изменения", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else 
            {
                // Получаем номер выбранной записи и создаём объект типографии
                int numberRow = WorkWithDataDgv.NumberSelectedRows(employeeDataGridView);
                Employee employee = new Employee(employeeDataGridView.Rows[numberRow].Cells["Имя"].Value.ToString(), employeeDataGridView.Rows[numberRow].Cells["Фамилия"].Value.ToString(), employeeDataGridView.Rows[numberRow].Cells["Отчество"].Value.ToString(), employeeDataGridView.Rows[numberRow].Cells["Должность сотрудника"].Value.ToString(),
                    employeeDataGridView.Rows[numberRow].Cells["Электронная почта"].Value.ToString(), employeeDataGridView.Rows[numberRow].Cells["Номер телефона"].Value.ToString(), (DateTime)employeeDataGridView.Rows[numberRow].Cells["Дата рождения"].Value, employeePictureBox.Image);

                // Переходим в меню ввода данных для изменения этих самых данных
                FillEmployeeMenu fillEmployeeMenu = new FillEmployeeMenu(employee, 'C');
                Transition.TransitionByForms(this, fillEmployeeMenu);


            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Если пользователь изменяет запись
                if (MessageBox.Show("Вы точно хотите изменить запись?", "Изменение данных о сотруднике", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    // Написать условие для проверки того, что сотрудник выполняет заказ

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
    }
}

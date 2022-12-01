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
            if (employeeDataGridView.RowCount > 0) 
            {
                DisplayEmployeePhoto(0);
                employeeDataGridView.CurrentCell = employeeDataGridView.Rows[0].Cells["Фамилия"];
            }

            if (employee != null && state == 'A')        
                addLabel.Visible = true;
            
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
    }
}

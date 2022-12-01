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
        public AdminMenu()
        {
            InitializeComponent();
        }

        public AdminMenu(Employee employee) 
        {
            InitializeComponent();
            this.employee = employee;

        }

        private void AdminMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void inputButton_Click(object sender, EventArgs e)
        {
            FillEmployeeMenu fillEmployeeMenu = new FillEmployeeMenu();
            Transition.TransitionByForms(this, fillEmployeeMenu);
        }

        private void addEmployeeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (employee == null)
                    MessageBox.Show("Перед добавлением сотрудника необходимо ввести данные о нём", "Добавление сотрудника", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else 
                {
                    if (employee.AddEmployee() == 1)
                        MessageBox.Show("Запись успешно добавлена!", "Добавление сотрудника", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }

        private void employeeDataGridView_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void employeeDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Получаем фотографию сотрудника из бд и отображаем её в PictureBox
                byte[] photo = Employee.GetPhotoEmployeeByPhone(employeeDataGridView.Rows[e.RowIndex].Cells["Номер телефона"].Value.ToString());
                employeePictureBox.BackColor = SystemColors.Control;
                DisplayEmployeePhoto(photo);
            }
            catch 
            {
                MessageBox.Show("Ошибка отображения фотографии сотрудника", "Отображение фотографии сотрудника", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод перевода изображения из массива байт в Image и отображения полученного Image на форме
        /// </summary>
        /// <param name="photo">Изображение в виде массива байт</param>
        private void DisplayEmployeePhoto(byte[]photo) 
        {
            try
            {
                // Переводим изображение из массива байт в Image и отображаем в PictureBox
                MemoryStream stream = new MemoryStream(photo);
                employeePictureBox.Image = Image.FromStream(stream);
            }
            catch 
            {
                throw new Exception("Ошибка получения изображения");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}

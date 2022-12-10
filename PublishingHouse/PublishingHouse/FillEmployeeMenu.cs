using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PublishingHouse
{
    public partial class FillEmployeeMenu : Form
    {

        Employee employee = null;
        char state = ' ';
        int id = -1;

        public FillEmployeeMenu()
        {
            InitializeComponent();
        }

        public FillEmployeeMenu(char state) 
        {
            InitializeComponent();
            this.state = state;
        }

        public FillEmployeeMenu(Employee employee, char state) 
        {
            InitializeComponent();
            this.employee = employee;
            this.state = state;
        }

        private void FillEmployeeMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void backTab_Click(object sender, EventArgs e)
        {
            // Переходим в главное меню администратора
            EmployeeMenu adminMenu = new EmployeeMenu();
            Transition.TransitionByForms(this, adminMenu);
        }

        private void surnameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Если пользователь не ввел русскую букву, тире или не нажал на кнопку Backspace
            if (!Regex.Match(e.KeyChar.ToString(), @"[а-яА-Я-]").Success && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void addImageButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openDialog = new OpenFileDialog();
                openDialog.Filter = "ImageFiles(*.BMP; *.JPG; *.JPEG; *.PNG)| *.BMP; *.JPG; *.JPEG; *.PNG";

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    employeePictureBox.Image = new Bitmap(openDialog.FileName);
                }
            }
            catch 
            {
                MessageBox.Show("Ошибка загрузки фото", "Загрузка фото", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод проверки правильности введённых данных
        /// </summary>
        /// <returns>Правильно ли пользователь </returns>
        private bool CorrectInputData() 
        {

            if (surnameTextBox.Text == "" || nameTextBox.Text == "" || typeComboBox.Text == "" || !phoneTextBox.MaskFull || !CorrectInput.IsCorrectEmail(emailTextBox.Text) || DateTime.Compare(birthDayTimePicker.Value.Date, DateTime.Now.Date) >= 0)
                return false;
            else
                return true;
        }

        private void saveDataButton_Click(object sender, EventArgs e)
        {
            EmployeeMenu adminMenu = new EmployeeMenu();

            try
            {
                if (CorrectInputData())
                {

                    string email = "";
                    string phone = "";

                    if (state == 'C') 
                    {   
                        // Текущие данные о сотруднике
                        email = this.employee.Email;
                        phone = this.employee.Phone;
                    }
                    
                    // Если существует сотрудник с введенной электронной почтой или номером телефона
                    if (!Employee.ExistEmailInDb(state, email, emailTextBox.Text) && !Employee.ExistPhoneInDb(state, phone, phoneTextBox.Text)) 
                    {
                        // Создаём сотрудника
                        Employee employee = new Employee(nameTextBox.Text, surnameTextBox.Text, middleNameTextBox.Text, typeComboBox.Text, emailTextBox.Text, phoneTextBox.Text, birthDayTimePicker.Value.Date, WorkWithDataDgv.GetBytePhoto(employeePictureBox.Image));

                        if (state == 'A')
                            // Переходим в меню сотрудников
                            adminMenu = new EmployeeMenu(employee, state);

                        else if (state == 'C')
                            // Переходим в меню сотрудников
                            adminMenu = new EmployeeMenu(employee, state, id);


                        Transition.TransitionByForms(this, adminMenu);
                    }
                    else
                        MessageBox.Show("В базе данных не могут существовать сотрудники с одинаковым номером или с одинаковой электронной почтой", "Сохранение данных о сотруднике", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                    MessageBox.Show("Текстовые поля, за исключением отчества, должны быть заполнены! Если текстовые поля заполнены, то проверьте правильность Email. Дата рождения сотрудника должна быть меньше текущей даты", "Сохранение данных о сотруднике", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch 
            {
                MessageBox.Show("Ошибка ввода данных о сотруднике", "Сохранение данных о сотруднике", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        /// <summary>
        /// Метод для загрузки данных о сотруднике в соответствующие компоненты
        /// </summary>
        private void LoadDataAboutEmployee()
        {
            nameTextBox.Text = employee.Name;
            surnameTextBox.Text = employee.Surname;
            middleNameTextBox.Text = employee.Middlename;
            birthDayTimePicker.Value = employee.Birthday;
            typeComboBox.Text = employee.Type;
            emailTextBox.Text = employee.Email;
            phoneTextBox.Text = employee.Phone;
            employeePictureBox.Image = employee.PhotoAsImage;
        }

        private void FillEmployeeMenu_Load(object sender, EventArgs e)
        {
            try
            {
                if (employee != null && state == 'C')
                {
                    LoadDataAboutEmployee();
                    id = Employee.GetIdEmployeeByPhone(employee.Phone);
                }
            }
            catch 
            {
                MessageBox.Show("Произошла ошибка открытия формы для ввода данных о сотруднике", "Ввод данных о сотруднике", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

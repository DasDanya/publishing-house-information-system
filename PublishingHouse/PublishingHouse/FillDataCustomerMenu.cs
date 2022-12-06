using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PublishingHouse
{
    public partial class FillDataCustomerMenu : Form
    {
        Customer customer = null;
        int id = -1;
        char state = ' ';

        public FillDataCustomerMenu()
        {
            InitializeComponent();
        }

        public FillDataCustomerMenu(char state) 
        {
            InitializeComponent();
            this.state = state;
        }

        public FillDataCustomerMenu(Customer customer, char state) 
        {
            InitializeComponent();
            this.customer = customer;
            this.state = state;
        }

        private void FillDataCustomerMenu_Load(object sender, EventArgs e)
        {
            try
            {
                if (customer != null && state == 'C')
                {
                    LoadDataAboutCustomer();
                    id = Customer.GetIdCustomerByPhone(customer.Phone);
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка открытия формы для ввода данных о заказчике", "Ввод данных о заказчике", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод для загрузки данных о заказчике в соответствующие компоненты
        /// </summary>
        private void LoadDataAboutCustomer()
        {
            nameTextBox.Text = customer.Name;
            phoneTextBox.Text = customer.Phone;
            emailTextBox.Text = customer.Email;
        }

        private void FillDataCustomerMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void backTab_Click(object sender, EventArgs e)
        {
            CustomersMenu customerMenu = new CustomersMenu();
            Transition.TransitionByForms(this, customerMenu);
        }

        /// <summary>
        /// Метод проверки введённых данных
        /// </summary>
        /// <returns>Правильно ли введены данные</returns>
        private bool CorrectInputData()
        {
            if (nameTextBox.Text == "" || !phoneTextBox.MaskFull || emailTextBox.Text == "" || !CorrectInput.IsCorrectEmail(emailTextBox.Text))
            {
                return false;
            }
            else
                return true;
        }

        private void saveDataButton_Click(object sender, EventArgs e)
        {
            CustomersMenu customersMenu = new CustomersMenu();

            try
            {
                // Если пользователь ввёл корректные данные
                if (CorrectInputData())
                {
                    // Создаём заказчика
                    Customer customer = new Customer(nameTextBox.Text, emailTextBox.Text, phoneTextBox.Text);

                    if (state == 'A')
                        // Возвращаемся в меню заказчиков
                        customersMenu = new CustomersMenu(customer, state);



                    Transition.TransitionByForms(this, customersMenu);
                }
                else
                    MessageBox.Show("Текстовые поля должны быть заполнены! Проверьте правильность ввода электронной почты", "Сохранение данных о заказчике", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch 
            {
                MessageBox.Show("Ошибка сохранения данных о заказчике", "Сохранение данных о заказчике", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

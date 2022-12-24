using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PublishingHouse
{
    public partial class FillDataPrintingHouse : Form
    {

        PrintingHouse printingHouse = null;
        char state = ' ';
        int id = -1;
        public FillDataPrintingHouse()
        {
            InitializeComponent();
        }

        public FillDataPrintingHouse(char state) 
        {
            InitializeComponent();
            this.state = state;
        }
        public FillDataPrintingHouse(PrintingHouse printingHouse, char state)
        {
            InitializeComponent();
            this.printingHouse = printingHouse;
            this.state = state;
        }

        private void FillDataPrintingHouse_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void backTab_Click(object sender, EventArgs e)
        {
            PrintingHouseMenu printingHouseMenu = new PrintingHouseMenu();
            Transition.TransitionByForms(this, printingHouseMenu);
        }

        private void FillDataPrintingHouse_Load(object sender, EventArgs e)
        {
            try
            {
                if (printingHouse != null)
                {
                    LoadDataAboutPrintingHouse();
                    id = PrintingHouse.GetIdPrintingHouseByEmail(printingHouse.Email);
                }
            }
            catch 
            {
                MessageBox.Show("Ошибка загрузки данных", "Ошибка стартовых данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод для загрузки данных о типографии в соответствующие поля
        /// </summary>
        private void LoadDataAboutPrintingHouse()
        {
            nameTextBox.Text = printingHouse.Name;
            phoneNumberTextBox.Text = printingHouse.NumberPhone;
            emailTextBox.Text = printingHouse.Email;
            typesOfStateComboBox.Text = printingHouse.TypeState;
            stateTextBox.Text = printingHouse.NameState;
            cityTextBox.Text = printingHouse.City;
            typesStreetComboBox.Text = printingHouse.TypeStreet;
            streetTextBox.Text = printingHouse.NameStreet;
            houseTextBox.Text = printingHouse.NumberHouse;


        }

        /// <summary>
        /// Метод проверки введённых данных
        /// </summary>
        /// <returns>Правильно ли введены данные</returns>
        private bool CorrectInputData() 
        {
            if (nameTextBox.Text == "" || !phoneNumberTextBox.MaskFull || !CorrectInput.IsCorrectEmail(emailTextBox.Text) || typesOfStateComboBox.Text == ""|| !CorrectInput.CheckNameOfStateOrCity(stateTextBox.Text)
                || !CorrectInput.CheckNameOfStateOrCity(cityTextBox.Text) || typesStreetComboBox.Text == "" || streetTextBox.Text == "" || !CorrectInput.IsCorrectNumberOfHouse(houseTextBox.Text))
            {
                return false;
            }
            else
                return true;
        }

        private void saveInputButton_Click(object sender, EventArgs e)
        {
            PrintingHouseMenu printingHouseMenu = new PrintingHouseMenu();
            try
            {
                // Если пользователь ввёл корректные данные
                if (CorrectInputData())
                {
                    string pastEmail = "";
                    string pastPhone = "";
                    string pastName = "";

                    // Если пользователь изменяет данные
                    if (state == 'C')
                    {
                        pastEmail = this.printingHouse.Email;
                        pastPhone = this.printingHouse.NumberPhone;
                        pastName = this.printingHouse.Name;
                    }

                    // Если email, номера телефона и названия не существует в бд
                    if (!PrintingHouse.ExistEmailInDb(state, pastEmail, emailTextBox.Text) && !PrintingHouse.ExistPhoneInDb(state, pastPhone, phoneNumberTextBox.Text) && !PrintingHouse.ExistNameOfPrintingHouseInDb(state, pastName, nameTextBox.Text))
                    {

                        // Создаём типографию
                        PrintingHouse printingHouse = new PrintingHouse(nameTextBox.Text, phoneNumberTextBox.Text, emailTextBox.Text, typesOfStateComboBox.Text, CorrectOutput.CorrectStateOrCity(stateTextBox.Text),
                            CorrectOutput.CorrectStateOrCity(cityTextBox.Text), typesStreetComboBox.Text, streetTextBox.Text, houseTextBox.Text.Replace(" ", ""));

                        if (state == 'A')
                            // Возвращаемся в меню типографий
                            printingHouseMenu = new PrintingHouseMenu(printingHouse, state);

                        else if (state == 'C')                       
                            // Возвращаемся в меню типографий
                            printingHouseMenu = new PrintingHouseMenu(printingHouse, state, id);
                           

                            Transition.TransitionByForms(this, printingHouseMenu);
                    }
                    else
                    {
                        MessageBox.Show("В базе данных не могут существовать типографии с одинаковым названием или с одинаковым номером телефона или с одинаковой электронной почтой", "Заполнение данных о типографии", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }


                }
                else
                    MessageBox.Show("Все поля должны быть заполнены. Проверьте правильность ввода названия типографии, субъекта, города," +
                        " номера дома или электронной почты", "Заполнение данных о типографии", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
                MessageBox.Show("Произошла ошибка ввода данных о типографии", "Ввод данных о типографии", MessageBoxButtons.OK, MessageBoxIcon.Error);    
            }
        }

        private void stateTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Если пользователь не ввел русскую букву, тире или не нажал на кнопку Backspace
            if (!Regex.Match(e.KeyChar.ToString(), @"[а-яА-Я-]").Success && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void streetTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.Match(e.KeyChar.ToString(), @"[а-яА-Я-0-9]").Success && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}

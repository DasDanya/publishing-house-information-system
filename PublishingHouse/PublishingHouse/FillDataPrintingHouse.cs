using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PublishingHouse
{
    public partial class FillDataPrintingHouse : Form
    {
        public FillDataPrintingHouse()
        {
            InitializeComponent();
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
            //Загружаем иконки для вкладок
            IconImage.LoadIconBackTab(backTab);
        }

        /// <summary>
        /// Метод проверки введённых данных
        /// </summary>
        /// <returns>Правильно ли введены данные</returns>
        private bool CorrectInputData() 
        {
            if (nameTextBox.Text == "" || !phoneNumberTextBox.MaskFull || !CorrentInput.IsCorrectEmail(emailTextBox.Text) || typesOfStateComboBox.Text == ""|| !CorrentInput.CheckNameOfStateOrCity(stateTextBox.Text)
                || !CorrentInput.CheckNameOfStateOrCity(cityTextBox.Text) || typesStreetComboBox.Text == "" || streetTextBox.Text == "" || !CorrentInput.IsCorrectNumberOfHouse(houseTextBox.Text))
            {
                return false;
            }
            else
                return true;


        }

        private void saveInputButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CorrectInputData())
                    MessageBox.Show("ok");
                else
                    MessageBox.Show("Все поля должны быть заполнены. Проверьте правильность ввода названия субъекта, города," +
                        " номера дома или электронной почты", "Заполнение данных о типографии", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch 
            {
                MessageBox.Show("Проверьте правильность ввода названия субъекта, города," +
                        " номера дома или электронной почты", "Заполнение данных о типографии", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
}
    }
}

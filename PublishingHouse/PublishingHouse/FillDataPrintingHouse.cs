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
            if (nameTextBox.Text != "" && phoneNumberTextBox.MaskCompleted && CorrentInput.IsCorrectEmail(emailTextBox.Text) && CorrentInput.CheckNameOfStateOrCity(stateTextBox.Text)
                && CorrentInput.CheckNameOfStateOrCity(cityTextBox.Text) && typesStreetComboBox.Text != "" && streetTextBox.Text != "" && CorrentInput.IsCorrectNumberOfHouse(houseTextBox.Text))
            {
                return true;
            }
            else
                return false;
        }

        private void saveInputButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CorrectInputData())
                    MessageBox.Show("ok");
                else
                    MessageBox.Show("Все поля должны быть заполнены. В названии субъектов и городов должны присутствовать только русские буквы и знак тире. Проверьте правильность" +
                        " ввода номера дома", "Заполнение данных о типографии", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch 
            {
                MessageBox.Show("Неправильный ввод электронной почты", "Заполнение данных о типографии", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

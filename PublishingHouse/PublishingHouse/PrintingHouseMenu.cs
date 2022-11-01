using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Linq;
using System.Text.RegularExpressions;

namespace PublishingHouse
{
    public partial class PrintingHouseMenu : Form
    {
        public PrintingHouseMenu()
        {
            InitializeComponent();
        }

        private void PrintingHouseMenu_Load(object sender, EventArgs e)
        {
            //Загружаем иконки для вкладок
            IconImage.LoadIconsOfMaterialTab(backTab);
        }

        private void backTab_Click(object sender, EventArgs e)
        {
            // Переход к основному меню
            MainMenu mainMenu = new MainMenu();
            Transition.TransitionByForms(this, mainMenu);
        }

        private void PrintingHouseMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            CorrectInputData();
        }

        /// <summary>
        /// Метод проверки правильности введенных данных
        /// </summary>
        private void CorrectInputData() 
        {
            //if (nameTextBox.Text == "" || !phoneNumberTextBox.MaskCompleted || !IsCorrectEmail(emailTextBox.Text) || !IsCorrectPartOfAddress(stateTextBox.Text)
            //    || !IsCorrectPartOfAddress(cityTextBox.Text) || !IsCorrectPartOfAddress(stateTextBox.Text) || !IsCorrectNumberOfHouse(houseTextBox.Text))

            

            
        }

        /// <summary>
        /// Метод проверки электронной почты на корректность
        /// </summary>
        /// <param name="email">Электронная почта</param>
        /// <returns>Корректна ли электронная почта</returns>
        private bool IsCorrectEmail(string email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        
        /// <summary>
        /// Метод проверки части адреса на корректность
        /// </summary>
        /// <param name="part">Часть адреса</param>
        /// <returns>Корректна ли часть адреса</returns>
        private bool IsCorrectPartOfAddress(string part) 
        {
            if (part.All(Char.IsLetter) && part != "" && Regex.IsMatch(part, "^[А-Яа-я]+$"))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Метод проверки номера дома на корректность
        /// </summary>
        /// <param name="house">Номер дома</param>
        /// <returns>Корректен ли номер дома</returns>
        private bool IsCorrectNumberOfHouse(string house) 
        {
            if (Regex.IsMatch(house, @"^[1-9]\d*(?: ?(?:[А-Га-г]|[/] ?\d+))?$"))
                return true;
            else
                return false;
        }
    }
}

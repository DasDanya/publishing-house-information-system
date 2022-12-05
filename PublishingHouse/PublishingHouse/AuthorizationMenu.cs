using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace PublishingHouse
{
    public partial class AuthorizationMenu : Form
    {
        Authorization authorization = null;
        public AuthorizationMenu()
        {
            InitializeComponent();
        }

        private void authorizationButton_Click(object sender, EventArgs e)
        {
            if (loginTextBox.Text != "" && passwordTextBox.Text != "")
            {
                authorization = new Authorization(loginTextBox.Text, passwordTextBox.Text);
                string login = authorization.UserAuthorization();

                if (login == "user")
                {
                    MainMenu mainMenu = new MainMenu();
                    Transition.TransitionByForms(this, mainMenu);
                }                
                else
                    MessageBox.Show("Неправильный логин или пароль!", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show("Необходимо ввести логин и пароль!", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void AuthorizationMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void hidePasswordButton_Click(object sender, EventArgs e)
        {
            // Если пользователь видит пароль
            if (passwordTextBox.PasswordChar == '\0') 
            {
                // Показываем кнопку для открытия пароля
                openPasswordButton.BringToFront();

                // Скрываем пароль
                passwordTextBox.PasswordChar = '*';
            }
        }

        private void openPasswordButton_Click(object sender, EventArgs e)
        {
            // Если пользователь не видит пароль
            if (passwordTextBox.PasswordChar == '*') 
            {
                // Показываем кнопку для скрытия пароля
                hidePasswordButton.BringToFront();

                // Показываем пароль
                passwordTextBox.PasswordChar = '\0';
            }
        }
    }
}

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
    public partial class FillEmployeeMenu : Form
    {
        public FillEmployeeMenu()
        {
            InitializeComponent();
        }

        private void FillEmployeeMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void backTab_Click(object sender, EventArgs e)
        {
            // Переходим в главное меню администратора
            AdminMenu adminMenu = new AdminMenu();
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
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "ImageFiles(*.BMP; *.JPG; *.JPEG; *.PNG)| *.BMP; *.JPG; *.JPEG; *.PNG";

            if (openDialog.ShowDialog() == DialogResult.OK) 
            {
                employeePictureBox.Image = new Bitmap(openDialog.FileName);
            }
        }
    }
}

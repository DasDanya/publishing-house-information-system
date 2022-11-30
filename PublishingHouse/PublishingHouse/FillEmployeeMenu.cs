using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
    }
}

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
        public AdminMenu()
        {
            InitializeComponent();
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
    }
}

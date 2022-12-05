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

        private void FillDataCustomerMenu_Load(object sender, EventArgs e)
        {

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
    }
}

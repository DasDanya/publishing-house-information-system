using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PublishingHouse
{
    public partial class CustomersMenu : Form
    {
        public CustomersMenu()
        {
            InitializeComponent();
        }

        private void backTab_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            Transition.TransitionByForms(this, mainMenu);
        }

        private void CustomersMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void processingTab_Click(object sender, EventArgs e)
        {
            inputDataButton.Visible = true;
            addButton.Visible = true;
            selectForChangeButton.Visible = true;
            resetAddOrChangeButton.Visible = true;
            deleteButton.Visible = true;
            changeButton.Visible = true;
            selectAllRowsButton.Visible = false;
            resetSelectRowsButton.Visible = false;
            ordersTreeView.Visible = false;
            fashionCustomersButton.Visible = false;
            getOrdersButton.Visible = false;
            columnLabel.Visible = false;
            columnsComboBox.Visible = false;
            dataAboutCustomerLabel.Visible = false;
            searchTextBox.Visible = false;
        }

        private void searchTab_Click(object sender, EventArgs e)
        {
            inputDataButton.Visible = false;
            addButton.Visible = false;
            selectForChangeButton.Visible = false;
            resetAddOrChangeButton.Visible = false;
            deleteButton.Visible = false;
            changeButton.Visible = false;
            selectAllRowsButton.Visible = false;
            resetSelectRowsButton.Visible = false;
            ordersTreeView.Visible = true;
            fashionCustomersButton.Visible = true;
            getOrdersButton.Visible = true;
            columnLabel.Visible = true;
            columnsComboBox.Visible = true;
            dataAboutCustomerLabel.Visible = true;
            searchTextBox.Visible = true;
        }

        private void selectTab_Click(object sender, EventArgs e)
        {
            inputDataButton.Visible = false;
            addButton.Visible = false;
            selectForChangeButton.Visible = false;
            resetAddOrChangeButton.Visible = false;
            deleteButton.Visible = false;
            changeButton.Visible = false;
            selectAllRowsButton.Visible = true;
            resetSelectRowsButton.Visible = true;
            ordersTreeView.Visible = false;
            fashionCustomersButton.Visible = false;
            getOrdersButton.Visible = false;
            columnLabel.Visible = false;
            columnsComboBox.Visible = false;
            dataAboutCustomerLabel.Visible = false;
            searchTextBox.Visible = false;
        }

        private void selectForChangeButton_Click(object sender, EventArgs e)
        {

        }

        private void resetAddOrChangeButton_Click(object sender, EventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }

        private void changeButton_Click(object sender, EventArgs e)
        {

        }

        private void selectAllRowsButton_Click(object sender, EventArgs e)
        {

        }

        private void resetSelectRowsButton_Click(object sender, EventArgs e)
        {

        }

        private void inputDataButton_Click(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {

        }

        private void getOrdersButton_Click(object sender, EventArgs e)
        {

        }

        private void fashionCustomersButton_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PublishingHouse
{
    public partial class TypesProductMenu : Form
    {
        public TypesProductMenu()
        {
            InitializeComponent();
        }

        private void backTab_Click(object sender, EventArgs e)
        {
            ProductMenu productMenu = new ProductMenu();
            Transition.TransitionByForms(this, productMenu);
        }

        private void TypesProductMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void inputDataButton_Click(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {

        }

        private void selectForChangeButton_Click(object sender, EventArgs e)
        {

        }

        private void restAddOrChangeButton_Click(object sender, EventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }

        private void changeButton_Click(object sender, EventArgs e)
        {

        }

        private void processingTab_Click(object sender, EventArgs e)
        {
            addButton.Visible = true;
            inputDataButton.Visible = true;
            addTypeLabel.Visible = true;
            changeTypeLabel.Visible = true;
            selectForChangeButton.Visible = true;
            restAddOrChangeButton.Visible = true;
            deleteButton.Visible = true;
            changeButton.Visible = true;
            productsTreeView.Visible = false;
            getProductsButton.Visible = false;
            fashionTypesButton.Visible = false;
            columnsLabel.Visible = false;
            columnsComboBox.Visible = false;
            searchTypeLabel.Visible = false;
            searchTextBox.Visible = false;
            selectAllRowsButton.Visible = false;
            resetSelectRowsButton.Visible = false;
        }

        private void searchTab_Click(object sender, EventArgs e)
        {
            addButton.Visible = false;
            inputDataButton.Visible = false;
            addTypeLabel.Visible = false;
            changeTypeLabel.Visible = false;
            selectForChangeButton.Visible = false;
            restAddOrChangeButton.Visible = false;
            deleteButton.Visible = false;
            changeButton.Visible = false;
            productsTreeView.Visible = true;
            getProductsButton.Visible = true;
            fashionTypesButton.Visible = true;
            columnsLabel.Visible = true;
            columnsComboBox.Visible = true;
            searchTypeLabel.Visible = true;
            searchTextBox.Visible = true;
            selectAllRowsButton.Visible = false;
            resetSelectRowsButton.Visible = false;

            // Устанавливаем значения и свойства полям для поиска
            WorkWithDataDgv.SetElementsForSearchStringData(typesProductDataGridView, columnsComboBox, searchTextBox);
        }

        private void selectTab_Click(object sender, EventArgs e)
        {
            addButton.Visible = false;
            inputDataButton.Visible = false;
            addTypeLabel.Visible = false;
            changeTypeLabel.Visible = false;
            selectForChangeButton.Visible = false;
            restAddOrChangeButton.Visible = false;
            deleteButton.Visible = false;
            changeButton.Visible = false;
            productsTreeView.Visible = false;
            getProductsButton.Visible = false;
            fashionTypesButton.Visible = false;
            columnsLabel.Visible = false;
            columnsComboBox.Visible = false;
            searchTypeLabel.Visible = false;
            searchTextBox.Visible = false;
            selectAllRowsButton.Visible = true;
            resetSelectRowsButton.Visible = true;
        }
    }
}

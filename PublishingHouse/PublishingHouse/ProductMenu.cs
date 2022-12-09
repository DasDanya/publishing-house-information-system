using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PublishingHouse
{
    public partial class ProductMenu : Form
    {
        public ProductMenu()
        {
            InitializeComponent();
        }

        private void ProductMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void backTab_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            Transition.TransitionByForms(this, mainMenu);
        }

        private void typesProductButton_Click(object sender, EventArgs e)
        {
            TypesProductMenu typesProductMenu = new TypesProductMenu();
            Transition.TransitionByForms(this, typesProductMenu);
        }

        private void inputDataButton_Click(object sender, EventArgs e)
        {
            // Переходим в меню ввода данных о печатной продукции
            FillDataProduct fillDataProduct = new FillDataProduct('A');
            Transition.TransitionByForms(this, fillDataProduct);
        }
    }
}

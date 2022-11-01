using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
            MainMenu mainMenu = new MainMenu();
            Transition.TransitionByForms(this, mainMenu);
        }


    }
}

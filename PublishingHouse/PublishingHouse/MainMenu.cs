using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PublishingHouse
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }


       
        private void MainMenu_Load(object sender, EventArgs e)
        {
            IconImage.LoadIconsOfMainTab(employeeTab, materialTab); // загружаем иконки на вкладки
            
        }

        

        private void employeeTab_Click(object sender, EventArgs e)
        {
            EmployeesMenu employeesMenu = new EmployeesMenu();
            Transition.TransitionByForms(this, employeesMenu); // Переход между формами
           
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ConnectionToDb.Close();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void materialTab_Click(object sender, EventArgs e)
        {
            MaterialMenu materialMenu = new MaterialMenu();
            Transition.TransitionByForms(this, materialMenu); // Переход между формами
        }
    }
}

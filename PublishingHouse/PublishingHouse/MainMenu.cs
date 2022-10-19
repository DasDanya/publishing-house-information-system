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
            IconImage.LoadIconsOfMainTab(employeeTab); // загружаем иконки на вкладки
            try
            {
                ConnectionToDb.Open();
                MessageBox.Show("Nice");
            }
            catch (Exception ex) {

                MessageBox.Show("bad");
            }
        }

        

        private void employeeTab_Click(object sender, EventArgs e)
        {

            EmployeesMenu employeesMenu = new EmployeesMenu();
            employeesMenu.Show();

            employeesMenu.FormClosed += (sender, e) => this.Show(); // при закрытии формы со сотрудниками откроется главное меню
            this.Hide();
           
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConnectionToDb.Close();
        }
    }
}

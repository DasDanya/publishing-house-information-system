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
        Product product = null;
        char state = ' ';
        int id = -1;

        public ProductMenu()
        {
            InitializeComponent();
        }

        public ProductMenu(Product product, char state) 
        {
            InitializeComponent();
            this.product = product;
            this.state = state;
        }

        public ProductMenu(Product product, char state, int id)
        {
            InitializeComponent();
            this.product = product;
            this.state = state;
            this.id = id;
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

        private void ProductMenu_Load(object sender, EventArgs e)
        {
            try
            {
                //LoadTable();

                // Если пользователь добавляет запись
                if (product != null && state == 'A')
                    addLabel.Text = "Вы можете добавить запись";

                // Если пользователь изменяет запись
                else if (product != null && state == 'C')
                {
                    addButton.Enabled = false;
                    deleteButton.Enabled = false;
                    changeButton.Enabled = true;

                    changeLabel.Text = "Вы можете изменить запись";
                }
            }
            catch
            {
                MessageBox.Show("Ошибка отображения стартовых данных", "Отображение стартовых данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (product == null || state != 'A')
                    MessageBox.Show("Перед добавлением печатной продукции необходимо ввести данные о ней", "Добавление печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    if (product.AddProduct() == 1)
                    {
                        MessageBox.Show("Запись успешно добавлена!", "Добавление печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Выводим новые данные и делаем комноненты и переменные в состояние по умолчанию
                        //ReloadData();
                        //DefaultStateOfMenu();


                    }
                    else
                        MessageBox.Show("Количество добавленных записей не равно должному количеству", "Добавление печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Ошибка добавления печатной продукции", "Добавление печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

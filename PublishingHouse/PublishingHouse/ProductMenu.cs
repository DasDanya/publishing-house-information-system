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
                LoadTable();

                // Отображаем макет первой печатной продукции
                DisplayStartPhoto();

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
                        ReloadData();
                        DefaultStateOfMenu();
                        DisplayStartPhoto();

                    }
                    else
                        MessageBox.Show("Количество добавленных записей не равно должному количеству", "Добавление печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch
            {
                MessageBox.Show("Ошибка добавления печатной продукции", "Добавление печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод очистки значений для буфферных переменных
        /// </summary>
        private void ClearBuffer()
        {
            product = null;
            state = ' ';
            id = -1;
        }

        /// <summary>
        /// Метод,который приводит компоненты и переменные в состояние по умолчанию
        /// </summary>
        private void DefaultStateOfMenu()
        {
            ClearBuffer();
            addLabel.Text = "";
            changeLabel.Text = "";
            addButton.Enabled = true;
            deleteButton.Enabled = true;
            changeButton.Enabled = false;

        }

        private void resetAddOrChangeButton_Click(object sender, EventArgs e)
        {
            // Приводим буфферные данные и компоненты в состояние по умолчанию
            DefaultStateOfMenu();
        }

        /// <summary>
        /// Метод загрузки данных в таблицу
        /// </summary>
        private void LoadTable()
        {
            // Загружаем данные о сотрудниках в таблицу
            Product.LoadProductsInTable(productDataGridView);
            WorkWithDataDgv.SetReadOnlyColumns(productDataGridView);
            productDataGridView.Columns[1].Width = 200;
            productDataGridView.Columns[2].Width = 180;
        }

        /// <summary>
        /// Метод вывода новых данных из бд
        /// </summary>
        private void ReloadData()
        {
            // Удаляем все строки из таблицы
            while (productDataGridView.Rows.Count != 0)
            {
                productDataGridView.Rows.Remove(productDataGridView.Rows[productDataGridView.Rows.Count - 1]);
            }

            // Загружаем новые данные
            LoadTable();

        }

        private void productDataGridView_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        /// <summary>
        /// Метод отображения макета печатной продукции
        /// </summary>
        /// <param name="rowIndex">Номер строки в таблице</param>
        private void DisplayProductPhoto(int rowIndex)
        {
            try
            {

                productPictureBox.BackColor = SystemColors.Control;
                productPictureBox.Image = Product.GetPhotoAsImage(productDataGridView.Rows[rowIndex].Cells["Название"].Value.ToString(), Convert.ToInt32(productDataGridView.Rows[rowIndex].Cells["Номер тиража"].Value));
            }
            catch
            {
                throw new Exception("Ошибка получения изображения");
            }
        }

        private void productDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Исключаем заголовок DataGridView
                if (e.RowIndex > -1)
                    // Получаем макет печатной продукции из бд и отображаем её в PictureBox
                    DisplayProductPhoto(e.RowIndex);

            }
            catch
            {
                MessageBox.Show("Ошибка отображения макета печатной продукции", "Отображение макета печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод отображения фото первой печатной продукции
        /// </summary>
        private void DisplayStartPhoto()
        {
            try
            {
                // Отображаем изображение первого сотрудника
                if (productDataGridView.RowCount >= 1)
                {
                    DisplayProductPhoto(0);
                    productDataGridView.CurrentCell = productDataGridView.Rows[0].Cells["Название"];
                }
            }
            catch
            {
                MessageBox.Show("Ошибка отображения стартого изображения", "Отображение стартового изображения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}

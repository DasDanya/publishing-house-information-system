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
        TypeProduct typeProduct = null;
        char state = ' ';
        int id = -1;

        public TypesProductMenu()
        {
            InitializeComponent();
        }

        public TypesProductMenu(TypeProduct typeProduct, char state)
        {
            InitializeComponent();
            this.typeProduct = typeProduct;
            this.state = state;
        }

        public TypesProductMenu(TypeProduct typeProduct, char state, int id)
        {
            InitializeComponent();
            this.typeProduct = typeProduct;
            this.state = state;
            this.id = id;
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
            // Переходим в меню для ввода данных
            FillDataTypeProduct fillDataTypeProduct = new FillDataTypeProduct('A');
            Transition.TransitionByForms(this, fillDataTypeProduct);
        }

        /// <summary>
        /// Метод очистки значений для буфферных переменных
        /// </summary>
        private void ClearBuffer()
        {
            typeProduct = null;
            state = ' ';
            id = -1;
        }

        /// <summary>
        /// Метод,который приводит компоненты и переменные в состояние по умолчанию
        /// </summary>
        private void DefaultStateOfMenu()
        {
            ClearBuffer();
            addTypeLabel.Text = "";
            changeTypeLabel.Text = "";
            addButton.Enabled = true;
            deleteButton.Enabled = true;
            changeButton.Enabled = false;

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (typeProduct == null || state != 'A')
                    MessageBox.Show("Перед добавлением типа печатной продукции необходимо ввести данные о нём", "Добавление типа печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    if (typeProduct.AddTypeProduct() == 1)
                    {
                        MessageBox.Show("Запись успешно добавлена!", "Добавление типа печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Выводим новые данные и делаем комноненты и переменные в состояние по умолчанию
                        ReloadData();
                        DefaultStateOfMenu();


                    }
                    else
                        MessageBox.Show("Количество добавленных записей не равно единице", "Добавление типа печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch
            {
                MessageBox.Show("Ошибка добавления типа печатной продукции", "Добавление типа печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void selectForChangeButton_Click(object sender, EventArgs e)
        {

        }

        private void restAddOrChangeButton_Click(object sender, EventArgs e)
        {
            // Приводим буфферные данные и компоненты в состояние по умолчанию
            DefaultStateOfMenu();

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

        private void TypesProductMenu_Load(object sender, EventArgs e)
        {
            try
            {
                LoadTable();

                // Если пользователь добавляет запись
                if (typeProduct != null && state == 'A')
                    addTypeLabel.Text = "Вы можете добавить запись";

                // Если пользователь изменяет запись
                else if (typeProduct != null && state == 'C')
                {
                    addButton.Enabled = false;
                    deleteButton.Enabled = false;
                    changeButton.Enabled = true;

                    changeTypeLabel.Text = "Вы можете изменить запись";
                }
            }
            catch
            {
                MessageBox.Show("Ошибка отображения стартовых данных", "Отображение стартовых данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        /// <summary>
        /// Метод вывода новых данных из бд
        /// </summary>
        private void ReloadData()
        {
            // Удаляем все строки из таблицы
            while (typesProductDataGridView.Rows.Count != 0)
            {
                typesProductDataGridView.Rows.Remove(typesProductDataGridView.Rows[typesProductDataGridView.Rows.Count - 1]);
            }

            // Загружаем новые данные
            LoadTable();

        }

        /// <summary>
        /// Метод загрузки данных
        /// </summary>
        private void LoadTable()
        {
            // Загружаем данные о типах печатной продукции в таблицу
            TypeProduct.LoadTypesProducts(typesProductDataGridView);
            WorkWithDataDgv.SetReadOnlyColumns(typesProductDataGridView);

            typesProductDataGridView.Columns["Тип печатной продукции"].Width = 440;
            typesProductDataGridView.Columns["Наценка в %"].Width = 220;

        }

        private void typesProductDataGridView_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}

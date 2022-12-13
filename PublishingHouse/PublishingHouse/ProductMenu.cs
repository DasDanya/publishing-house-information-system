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

        private void selectAllRowsButton_Click(object sender, EventArgs e)
        {
            if (productDataGridView.Rows.Count < 1)
                MessageBox.Show("Отсутствуют строки для выбора", "Выбрать всё", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                WorkWithDataDgv.SelectOrCancelSelectAllRows(productDataGridView, true);
        }

        private void resetSelectRowsButton_Click(object sender, EventArgs e)
        {
            if (productDataGridView.Rows.Count < 1)
                MessageBox.Show("Отсутствуют строки", "Отменить выбор строк", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                WorkWithDataDgv.SelectOrCancelSelectAllRows(productDataGridView, false);
        }

        private void selectForChangeButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Если количество выбранный записей не равно 1
                if (WorkWithDataDgv.CountSelectedRows(productDataGridView) != 1)
                    MessageBox.Show("Неодходимо выбрать одну запись", "Выбор записи для её изменения", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    int numberRow = WorkWithDataDgv.NumberSelectedRows(productDataGridView);
                    int id = Product.GetIdProduct(productDataGridView.Rows[numberRow].Cells["Название"].Value.ToString(), Convert.ToInt32(productDataGridView.Rows[numberRow].Cells["Номер тиража"].Value));
                    if (!Product.ProductIsSpecified(id))
                    {

                        //Cоздаём объект печатной продукции              
                        Product product = new Product(productDataGridView.Rows[numberRow].Cells["Название"].Value.ToString(), Convert.ToInt32(productDataGridView.Rows[numberRow].Cells["Номер тиража"].Value), Convert.ToInt32(productDataGridView.Rows[numberRow].Cells["Тираж"].Value),
                            TypeProduct.GetIdTypeProduct(id), Product.GetPhotoAsImage(productDataGridView.Rows[numberRow].Cells["Название"].Value.ToString(), Convert.ToInt32(productDataGridView.Rows[numberRow].Cells["Номер тиража"].Value)), Material.GetListMaterials(id));

                        // Переходим в меню ввода данных для изменения этих самых данных
                        FillDataProduct fillDataProduct = new FillDataProduct(product, 'C');
                        Transition.TransitionByForms(this, fillDataProduct);
                    }
                    else
                        MessageBox.Show("Невозможно изменить запись, так как существует заказ(-ы), где указана печатная продукция. Удалите заказ(-ы), где указана печатная продукция, или создайте новую печатную продукцию", "Выбор записи для её изменения", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка выбора записи для её изменения", "Выбор записи для её изменения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Если пользователь изменяет запись
                if (MessageBox.Show("Вы точно хотите изменить запись?", "Изменение данных о печатной продукции", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
             
                    // Если изменилась только выбранная запись
                    if (product.ChangeProduct(id) == 1)
                        MessageBox.Show("Запись успешно изменена!", "Изменение данных о печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Количество измененных записей не равно ожидаемому количеству изменяемых записей", "Изменение данных о печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    // Выводим новые данные и делаем комноненты и переменные в состояние по умолчанию
                    ReloadData();
                    DefaultStateOfMenu();
                    DisplayStartPhoto();

                }
            }
            catch
            {
                MessageBox.Show("Ошибка изменения данных о печатной продукции", "Изменение данных о печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Если пользователь выбрал 0 записей
                if (WorkWithDataDgv.CountSelectedRows(productDataGridView) < 1)
                    MessageBox.Show("Неодходимо выбрать одну или несколько записей", "Удаление печатных продукций", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    // Если пользователь соглашается на удаление записи(-ей)
                    if (MessageBox.Show("Вы точно хотите удалить эту(-и) запись(-и)?", "Удаление печатных продукций", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        // Получаем массив id
                        int[] arrayId = Product.GetArrayIdProducts(productDataGridView, WorkWithDataDgv.GetListIndexesSelectedRows(productDataGridView));

                        // Если печатная продукция(-ии) не упоминается(-ются) ни в одном заказе 
                        if (!Product.ProductsAreSpecified(arrayId))
                        {
                            // Если мы удалили указанное количество записей                          
                            if (Product.DeleteProducts(arrayId) == arrayId.Length)
                            {
                                MessageBox.Show("Записи успешно удалены!", "Удаление печатных продукций", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ReloadData();
                                DisplayStartPhoto();

                                // Очищаем поле для макета печатной продукции, если таблица пустая
                                if (productDataGridView.RowCount < 1)
                                    WorkWithDataDgv.EmptyPictureBox(productPictureBox);
                             
                            }
                            else
                            {
                                MessageBox.Show("Количество удаленных записей не совпадает с ожидаемым количеством", "Удаление печатных продукций", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            
                        }
                        else
                            MessageBox.Show("Невозможно удалить запись(-и), так как существует заказ(-ы), где указана выбранная печатная продукция. Удалите заказ(-ы), где указана выбранная печатная продукция, и повторите попытку", "Удаление печатных продукций", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
            }
            catch
            {

                MessageBox.Show("Произошла ошибка удаления печатных продукций", "Удаление печатных продукций", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchTab_Click(object sender, EventArgs e)
        {
            inputDataButton.Visible = false;
            addButton.Visible = false;
            addLabel.Visible = false;
            selectForChangeButton.Visible = false;
            resetAddOrChangeButton.Visible = false;
            deleteButton.Visible = false;
            changeLabel.Visible = false;
            changeButton.Visible = false;
            selectAllRowsButton.Visible = false;
            resetSelectRowsButton.Visible = false;
            ordersTreeView.Visible = true;
            searchOrdersButton.Visible = true;
            outputAllDataButton.Visible = true;
            firstColumnsLabel.Visible = true;
            numbersComboBox.Visible = true;
            fromLabel.Visible = true;
            fromTextBox.Visible = true;
            toLabel.Visible = true;
            toTextBox.Visible = true;
            getNumbersDataButton.Visible = true;
            resetSearchButton.Visible = true;
            secondLabel.Visible = true;
            stringComboBox.Visible = true;
            stringLabel.Visible = true;
            searchStringTextBox.Visible = true;

            // Устанавливаем значения и свойства полям для поиска
            WorkWithDataDgv.SetElementsForSearchStringData(productDataGridView, stringComboBox, searchStringTextBox);
            WorkWithDataDgv.SetRowOfIntComboBox(productDataGridView, numbersComboBox, fromTextBox, toTextBox);
            
        }

        private void processingTab_Click(object sender, EventArgs e)
        {
            inputDataButton.Visible = true;
            addButton.Visible = true;
            addLabel.Visible = true;
            selectForChangeButton.Visible = true;
            resetAddOrChangeButton.Visible = true;
            deleteButton.Visible = true;
            changeLabel.Visible = true;
            changeButton.Visible = true;
            selectAllRowsButton.Visible = true;
            resetSelectRowsButton.Visible = true;
            ordersTreeView.Visible = false;
            searchOrdersButton.Visible = false;
            outputAllDataButton.Visible = false;
            firstColumnsLabel.Visible = false;
            numbersComboBox.Visible = false;
            fromLabel.Visible = false;
            fromTextBox.Visible = false;
            toLabel.Visible = false;
            toTextBox.Visible = false;
            getNumbersDataButton.Visible = false;
            resetSearchButton.Visible = false;
            secondLabel.Visible = false;
            stringComboBox.Visible = false;
            stringLabel.Visible = false;
            searchStringTextBox.Visible = false;

        }

        private void fromTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Получаем символ, который ввёл пользователь
            char number = e.KeyChar;

            // Если пользователь ввёл не цифру, не нажал на Backspace или запятую, то не отображаем символ в textbox
            if (!Char.IsDigit(number) && number != 8 && number != 44)
                e.Handled = true;
        }

        private void searchStringTextBox_TextChanged(object sender, EventArgs e)
        {
            // Ищём запрашиваемые данные в таблице
            WorkWithDataDgv.GetLikeString(productDataGridView, stringComboBox, searchStringTextBox);
            DisplayStartPhoto();
        }

        private void resetSearchButton_Click(object sender, EventArgs e)
        {
            WorkWithDataDgv.ResetSearch(productDataGridView);
            searchStringTextBox.Text = "";
            toTextBox.Text = "";
            fromTextBox.Text = "";
            DisplayStartPhoto();
        }

        private void getNumbersDataButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (productDataGridView.RowCount < 1)
                    MessageBox.Show("Отсутствуют строки для поиска", "Поиск числовых данных", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    double from = Convert.ToDouble(fromTextBox.Text);
                    double to = Convert.ToDouble(toTextBox.Text);

                    if (from >= to)
                        MessageBox.Show("Данные в поле \"От\" должны быть меньше данных в поле \"До\"", "Поиск числовых данных", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                    {
                        // Производим поиск числовых данных
                        WorkWithDataDgv.SearchByDifference(productDataGridView, numbersComboBox.Text, from, to);
                        DisplayStartPhoto();
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Ошибка поиска числовых данных. Возможно, что вы ввели нецелые числа для поиска данных из столбца, которых хранит в себе только целые числа", "Поиск числовых данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void searchOrdersButton_Click(object sender, EventArgs e)
        {
            try
            {
                ordersTreeView.Nodes.Clear();

                // Если пользователь выбрал 0 или несколько записей
                if (WorkWithDataDgv.CountSelectedRows(productDataGridView) != 1)
                    MessageBox.Show("Неодходимо выбрать одну запись", "Поиск заказа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {

                    int numberRow = WorkWithDataDgv.NumberSelectedRows(productDataGridView);

                    // Получаем номер заказа
                    int numOrder = Product.GetNumberOfOrdersThisProduct(Product.GetIdProduct(productDataGridView.Rows[numberRow].Cells["Название"].Value.ToString(), Convert.ToInt32(productDataGridView.Rows[numberRow].Cells["Номер тиража"].Value)));

                    if (numOrder == 0)
                       MessageBox.Show("Данная печатная продукция нигде не указана", "Поиск заказа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        // Выводим номер заказа
                        ordersTreeView.Nodes.Add("Заказ №:");
                        ordersTreeView.Nodes.Add(numOrder.ToString());
                    }                    
                }
            }
            catch
            {
                MessageBox.Show("Ошибка поиска заказа", "Поиск заказа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void outputAllDataButton_Click(object sender, EventArgs e)
        {
            if (WorkWithDataDgv.CountSelectedRows(productDataGridView) != 1)
                MessageBox.Show("Неодходимо выбрать одну запись", "Вывод всех данных о печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else 
            {
                Product product = null;

                for (int i = 0; i < productDataGridView.RowCount; i++)
                {
                    // Если список содержит индекс выбранной строки
                    if (WorkWithDataDgv.GetListIndexesSelectedRows(productDataGridView).Contains(i))
                    {
                        // Получаем данные о печатной продукции 
                        int idProduct = Product.GetIdProduct(productDataGridView.Rows[i].Cells["Название"].Value.ToString(), Convert.ToInt32(productDataGridView.Rows[i].Cells["Номер тиража"].Value));
                        List<Material> materials = Material.GetListMaterials(idProduct);

                        product = new Product(productDataGridView.Rows[i].Cells["Название"].Value.ToString(), productDataGridView.Rows[i].Cells["Тип печ. продукции"].Value.ToString(), Convert.ToInt32(productDataGridView.Rows[i].Cells["Номер тиража"].Value), Convert.ToInt32(productDataGridView.Rows[i].Cells["Тираж"].Value),
                            Product.GetPhotoAsImage(productDataGridView.Rows[i].Cells["Название"].Value.ToString(), Convert.ToInt32(productDataGridView.Rows[i].Cells["Номер тиража"].Value)), materials, Convert.ToDouble(productDataGridView.Rows[i].Cells["Стоимость"].Value));
                    }
                }

                // Переход в меню вывода данных
                OtputAllDataProduct otputAllDataProduct = new OtputAllDataProduct(product);
                Transition.TransitionByForms(this, otputAllDataProduct);
                 
            }
        }
    }
}

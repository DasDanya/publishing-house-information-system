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

            // Если количество выбранный записей не равно 1
            if (WorkWithDataDgv.CountSelectedRows(typesProductDataGridView) != 1)
                MessageBox.Show("Неодходимо выбрать одну запись", "Выбор записи для её изменения", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                int numberRow = WorkWithDataDgv.NumberSelectedRows(typesProductDataGridView);

                if (!TypeProduct.TypeProductIsIndicated(TypeProduct.GetIdTypeProduct(typesProductDataGridView.Rows[numberRow].Cells["Тип печатной продукции"].Value.ToString(), Convert.ToDouble(typesProductDataGridView.Rows[numberRow].Cells["Наценка в %"].Value))))
                {

                    //Cоздаём объект типа печатной продукции              
                    TypeProduct typeProduct = new TypeProduct(typesProductDataGridView.Rows[numberRow].Cells["Тип печатной продукции"].Value.ToString(), Convert.ToDouble(typesProductDataGridView.Rows[numberRow].Cells["Наценка в %"].Value));

                    // Переходим в меню ввода данных для изменения этих самых данных
                    FillDataTypeProduct fillDataTypeProduct = new FillDataTypeProduct(typeProduct, 'C');
                    Transition.TransitionByForms(this, fillDataTypeProduct);
                }
                else
                    MessageBox.Show("Невозможно изменить запись, так как выбранный тип печатной продукции указан в печатной продукции. Удалите печатные продукции, в которых указан выбранный тип печатной продукции, или создайте новый тип печатной продукции", "Выбор записи для её изменения", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void restAddOrChangeButton_Click(object sender, EventArgs e)
        {
            // Приводим буфферные данные и компоненты в состояние по умолчанию
            DefaultStateOfMenu();

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Если пользователь выбрал 0 записей
                if (WorkWithDataDgv.CountSelectedRows(typesProductDataGridView) < 1)
                    MessageBox.Show("Неодходимо выбрать одну или несколько записей", "Удаление типов печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    // Если пользователь соглашается на удаление записи(-ей)
                    if (MessageBox.Show("Вы точно хотите удалить эту(-и) запись(-и)?", "Удаление типов печатной продукции", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        // Получаем массив id
                        int[] arrayId = TypeProduct.GetArrayIdTypesProduct(typesProductDataGridView, WorkWithDataDgv.GetListIndexesSelectedRows(typesProductDataGridView));

                        // Если все типы печатной продукции не указаны
                        if (!TypeProduct.TypeProductAreIndicated(arrayId))
                        {
                            // Если мы удалили указанное количество записей
                            if (TypeProduct.DeleteTypesProduct(arrayId) == arrayId.Length)
                            {
                                MessageBox.Show("Записи успешно удалены!", "Удаление типов печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ReloadData();
                            }
                            else
                            {
                                MessageBox.Show("Количество удаленных записей не совпадает с количеством выбранных записей", "Удаление типов печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                            MessageBox.Show("Невозможно удалить тип печатной продукции, так как он указан в печатной продукции. Удалите все печатные продукции, где указан выбранный тип печатной продукции, и повторите попытку", "Удаление типов печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
            }
            catch
            {

                MessageBox.Show("Произошла ошибка удаления типов печатной продукции", "Удаление типов печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Если пользователь изменяет запись
                if (MessageBox.Show("Вы точно хотите изменить запись?", "Изменение данных о типе печатной продукции", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    // Если изменилась только одна запись 
                    if (typeProduct.ChangeTypeProduct(id) == 1)
                        MessageBox.Show("Запись успешно изменена!", "Изменение данных о типе печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    else
                        MessageBox.Show("Количество измененных записей не равно единице", "Изменение данных о типе печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    ReloadData();
                    DefaultStateOfMenu();

                }
            }
            catch
            {
                MessageBox.Show("Ошибка изменения данных о типе печатной продукции", "Изменение данных о типе печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            selectAllRowsButton.Visible = true;
            resetSelectRowsButton.Visible = true;
            rangeLabel.Visible = false;
            fromLabel.Visible = false;
            toLabel.Visible = false;
            toTextBox.Visible = false;
            fromTextBox.Visible = false;
            searchMarginButton.Visible = false;
            resetSearchButton.Visible = false;
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
            rangeLabel.Visible = true;
            fromLabel.Visible = true;
            toLabel.Visible = true;
            toTextBox.Visible = true;
            fromTextBox.Visible = true;
            searchMarginButton.Visible = true;
            resetSearchButton.Visible = true;

            // Устанавливаем значения и свойства полям для поиска
            WorkWithDataDgv.SetElementsForSearchStringData(typesProductDataGridView, columnsComboBox, searchTextBox);
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
            TypeProduct.LoadTypesProduct(typesProductDataGridView);
            WorkWithDataDgv.SetReadOnlyColumns(typesProductDataGridView);

            typesProductDataGridView.Columns["Select"].Width = 200;
            typesProductDataGridView.Columns["Тип печатной продукции"].Width = 440;
            typesProductDataGridView.Columns["Наценка в %"].Width = 320;

        }

        private void typesProductDataGridView_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void selectAllRowsButton_Click(object sender, EventArgs e)
        {
            if (typesProductDataGridView.Rows.Count < 1)
                MessageBox.Show("Отсутствуют строки для выбора", "Выбрать всё", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                WorkWithDataDgv.SelectOrCancelSelectAllRows(typesProductDataGridView, true);
        }

        private void resetSelectRowsButton_Click(object sender, EventArgs e)
        {
            if (typesProductDataGridView.Rows.Count < 1)
                MessageBox.Show("Отсутствуют строки", "Отменить выбор строк", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                WorkWithDataDgv.SelectOrCancelSelectAllRows(typesProductDataGridView, false);
        }

        private void searchMarginButton_Click(object sender, EventArgs e)
        {
            if (typesProductDataGridView.Rows.Count < 1)
                MessageBox.Show("Отсутствуют строки для поиска", "Поиск по наценке", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                try
                {
                    // Получаем данные из текстовых полей
                    double from = double.Parse(fromTextBox.Text);
                    double to = double.Parse(toTextBox.Text);

                    // Если некорректный ввод данных
                    if (from >= to)
                    {
                        MessageBox.Show("Значение правого текстового поля должно быть больше левого", "Поиск по наценке", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        // Производим поиск по наценке
                        WorkWithDataDgv.SearchByDifference(typesProductDataGridView, "Наценка в %", from, to);
                        //WorkWithDataDgv.SetHeightRows(materialDataGridView);
                    }
                }

                catch
                {
                    MessageBox.Show("Ошибка поиска материала по стоимости. Убедитесь, что вы заполнили нужные текстовые поля, и повторите попытку", "Поиск материала по стоимости", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void resetSearchButton_Click(object sender, EventArgs e)
        {
            WorkWithDataDgv.ResetSearch(typesProductDataGridView);
            searchTextBox.Text = "";
            fromTextBox.Text = "0";
            toTextBox.Text = "100";

        }

        private void fromTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Получаем символ, который ввёл пользователь
            char number = e.KeyChar;

            // Если пользователь ввёл не цифру, не нажал на Backspace или запятую, то не отображаем символ в textbox
            if (!Char.IsDigit(number) && number != 8 && number != 44)
                e.Handled = true;
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            // Ищём запрашиваемые данные в таблице
            WorkWithDataDgv.GetLikeString(typesProductDataGridView, columnsComboBox, searchTextBox);
        }

        private void getProductsButton_Click(object sender, EventArgs e)
        {
            try
            {
                productsTreeView.Nodes.Clear();
                // Если пользователь выбрал 0 или несколько записей
                if (WorkWithDataDgv.CountSelectedRows(typesProductDataGridView) != 1)
                    MessageBox.Show("Неодходимо выбрать одну запись", "Получение печатных продукций", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    // Получаем список заказов
                    List<Product> products = TypeProduct.GetListProductsThisTypeProduct(typesProductDataGridView.Rows[WorkWithDataDgv.NumberSelectedRows(typesProductDataGridView)].Cells["Тип печатной продукции"].Value.ToString(), Convert.ToDouble(typesProductDataGridView.Rows[WorkWithDataDgv.NumberSelectedRows(typesProductDataGridView)].Cells["Наценка в %"].Value));

                    // Если список пуст
                    if (products.Count == 0)
                        MessageBox.Show("Выбранный тип печатной продукции не указан ни в одной печатной продукции", "Получение печатных продукций", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        // Выводим наименование заказчика
                        productsTreeView.Nodes.Add($"Название печатной продукции: её номер тиража");

                        // Выводим номера заказов
                        foreach (Product product in products)
                        {
                            productsTreeView.Nodes.Add($"{product.Name}: {product.NumberEdition}");
                        }
                    }


                }
            }
            catch
            {
                MessageBox.Show("Ошибка получения печатных продукций", "Получение печатных продукций", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fashionTypesButton_Click(object sender, EventArgs e)
        {
            if (typesProductDataGridView.Rows.Count > 0)
            {
                FashionTypeProductMenu fashionTypeProductMenu = new FashionTypeProductMenu();
                Transition.TransitionByForms(this, fashionTypeProductMenu);

            }
            else
                MessageBox.Show("Невозможно вывести моду данных о типах печатной продукции, так они отсутствуют!", "Вывод моды данных о типах печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

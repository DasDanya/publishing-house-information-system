using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PublishingHouse
{
    public partial class FillDataProduct : Form
    {

        Product product = null;
        char state = ' ';
        int id = -1;

        public FillDataProduct()
        {
            InitializeComponent();
        }

        public FillDataProduct(char state) 
        {
            InitializeComponent();
            this.state = state;
        }

        public FillDataProduct(Product product, char state) 
        {
            InitializeComponent();
            this.product = product;
            this.state = state;
        }

        private void backTab_Click(object sender, EventArgs e)
        {
            ProductMenu productMenu = new ProductMenu();
            Transition.TransitionByForms(this, productMenu);
        }

        private void FillDataProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void FillDataProduct_Load(object sender, EventArgs e)
        {
            try
            {
                //Загружаем данные в компоненты
                LoadStartData();

                // Если пользователь изменяет запись
                if (product != null && state == 'C')
                {
                    LoadDataAboutProduct();
                    id = Product.GetIdProduct(product.Name, product.NumberEdition);
                }
            }
            catch
            {

                MessageBox.Show("Ошибка загрузки формы ввода данных о печатной продукции", "Ввод данных о печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод заполнения данных о печатной продукции в нужные компоненты
        /// </summary>
        private void LoadDataAboutProduct() 
        {
            nameTextBox.Text = product.Name;
            numEditionTextBox.Text = product.NumberEdition.ToString();
            countTextBox.Text = product.ProdEdition.ToString();
            productPictureBox.Image = product.DesignAsImage;
            TypeProduct.SelectRowTypeProduct(typeProductDataGridView, product.IdTypeProduct);
            Material.FillTableWithMaterials(toDataGridView, product.Materials);
        }

        

        /// <summary>
        ///  Метод заполнения таблицы для выбора материалов
        /// </summary>
        private void LoadStartData() 
        {
            fromDataGridView.DataSource = Material.LoadMaterial();
            TypeProduct.LoadTypesProduct(typeProductDataGridView);
            typeProductDataGridView.Columns[1].Width = 320;
            typeProductDataGridView.Columns[2].Width = 150;

            // Делаем таблицы только для чтения
            WorkWithDataDgv.SetReadOnlyColumns(fromDataGridView);
            WorkWithDataDgv.SetReadOnlyColumns(typeProductDataGridView);
            toDataGridView.Columns[1].ReadOnly = true;
            toDataGridView.Columns[2].ReadOnly = true;
            toDataGridView.Columns[3].ReadOnly = true;
            toDataGridView.Columns[4].ReadOnly = true;

        }

        private void fromDataGridView_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void selectMaterialButton_Click(object sender, EventArgs e)
        {
            try
            {               
                if (WorkWithDataDgv.CountSelectedRows(fromDataGridView) < 1)
                    MessageBox.Show("Необдимо выбрать хотя бы один материал", "Выбор материалов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    // удаляем прошлые выбранные материалы
                    WorkWithDataDgv.DeleteAllRowsFromDataGridView(toDataGridView);
                   
                    // Получаем массив выбранных материалов
                    Material[] materials = Material.GetArrayMaterials(fromDataGridView, WorkWithDataDgv.GetListIndexesSelectedRows(fromDataGridView));

                    // Если материалы не имеют одинаковый тип,цвет,размер, то добавляем в таблицу
                    if (/*Material.SameSizeMaterials(materials) && */ !Material.SameSizeColorTypeMaterial(materials))
                    {
                        // Добавляем материалы в таблицу добавления материалов
                        Material.FillTableWithMaterials(toDataGridView, materials);
                        WorkWithDataDgv.SelectOrCancelSelectAllRows(fromDataGridView, false);
                    }
                    else
                        MessageBox.Show("Нельзя добавить материалы с одинаковым типом, цветом и размером", "Выбор материалов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {          
                MessageBox.Show("Ошибка выбора материалов", "Выбор материалов", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetSelectMateralButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (WorkWithDataDgv.CountSelectedRows(toDataGridView) < 1)
                    MessageBox.Show("Необдимо выбрать хотя бы один материал", "Удаление материалов из таблицы добавления", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    // Удаляем выбранные строки из таблицы
                    WorkWithDataDgv.DeleteSelectedRowsFromDataGridView(toDataGridView);
            }
            catch
            {
                MessageBox.Show("Ошибка удаления материалов из таблицы добавления", "Удаление материалов из таблицы добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openDialog = new OpenFileDialog();
                openDialog.Filter = "ImageFiles(*.BMP; *.JPG; *.JPEG; *.PNG)| *.BMP; *.JPG; *.JPEG; *.PNG";

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    productPictureBox.Image = new Bitmap(openDialog.FileName);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки фото", "Загрузка фото", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод проверки введённых данных
        /// </summary>
        /// <returns>Правильно ли введены данные</returns>
        private bool CorrectInputData()
        {
            if (nameTextBox.Text == "" || numEditionTextBox.Text == "" || countTextBox.Text == "" || int.Parse(numEditionTextBox.Text) < 1 || int.Parse(countTextBox.Text) < 1 || WorkWithDataDgv.CountSelectedRows(typeProductDataGridView) != 1 || toDataGridView.RowCount < 1 || !CountIsFilled())
            {
                return false;
            }
            else
                return true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ProductMenu productMenu = new ProductMenu();
            try
            {
                if (CorrectInputData())
                {
                    string name = "";
                    int numEdition = 0;

                    if (state == 'C')
                    {
                        // Текущие данные о печатной продукции
                        name = this.product.Name;
                        numEdition = this.product.NumberEdition;

                    }

                    // Если существует тип печатной продукции с введенными данными
                    if (!Product.ExistProductInDb(state, numEdition, Convert.ToInt32(numEditionTextBox.Text), name, nameTextBox.Text))
                    {

                       // Данные о печатной продукции
                       double cost = Product.GetCostProduct(toDataGridView, Convert.ToDouble(typeProductDataGridView.Rows[WorkWithDataDgv.NumberSelectedRows(typeProductDataGridView)].Cells["Наценка в %"].Value), Convert.ToInt32(countTextBox.Text));
                       byte[] design = WorkWithDataDgv.GetBytePhoto(productPictureBox.Image);
                       int idTypeProduct = TypeProduct.GetIdTypeProduct(typeProductDataGridView.Rows[WorkWithDataDgv.NumberSelectedRows(typeProductDataGridView)].Cells["Тип печатной продукции"].Value.ToString(), Convert.ToDouble(typeProductDataGridView.Rows[WorkWithDataDgv.NumberSelectedRows(typeProductDataGridView)].Cells["Наценка в %"].Value));
                       List<Material> materials = Material.GetListMaterials(toDataGridView);

                        //Создаём тип печатной продукции
                        Product product = new Product(nameTextBox.Text, Convert.ToInt32(numEditionTextBox.Text), Convert.ToInt32(countTextBox.Text), idTypeProduct, design, cost, materials);


                        // Возвращаемся в меню типов печатной продукции
                        if (state == 'A')
                            productMenu = new ProductMenu(product, state);
                        else if (state == 'C')
                            productMenu = new ProductMenu(product, state, id);



                        Transition.TransitionByForms(this, productMenu);
                    }
                    else
                        MessageBox.Show("В базе данных не могут существовать печатные продукции с одинаковым названием и с одинаковым номером тиража", "Ввод данных о печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                    MessageBox.Show("Текстовые поля должны быть заполнены, количество материалов должно быть указано. Номер тиража и количество должны быть больше нуля. Необходимо выбрать один тип печатной продукции и хотя бы один материал","Ввод данных о печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {              
                MessageBox.Show("Ошибка ввода данных о печатной продукции", "Ввод данных о печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numEducationTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Получаем символ, который ввёл пользователь
            char number = e.KeyChar;

            // Если пользователь ввёл не цифру и не нажал на Backspace, то не отображаем символ в textbox
            if (!Char.IsDigit(number) && number != 8)
                e.Handled = true;
        }

        // Событие на ввод данных в ячейку datagridview
        private void toDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;
            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
        }

        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Получаем символ, который ввёл пользователь
            char number = e.KeyChar;

            // Если пользователь ввёл не цифру и не нажал на Backspace, то не отображаем символ в textbox
            if (!Char.IsDigit(number) && number != 8)
                e.Handled = true;
        }

        /// <summary>
        /// Метод проверки на то, что пользователь ввёл для каждого материала количество
        /// </summary>
        /// <returns></returns>
        private bool CountIsFilled() 
        {
            if (toDataGridView.Rows.Count == 0)
                return false;

            for (int i = 0; i < toDataGridView.RowCount; i++)
            {
                if (toDataGridView.Rows[i].Cells["Count"].Value == null || Convert.ToInt32(toDataGridView.Rows[i].Cells["Count"].Value) == 0)
                    return false;
            }

            return true;
        }

        
    }
}

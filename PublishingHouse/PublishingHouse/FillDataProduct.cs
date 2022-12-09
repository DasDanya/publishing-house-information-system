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
                LoadMaterials();
            }
            catch 
            {
                MessageBox.Show("Ошибка загрузки формы ввода данных о печатной продукции", "Ввод данных о печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///  Метод заполнения таблицы для выбора материалов
        /// </summary>
        private void LoadMaterials() 
        {
            fromDataGridView.DataSource = Material.LoadMaterial();

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

                    // Если материалы имеют одинаковый размер и не имеют одинаковый тип,цвет,размер, то добавляем в таблицу
                    if (Material.SameSizeMaterials(materials) && !Material.SameSizeColorTypeMaterial(materials))
                    {
                        // Добавляем материалы в таблицу добавления материалов
                        Material.FillTableWithMaterials(toDataGridView, materials);
                        WorkWithDataDgv.SelectOrCancelSelectAllRows(fromDataGridView, false);
                    }
                    else
                        MessageBox.Show("Выбранные материалы должны иметь одинаковый размер. Нельзя добавить материалы с одинаковым типом, цветом и размером", "Выбор материалов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
    }
}

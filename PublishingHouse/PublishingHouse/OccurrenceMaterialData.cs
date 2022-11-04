using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PublishingHouse
{
    public partial class OccurrenceMaterialData : Form
    {
        public OccurrenceMaterialData()
        {
            InitializeComponent();
        }

        private void PopularMaterialData_Load(object sender, EventArgs e)
        {
            //Загружаем иконки для вкладок
            IconImage.LoadIconBackTab(backTab);

            // Заполняем таблицы
            int count = Material.GetCountRows();
            FillingTable(typeDataGridView, "Тип", "DESC", count);
    
        }

        private void backTab_Click(object sender, EventArgs e)
        {
            // Переход к меню материалов
            MaterialMenu materialMenu = new MaterialMenu();
            Transition.TransitionByForms(this, materialMenu);
        }

        private void PopularMaterialData_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void getTypesButton_Click(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// Метод заполнения таблицы
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        /// <param name="columnName">Столбец</param>
        /// <param name="order">Порядок сортировки</param>
        /// <param name="count">Количество выводимых строк</param>
        private void FillingTable(DataGridView dataGridView, string columnName, string order, int count) 
        {
            // Заполняем таблицы полностью по убыванию повторяемости
            dataGridView.DataSource = Material.GetTableByOccurrence(columnName,order, count);

            // Устанавливаем ширину столбца и делаем первую строку без выделения
            dataGridView.Columns[0].Width = 310;
            dataGridView.ClearSelection();
        }

       
       

        //private void FillingTable(DataGridView dataGridView, string columnName, string order) 
        //{            
        //    //if (int.Parse(countTypeTextBox.Text) > count)
        //    //    MessageBox.Show(string.Format("Необходимо ввести количество строк, не превышая максимальное значение: {0}", count), "Получение типов материалов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    //else
        //        dataGridView.DataSource = Material.GetTableByOccurrence(columnName, order, count);
        //}
    }
}

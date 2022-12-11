using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PublishingHouse
{
    public partial class OtputAllDataProduct : Form
    {
        Product product = null;

        public OtputAllDataProduct()
        {
            InitializeComponent();
        }

        public OtputAllDataProduct(Product product) 
        {
            InitializeComponent();
            this.product = product;
        }

        private void backTab_Click(object sender, EventArgs e)
        {
            ProductMenu productMenu = new ProductMenu();
            Transition.TransitionByForms(this, productMenu);
        }

        private void OtputAllDataProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void OtputAllDataProduct_Load(object sender, EventArgs e)
        {
            try
            {
                // Загружаем данные о печатной продукции
                OutputData();
            }
            catch 
            {
                MessageBox.Show("Ошибка отображения данных о печатной продукции", "Отображение данных о печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод загрузки данных в RichTextBox
        /// </summary>
        private void OutputData() 
        {
             // Текстовые данные о печатной продукции
            dataRichTextBox.Text += $"\n\nНазвание печатной продукции: {product.Name}\nТип печатной продукции: {product.NameTypeProduct}\nНомер тиража: {product.NumberEdition}\nТираж: {product.ProdEdition}\n" +
                      $"Стоимость: {product.Cost}\n\nМатериалы:\n";


            // Выводим данные о материалах
            for (int i = 0; i < product.Materials.Count; i++)
            {
                Material material = Material.GetMaterial(product.Materials[i].Id, product.Materials[i].Count);
                dataRichTextBox.Text += material.ToString() + "\n\n";
            }

            // Фото макета печатной продукции
            Clipboard.SetImage(product.DesignAsImage);
            dataRichTextBox.Paste();
        }

        private void saveRTFButton_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = "*.rtf";
                saveFileDialog.Filter = "RTF Files|*.rtf"; 

                if (saveFileDialog.ShowDialog() == DialogResult.OK) 
                {
                    dataRichTextBox.SaveFile(saveFileDialog.FileName);
                    MessageBox.Show("Данные успешно сохранены в файл!", "Сохранить данные в RTF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch 
            {
                MessageBox.Show("Ошибка сохранения файла", "Сохранить данные в RTF", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

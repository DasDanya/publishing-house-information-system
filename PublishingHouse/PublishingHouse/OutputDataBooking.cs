using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PublishingHouse
{
    public partial class OutputDataBooking : Form
    {
        Booking booking = null;

        public object PDfWriter { get; private set; }

        public OutputDataBooking()
        {
            InitializeComponent();
        }

        public OutputDataBooking(Booking booking) 
        {
            InitializeComponent();
            this.booking = booking;
        }

        private void backTab_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            Transition.TransitionByForms(this, mainMenu);
        }

        private void OutputDataBooking_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void OutputDataBooking_Load(object sender, EventArgs e)
        {
            try
            {
                LoadStartData();
            }
            catch
            {        
                MessageBox.Show("Ошибка формирования отчёта", "Формирование отчёта", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStartData() 
        {
            // Текстовые данные о печатной продукции
            reportRichTextBox.Text += $"Номер заказа: {booking.NumBooking}\nДата приёма: {booking.StartBooking.Date.ToShortDateString()}\nДата выполнения заказа: {booking.EndBooking.Date.ToShortDateString()}\nСтоимость выполнения: {booking.Cost}\n\n" +
                $"Данные о заказчике:\n{Customer.GetCustomer(booking.IdCustomer).ToString()}\n\nДанные о типографии:\n{PrintingHouse.GetPrintingHouse(booking.IdPrintingHouse).ToString()}\n\nДанные о сотрудниках:\n";

            // Выводим данные о сотрудниках
            for (int i = 0; i < booking.IdEmployees.Length; i++)
            {
                Employee employee = Employee.GetEmployee(booking.IdEmployees[i]);
                reportRichTextBox.Text += employee.ToString() + "\n" + "\n";
            }

            reportRichTextBox.Text += "\nПечатные продукции:\n";
            // Выводим данные о печатных продукциях
            for (int i = 0; i < booking.IdProducts.Length; i++)
            {
                Product product = Product.GetProduct(booking.IdProducts[i]);
                reportRichTextBox.Text += product.ToString() + "\n";

                reportRichTextBox.Text += "\nТип печатной продукции:\n";

                int idTypeProduct = TypeProduct.GetIdTypeProduct(booking.IdProducts[i]);

                TypeProduct typeProduct = TypeProduct.GetTypeProduct(idTypeProduct);
                reportRichTextBox.Text += typeProduct.ToString() + "\n";

                List<Material> materials = Material.GetListMaterials(booking.IdProducts[i]);

                reportRichTextBox.Text += "\nМатериалы:\n";
                // Выводим данные о материалах
                for (int j = 0; j < materials.Count; j++)
                {
                    Material material = Material.GetMaterial(materials[j].Id, materials[j].Count);
                    reportRichTextBox.Text += material.ToString() + "\n\n";
                }
            }
        }

        private void reportRTFButton_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = "*.rtf";
                saveFileDialog.Filter = "RTF file|*.rtf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    reportRichTextBox.SaveFile(saveFileDialog.FileName);
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

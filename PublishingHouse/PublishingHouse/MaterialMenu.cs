using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PublishingHouse
{
    public partial class MaterialMenu : Form
    {
     
        public MaterialMenu()
        {
            InitializeComponent();
        }

        private void MaterialMenu_Load(object sender, EventArgs e)
        {
            //Загружаем иконки для вкладок
            IconImage.LoadIconsOfMaterialTab(backTab);

            //Загружаем данные из бд в таблицу
            LoadData();
          
        }

        private void backTab_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            Transition.TransitionByForms(this, mainMenu);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (typeComboBox.Text == "" || colorComboBox.Text == "" || widthTextBox.Text == "" || heightTextBox.Text == "" || costTextBox.Text == "" || int.Parse(widthTextBox.Text) <=0 || int.Parse(heightTextBox.Text) <=0 || double.Parse(costTextBox.Text) <= 0 || costTextBox.Text.Length > 4)
                {
                    MessageBox.Show("Поля для ввода должны быть заполнены. Ширина и высота должны быть целыми числами. Ширина, высота, стоимость должны быть числами больше нуля", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else 
                {
                    // Создаём материал
                    string size = string.Format(widthTextBox.Text + "x" + heightTextBox.Text);
                    Material material = new Material(typeComboBox.Text, colorComboBox.Text, size, double.Parse(costTextBox.Text));

                    // Добавляем материал в базу данных
                    if (material.AddMaterial() == 1)
                    {
                        MessageBox.Show("Запись успешно добавлена!", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Выводим новые данные и очищаем текстовые поля 
                        ReloadData();
                        ClearBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка добавления данных", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Некорректный ввод данных", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MaterialMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        /// <summary>
        /// Загрузка данных из бд в таблицу
        /// </summary>
        private void LoadData() 
        {
            // Загружаем данные из бд в таблицу
            materialDataGridView.DataSource = Material.LoadMaterial();

            // Устанавливаем столбцам ширину
            SetWidthColumsTable();
        }

        /// <summary>
        /// Метод, устанавливающий ширину столбцов таблицы
        /// </summary>
        private void SetWidthColumsTable() 
        {
            materialDataGridView.Columns["Тип"].Width = 200;
            materialDataGridView.Columns["Цвет"].Width = 180;
            materialDataGridView.Columns["Размер в мм"].Width = 140;
            materialDataGridView.Columns["Стоимость в ₽"].Width = 140;
        }

        /// <summary>
        /// Метод вывода новых данных из бд
        /// </summary>
        private void ReloadData() 
        { 
            // Удаляем все строки из таблицы
            while(materialDataGridView.Rows.Count != 0) 
            {
                materialDataGridView.Rows.Remove(materialDataGridView.Rows[materialDataGridView.Rows.Count-1]);
            }

            // Загружаем новые данные
            LoadData();
            
        }

        /// <summary>
        /// Метод очистки полей для ввода данных
        /// </summary>
        private void ClearBoxes() 
        {
            typeComboBox.Text = "";
            colorComboBox.Text = "";
            widthTextBox.Text = "";
            heightTextBox.Text = "";
            costTextBox.Text = "";
        }
    }
}

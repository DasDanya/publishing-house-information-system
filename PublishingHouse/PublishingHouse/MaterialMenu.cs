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
                if (typeComboBox.Text == "" || colorComboBox.Text == "" || widthComboBox.Text == "" || heightComboBox.Text == "" || costTextBox.Text == "" || int.Parse(heightComboBox.Text) <=0 || int.Parse(widthComboBox.Text) <=0 || double.Parse(costTextBox.Text) <= 0)
                {
                    MessageBox.Show("Поля для ввода должны быть заполнены. Ширина и высота должны быть целыми числами. Ширина, высота, стоимость должны быть числами больше нуля.", "Добавление материала", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else 
                {
                    // Создаём материал
                    string size = string.Format(widthComboBox.Text + "x" + heightComboBox.Text);
                    Material material = new Material(typeComboBox.Text, colorComboBox.Text, size, double.Parse(costTextBox.Text));

                    // Если запись с такими данными уже существует в базе данных
                    if (material.ExistMaterial(materialDataGridView))
                    {
                        MessageBox.Show("Данная запись уже существует в базе данных", "Добавление материала", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        // Добавляем материал в базу данных
                        if (material.AddMaterial() == 1)
                        {
                            MessageBox.Show("Запись успешно добавлена!", "Добавление материала", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Выводим новые данные и очищаем текстовые поля 
                            ReloadData();
                            ClearBoxes();
                        }
                        else
                        {
                            MessageBox.Show("Ошибка добавления материала", "Добавление материала", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Некорректный ввод данных", "Добавление материала", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                // Загружаем данные из бд в таблицу
                materialDataGridView.DataSource = Material.LoadMaterial();

                // Устанавливаем столбцам ширину и свойство "Только для чтения"
                SetWidthColumsTable();
                SetReadOnlyColumns();
            }
            catch 
            {
                MessageBox.Show("Ошибка вывода данных", "Вывод материалов", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        /// Метод, устанавливающий столбцам свойство "Только для чтения"
        /// </summary>
        private void SetReadOnlyColumns() 
        {
            materialDataGridView.Columns["Тип"].ReadOnly = true;
            materialDataGridView.Columns["Цвет"].ReadOnly = true;
            materialDataGridView.Columns["Размер в мм"].ReadOnly = true;
            materialDataGridView.Columns["Стоимость в ₽"].ReadOnly = true;
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
            widthComboBox.Text = "";
            heightComboBox.Text = "";
            costTextBox.Text = "";
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (WorkWithRows.CountSelectedRows(materialDataGridView) != 1)
                {
                    MessageBox.Show("Для удаления материала необходимо выбрать одну запись", "Удаление материала", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (MessageBox.Show("Вы точно хотите удалить эту запись?", "Удаление материала", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        // Получаем номер выбранной записи. Создаём материал
                        int number = WorkWithRows.NumberSelectedRows(materialDataGridView);
                        Material material = new Material(materialDataGridView.Rows[number].Cells["Тип"].Value.ToString(), materialDataGridView.Rows[number].Cells["Цвет"].Value.ToString(), materialDataGridView.Rows[number].Cells["Размер в мм"].Value.ToString(), Convert.ToDouble(materialDataGridView.Rows[number].Cells["Стоимость в ₽"].Value));

                        // Удаляем материал из базы данных
                        if (material.DeleteMaterial() == 1)
                        {
                            MessageBox.Show("Запись успешно удалена!", "Удаление материала", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Выводим новые данные и очищаем текстовые поля 
                            ReloadData();
                            ClearBoxes();
                        }
                        else
                        {
                            MessageBox.Show("Ошибка удаления материала", "Удаление материала", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Произошка ошибка удаления записи", "Удаление материала", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

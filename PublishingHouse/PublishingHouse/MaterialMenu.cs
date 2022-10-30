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

            // Устанавливаем значения и свойства полям для поиска
            WorkWithDataDgv.SetElementsForSearchStringData(materialDataGridView, columnComboBox, searchTextBox);

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
                if (!CorrectInputData())
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

                            // Устанавливаем значения и свойства полям для поиска
                            WorkWithDataDgv.SetElementsForSearchStringData(materialDataGridView, columnComboBox, searchTextBox);

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
                SetSizeColumsAndRowsOfTable();
                SetReadOnlyColumns();
            }
            catch
            {
                MessageBox.Show("Ошибка вывода данных", "Вывод материалов", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод, устанавливающий размер столбцов таблицы
        /// </summary>
        private void SetSizeColumsAndRowsOfTable()
        {
            // Устанавливаем высоту
            WorkWithDataDgv.SetHeightRows(materialDataGridView);

            // Устанавливаем ширину
            materialDataGridView.Columns["Тип"].Width = 200;
            materialDataGridView.Columns["Цвет"].Width = 180;
            materialDataGridView.Columns["Размер"].Width = 140;
            materialDataGridView.Columns["Стоимость"].Width = 140;

        }

        /// <summary>
        /// Метод, устанавливающий столбцам свойство "Только для чтения"
        /// </summary>
        private void SetReadOnlyColumns()
        {
            materialDataGridView.Columns["Тип"].ReadOnly = true;
            materialDataGridView.Columns["Цвет"].ReadOnly = true;
            materialDataGridView.Columns["Размер"].ReadOnly = true;
            materialDataGridView.Columns["Стоимость"].ReadOnly = true;
        }

        /// <summary>
        /// Метод вывода новых данных из бд
        /// </summary>
        private void ReloadData()
        {
            // Удаляем все строки из таблицы
            while (materialDataGridView.Rows.Count != 0)
            {
                materialDataGridView.Rows.Remove(materialDataGridView.Rows[materialDataGridView.Rows.Count - 1]);
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

       

        /// <summary>
        /// Метод корректности введённых данных о материале
        /// </summary>
        /// <returns>Корректны ли данные</returns>
        private bool CorrectInputData()
        {
            if (typeComboBox.Text == "" || colorComboBox.Text == "" || widthComboBox.Text == "" || heightComboBox.Text == "" || costTextBox.Text == "" || int.Parse(heightComboBox.Text) <= 0 || int.Parse(widthComboBox.Text) <= 0 || double.Parse(costTextBox.Text) <= 0)
            {
                return false;
            }
            return true;
        }

        int id = -1;

        /// <summary>
        /// Метод получения данных выбранного материала и вывод их в соответствующие поля
        /// </summary>
        private void GetDataSelectedMaterial(int number)
        {

            typeComboBox.Text = materialDataGridView.Rows[number].Cells["Тип"].Value.ToString();
            colorComboBox.Text = materialDataGridView.Rows[number].Cells["Цвет"].Value.ToString();
            costTextBox.Text = materialDataGridView.Rows[number].Cells["Стоимость"].Value.ToString();

            string size = materialDataGridView.Rows[number].Cells["Размер"].Value.ToString();
            Material material = new Material(typeComboBox.Text, colorComboBox.Text, size, Convert.ToDouble(costTextBox.Text));
            id = material.GetIdMaterial();
            
            widthComboBox.Text = size.Substring(0, size.IndexOf('x'));
            heightComboBox.Text = size.Substring(size.IndexOf('x')+1);

        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (WorkWithDataDgv.CountSelectedRows(materialDataGridView) < 1)
                {
                    MessageBox.Show("Для удаления материала необходимо выбрать хотя бы одну запись", "Удаление материалов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (MessageBox.Show("Вы точно хотите удалить эту(-и) запись(-и)?", "Удаление материалов", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        // Создаём массив выбранных материалов
                        Material[] materials = Material.GetArrayMaterials(materialDataGridView, WorkWithDataDgv.GetListIndexesSelectedRows(materialDataGridView));

                        // Удаляем материалы из базы данных
                        if (Material.DeleteMaterial(materials) == materials.Length)
                        {
                            MessageBox.Show("Запись(-и) успешно удалена(-ы)!", "Удаление материалов", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Выводим новые данные 
                            ReloadData();

                            // Устанавливаем значения и свойства полям для поиска
                            WorkWithDataDgv.SetElementsForSearchStringData(materialDataGridView, columnComboBox, searchTextBox);

                        }
                        else
                        {
                            MessageBox.Show("Ошибка удаления материала(-ов)", "Удаление материалов", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Произошка ошибка удаления записи(-ей)", "Удаление материалов", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void selectForChangeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (WorkWithDataDgv.CountSelectedRows(materialDataGridView) != 1)
                {
                    MessageBox.Show("Для изменния материала необходимо выбрать одну запись", "Выбор материала для изменения", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    // Заполняем поля для ввода данными, выбранными пользователем
                    GetDataSelectedMaterial(WorkWithDataDgv.NumberSelectedRows(materialDataGridView));

                    changeButton.Enabled = true;
                    selectForChangeButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Выбор материала для изменения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CorrectInputData())
                {
                    MessageBox.Show("Поля для ввода должны быть заполнены. Ширина и высота должны быть целыми числами. Ширина, высота, стоимость должны быть числами больше нуля.", "Изменение материала", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    // Создаём материал
                    string size = string.Format(widthComboBox.Text + "x" + heightComboBox.Text);
                    Material material = new Material(typeComboBox.Text, colorComboBox.Text, size, double.Parse(costTextBox.Text));

                    // Если запись с такими данными уже существует в базе данных
                    if (material.ExistMaterial(materialDataGridView))
                    {
                        MessageBox.Show("Данная запись уже существует в базе данных", "Изменение материала", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (MessageBox.Show("Вы точно хотите изменить эту запись?", "Изменение материала", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                        {
                            // Изменяем данные выбранного материала
                            if (material.ChangeMaterial(id) == 1)
                            {
                                MessageBox.Show("Запись успешно изменена!", "Изменение материала", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Выводим новые данные и очищаем текстовые поля 
                                ReloadData();
                                ClearBoxes();

                                changeButton.Enabled = false;
                                selectForChangeButton.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("Ошибка изменения материала", "Изменение материала", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                }
            }
            catch
            {
                MessageBox.Show("Неккоректный ввод данных", "Изменение материала", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            // Ищём запрашиваемые данные в таблице
            WorkWithDataDgv.GetLikeString(materialDataGridView, columnComboBox, searchTextBox);

            SetSizeColumsAndRowsOfTable();
        }

        private void materialDataGridView_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void resetChangeButton_Click(object sender, EventArgs e)
        {
            ClearBoxes();

            selectForChangeButton.Enabled = true;
            changeButton.Enabled = false;

        }

        private void searchCostButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем данные из текстовых полей
                double from = double.Parse(fromTextBox.Text);
                double to = double.Parse(toTextBox.Text);

                // Если некорректный ввод данных
                if (from < 1 || to < 1 || from >= to)
                {
                    MessageBox.Show("Диапазон должен содержать числа больше нуля. Значение правого текстового поля должно быть больше левого", "Поиск материала по стоимости", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else 
                {
                    // Производим поиск по определенному столбцу
                    WorkWithDataDgv.GetLikeCost(materialDataGridView, "Стоимость", from, to);
                    WorkWithDataDgv.SetHeightRows(materialDataGridView);
                }
            }

            catch
            {
                MessageBox.Show("Неккоректный ввод данных", "Поиск материала по стоимости", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void resetCostButton_Click(object sender, EventArgs e)
        {
            // Сбрасываем поиск по стоимости
            WorkWithDataDgv.ResetSearchCost(materialDataGridView);
            WorkWithDataDgv.SetHeightRows(materialDataGridView);
        }

        private void popDataAbMaterialButton_Click(object sender, EventArgs e)
        {
            // Если есть записи в таблице, то открываем форму с популярными данными
            if (materialDataGridView.Rows.Count != 0)
            {
                PopularDataMaterialMenu popularDataMaterialMenu = new PopularDataMaterialMenu();
                Transition.TransitionByForms(this, popularDataMaterialMenu);
            }
            else
                MessageBox.Show("Невозможно вывести популярные данные о материалах, так они отсутствуют!", "Вывод популярных данных о материалах", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
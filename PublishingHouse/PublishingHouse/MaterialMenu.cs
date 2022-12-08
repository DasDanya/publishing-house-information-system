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
        string color = "";
        private void MaterialMenu_Load(object sender, EventArgs e)
        {
            
            //Загружаем данные из бд в таблицу
            LoadData();

            // Устанавливаем значения и свойства полям для поиска
            WorkWithDataDgv.SetElementsForSearchStringData(materialDataGridView, columnComboBox, searchTextBox);

        }

        /// <summary>
        /// Метод, проверяющий правильно ли пользователь выбрал размер материала
        /// </summary>
        /// <returns>Правильный ли ввод</returns>
        private bool CorrectInputSize() 
        {
            
            //if ((!string.IsNullOrWhiteSpace(bComboBox.Text) && !string.IsNullOrWhiteSpace(cComboBox.Text)) || (!string.IsNullOrWhiteSpace(aComboBox.Text) && !string.IsNullOrWhiteSpace(cComboBox.Text)) || (!string.IsNullOrWhiteSpace(aComboBox.Text) || !string.IsNullOrWhiteSpace(cComboBox.Text)) || (!string.IsNullOrWhiteSpace(aComboBox.Text) && !string.IsNullOrWhiteSpace(bComboBox.Text) && !string.IsNullOrWhiteSpace(cComboBox.Text)) || (string.IsNullOrWhiteSpace(aComboBox.Text) && string.IsNullOrWhiteSpace(bComboBox.Text) && string.IsNullOrWhiteSpace(cComboBox.Text)))
            if((!string.IsNullOrEmpty(aComboBox.Text) && string.IsNullOrEmpty(bComboBox.Text) && string.IsNullOrEmpty(cComboBox.Text)) | (string.IsNullOrEmpty(aComboBox.Text) && !string.IsNullOrEmpty(bComboBox.Text) && string.IsNullOrEmpty(cComboBox.Text)) | (string.IsNullOrEmpty(aComboBox.Text) && string.IsNullOrEmpty(bComboBox.Text) && !string.IsNullOrEmpty(cComboBox.Text)))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Метод, возвращающий размер материала
        /// </summary>
        /// <returns>Размер материала</returns>
        private string ValueInputSize() 
        {
            string size = "";
            if (aComboBox.Text != "")
                size = aComboBox.Text;
            else if (bComboBox.Text != "")
                size = bComboBox.Text;
            else if (cComboBox.Text != "")
                size = cComboBox.Text;

            return size;
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
                    MessageBox.Show("Поля для ввода должны быть заполнены. Должно быть выбрано только одно значение для размера. Стоимость должна быть числом больше нуля.", "Добавление материала", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    // Создаём материал
                    string size = ValueInputSize();
                    Material material = new Material(typeComboBox.Text, color, size, double.Parse(costTextBox.Text));

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
                            MessageBox.Show("Запись не была добавлена или неоднократно добавлена", "Добавление материала", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка добавления материала", "Добавление материала", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                SetColumnsWidth();
                SetReadOnlyColumns();

                // Первая строчка не выделятся
                materialDataGridView.ClearSelection();
            }
            catch
            {
                MessageBox.Show("Ошибка вывода данных", "Вывод материалов", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод, устанавливающий размер столбцов
        /// </summary>
        private void SetColumnsWidth()
        {
            //// Устанавливаем высоту
            //WorkWithDataDgv.SetHeightRows(materialDataGridView);

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
            for (int i = 1; i < materialDataGridView.Columns.Count; i++)
            {
                materialDataGridView.Columns[i].ReadOnly = true;
            }
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
            colorInfoLabel.Text = "Цвет не выбран!";


            typeComboBox.Text = "";
            color = "";
            //colorComboBox.Text = "";
            aComboBox.Text = "";
            bComboBox.Text = "";
            cComboBox.Text = "";
            //heightComboBox.Text = "";
            costTextBox.Text = "";
        }

       

        /// <summary>
        /// Метод корректности введённых данных о материале
        /// </summary>
        /// <returns>Корректны ли данные</returns>
        private bool CorrectInputData()
        {
           
            if (typeComboBox.Text == "" || color == ""  || !CorrectInputSize() || costTextBox.Text == "" || double.Parse(costTextBox.Text) <= 0)
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
            colorInfoLabel.Text = "Цвет из таблицы!";

            typeComboBox.Text = materialDataGridView.Rows[number].Cells["Тип"].Value.ToString();
            color = materialDataGridView.Rows[number].Cells["Цвет"].Value.ToString();
            costTextBox.Text = materialDataGridView.Rows[number].Cells["Стоимость"].Value.ToString();

            string size = materialDataGridView.Rows[number].Cells["Размер"].Value.ToString();
            SetSizeIntoComboBox(size);

            Material material = new Material(typeComboBox.Text, materialDataGridView.Rows[number].Cells["Цвет"].Value.ToString(), size, Convert.ToDouble(costTextBox.Text));
            id = material.GetIdMaterial();
            
        }

        /// <summary>
        /// Записывает размер в нужный ComboBox
        /// </summary>
        /// <param name="size">Размер</param>
        private void SetSizeIntoComboBox(string size) 
        {
            if (aComboBox.FindString(size) != -1)
                aComboBox.Text = size;
            else if (bComboBox.FindString(size) != -1)
                bComboBox.Text = size;
            else if (cComboBox.FindString(size) != -1)
                cComboBox.Text = size;
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

                        // Получаем массив id
                        int[] arrayId = Material.GetArrayIdMaterials(materialDataGridView, WorkWithDataDgv.GetListIndexesSelectedRows(materialDataGridView));

                        // Если материалы не используются
                        if (!Material.MaterialsAreUsed(arrayId))
                        {
                            // Создаём массив выбранных материалов
                            Material[] materials = Material.GetArrayMaterials(materialDataGridView, WorkWithDataDgv.GetListIndexesSelectedRows(materialDataGridView));

                            // Удаляем материалы из базы данных
                            if (Material.DeleteMaterial(materials) == materials.Length)
                            {
                                MessageBox.Show("Запись(-и) успешно удалена(-ы)!", "Удаление материалов", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Выводим новые данные и очищаем текстовые поля
                                ReloadData();
                                ClearBoxes();

                                // Устанавливаем значения и свойства полям для поиска
                                WorkWithDataDgv.SetElementsForSearchStringData(materialDataGridView, columnComboBox, searchTextBox);

                            }
                            else
                            {
                                MessageBox.Show("Ошибка удаления материала(-ов)", "Удаление материалов", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                            MessageBox.Show("Невозможно удалить материал, так как он используется в печатных продукциях. Удалите печатные продукции, в которых используется выбранный материал, и повторите попытку", "Удаления материалов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    // Номер выбранной записи
                    int numberRow = WorkWithDataDgv.NumberSelectedRows(materialDataGridView);

                    // Если материал не используется
                    if (!Material.MaterialIsUsed(Material.GetIdMaterial(materialDataGridView.Rows[numberRow].Cells["Тип"].Value.ToString(), materialDataGridView.Rows[numberRow].Cells["Цвет"].Value.ToString(), materialDataGridView.Rows[numberRow].Cells["Размер"].Value.ToString(), Convert.ToDouble(materialDataGridView.Rows[numberRow].Cells["Стоимость"].Value))))
                    {
                        // Заполняем поля для ввода данными, выбранными пользователем
                        GetDataSelectedMaterial(WorkWithDataDgv.NumberSelectedRows(materialDataGridView));

                        changeButton.Enabled = true;
                        selectForChangeButton.Enabled = false;
                        addButton.Enabled = false;
                        deleteButton.Enabled = false;
                        resetChangeButton.Enabled = true;
                    }
                    else
                        MessageBox.Show("Невозможно удалить материал, так как он используется в печатных продукциях. Удалите печатные продукции, в которых используется выбранный материал, или создайте новый материал", "Выбор материала для изменения", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    MessageBox.Show("Поля для ввода должны быть заполнены. Должно быть выбрано только одно значение для размера. Стоимость должна быть числом больше нуля.", "Изменение материала", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    // Создаём материал
                    string size = ValueInputSize();
                    Material material = new Material(typeComboBox.Text, color, size, double.Parse(costTextBox.Text));

                    // Если запись с такими данными уже существует в базе данных
                    if (material.ExistMaterial(materialDataGridView))
                    {
                        MessageBox.Show("Данная запись уже существует в базе данных", "Изменение материала", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (MessageBox.Show("Вы точно хотите изменить эту запись?", "Изменение материала", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            // Изменяем данные выбранного материала
                            if (material.ChangeMaterial(id) == 1)
                            {
                                MessageBox.Show("Запись успешно изменена!", "Изменение материала", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Выводим новые данные и очищаем текстовые поля 
                                ReloadData();
                                ClearBoxes();

                                addButton.Enabled = true;
                                deleteButton.Enabled = true;
                                changeButton.Enabled = false;
                                selectForChangeButton.Enabled = true;
                                resetChangeButton.Enabled = false;
                                
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

            SetColumnsWidth();
        }

        private void materialDataGridView_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void resetChangeButton_Click(object sender, EventArgs e)
        {
            // Очищаем поля и приводим кнопки в нужное состояние
            ClearBoxes();

            selectForChangeButton.Enabled = true;
            changeButton.Enabled = false;
            addButton.Enabled = true;
            deleteButton.Enabled = true;
            resetChangeButton.Enabled = false;

        }

        private void searchCostButton_Click(object sender, EventArgs e)
        {
            if (materialDataGridView.Rows.Count < 1)
                MessageBox.Show("Отсутствуют строки для поиска", "Поиск по стоимости", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        MessageBox.Show("Значение правого текстового поля должно быть больше левого", "Поиск материала по стоимости", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        // Производим поиск по стоимости
                        WorkWithDataDgv.SearchByDifference(materialDataGridView, "Стоимость", from, to);
                        //WorkWithDataDgv.SetHeightRows(materialDataGridView);
                    }
                }

                catch
                {
                    MessageBox.Show("Ошибка поиска материала по стоимости. Убедитесь, что вы заполнили нужные текстовые поля, и повторите попытку", "Поиск материала по стоимости", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }

        private void resetCostButton_Click(object sender, EventArgs e)
        {
            
                // Сбрасываем поиск
                WorkWithDataDgv.ResetSearch(materialDataGridView);
                searchTextBox.Text = "";
                fromTextBox.Text = "1";
                toTextBox.Text = "100";
                //WorkWithDataDgv.SetHeightRows(materialDataGridView);
            
        }

        private void popDataAbMaterialButton_Click(object sender, EventArgs e)
        {
            // Если есть записи в таблице, то открываем форму с популярными данными
            if (materialDataGridView.Rows.Count > 0)
            {
                //PopularDataMaterialMenu popularDataMaterialMenu = new PopularDataMaterialMenu();
                //Transition.TransitionByForms(this, popularDataMaterialMenu);

                OccurrenceMaterialData popularMaterialData = new OccurrenceMaterialData();
                Transition.TransitionByForms(this, popularMaterialData);
            }
            else
                MessageBox.Show("Невозможно вывести моду данных о материалах, так они отсутствуют!", "Вывод моды данных о материалах", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void selectColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK) 
            {
                color = colorDialog.Color.R + ";" + colorDialog.Color.G + ";" + colorDialog.Color.B;
                colorInfoLabel.Text = "Цвет выбран!";
            }
        }

        
        private void selectAllRowsButton_Click(object sender, EventArgs e)
        {
            if (materialDataGridView.Rows.Count < 1)
                MessageBox.Show("Отсутствуют строки для выбора", "Выбрать всё", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                WorkWithDataDgv.SelectOrCancelSelectAllRows(materialDataGridView, true);
        }

        private void cancelSelectRowsButton_Click(object sender, EventArgs e)
        {
            if (materialDataGridView.Rows.Count < 1)
                MessageBox.Show("Отсутствуют строки", "Отменить выбор строк", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                WorkWithDataDgv.SelectOrCancelSelectAllRows(materialDataGridView, false);
            
        }


        private void costTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Получаем символ, который ввёл пользователь
            char number = e.KeyChar;

            // Если пользователь ввёл не цифру,запятую и не нажал на Backspace, то не отображаем символ в textbox
            if (!Char.IsDigit(number) && number != 44 && number != 8)
                e.Handled = true;
        }
    }
}
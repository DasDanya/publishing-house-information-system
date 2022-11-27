using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Linq;
using System.Text.RegularExpressions;

namespace PublishingHouse
{
    public partial class PrintingHouseMenu : Form
    {
        PrintingHouse printingHouse;
        char state = ' ';
        public PrintingHouseMenu()
        {
            InitializeComponent();
        }

        public PrintingHouseMenu(PrintingHouse printingHouse, char state) 
        {
            InitializeComponent();
            this.printingHouse = printingHouse;
            this.state = state;

        }


        private void PrintingHouseMenu_Load(object sender, EventArgs e)
        {
            //Загружаем иконки для вкладок
            IconImage.LoadIconBackTab(backTab);
            PrintingHouse.LoadPrintingHouse(printingHouseDataGridView);

            // Если пользователь добавляет запись
            if (printingHouse != null && state == 'A')
            {
                infoLabel.Text = "Вы можете добавить запись";
            }

            // Если пользователь изменяет запись
            else if (printingHouse != null && state == 'C') 
            {
                addButton.Enabled = false;
                deleteButton.Enabled = false;
                changeButton.Enabled = true;

                infoChangeLabel.Text = "Вы можете изменить запись";
            }

        }

        /// <summary>
        /// Метод вывода новых данных из бд
        /// </summary>
        private void ReloadData()
        {
            // Удаляем все строки из таблицы
            while (printingHouseDataGridView.Rows.Count != 0)
            {
                printingHouseDataGridView.Rows.Remove(printingHouseDataGridView.Rows[printingHouseDataGridView.Rows.Count - 1]);
            }

            // Загружаем новые данные
            PrintingHouse.LoadPrintingHouse(printingHouseDataGridView);

        }

        private void backTab_Click(object sender, EventArgs e)
        {
            // Переход к основному меню
            MainMenu mainMenu = new MainMenu();
            Transition.TransitionByForms(this, mainMenu);
        }

        private void PrintingHouseMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Если пользователь не ввёл данные о типографии
                if (printingHouse == null && state != 'A')
                    MessageBox.Show("Перед добавлением данных о типографии необходимо ввести их", "Добавление типографии", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    if (printingHouse.AddPrintingHouse() == 1)
                    {
                        MessageBox.Show("Запись успешно добавлена!", "Добавление типографии", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        infoLabel.Text = "";
                        
                        // Выводим новые данные и очищаем буффер
                        ReloadData();
                        ClearBuffer();
                    }

                    else
                        MessageBox.Show("Запись не была добавлена или неоднократно добавлена", "Добавление типографии", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch 
            {
                MessageBox.Show("Ошибка добавления данных о типографии", "Добавление типографии", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

                
        }


        private void inputButton_Click(object sender, EventArgs e)
        {
            // Переходим в меню для ввода данных
            FillDataPrintingHouse fillDataPrintingHouse = new FillDataPrintingHouse('A');
            Transition.TransitionByForms(this, fillDataPrintingHouse);
        }

        private void printingHouseDataGridView_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void searchTab_Click(object sender, EventArgs e)
        {
            // Отображаем компоненты для поиска данных
            ordersTreeView.Visible = true;
            searchOrdersButton.Visible = true;
            addButton.Visible = false;
            inputButton.Visible = false;
            deleteButton.Visible = false;
            selectForChangeButton.Visible = false;
            resetChangeButton.Visible = false;
            changeButton.Visible = false;
            infoChangeLabel.Visible = false;
            infoLabel.Visible = false;
            columnsLabel.Visible = true;
            columnsComboBox.Visible = true;
            fashionButton.Visible = true;
            searchDataLabel.Visible = true;
            searchTextBox.Visible = true;

            // Устанавливаем значения и свойства полям для поиска
            WorkWithDataDgv.SetElementsForSearchStringData(printingHouseDataGridView, columnsComboBox, searchTextBox);
        }

        private void processingTab_Click(object sender, EventArgs e)
        {
            // Отображаем компоненты для обработки данных
            ordersTreeView.Nodes.Clear();
            ordersTreeView.Visible = false;
            searchOrdersButton.Visible = false;
            deleteButton.Visible = true;
            addButton.Visible = true;
            inputButton.Visible = true;
            selectForChangeButton.Visible = true;
            resetChangeButton.Visible = true;
            changeButton.Visible = true;
            infoChangeLabel.Visible = true;
            infoLabel.Visible = true;
            columnsLabel.Visible = false;
            columnsComboBox.Visible = false;
            fashionButton.Visible = false;
            searchTextBox.Visible = false;
            searchDataLabel.Visible = false;
    
        }

        private void searchOrdersButton_Click(object sender, EventArgs e)
        {
            try
            {
                ordersTreeView.Nodes.Clear();
                // Если пользователь выбрал 0 или несколько записей
                if (WorkWithDataDgv.CountSelectedRows(printingHouseDataGridView) != 1)
                    MessageBox.Show("Неодходимо выбрать одну запись", "Поиск заказов", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else 
                {
                    // Получаем список заказов
                    List<string> orders = PrintingHouse.GetNumbersOfOrdersThisPrintingHouse(printingHouseDataGridView.Rows[WorkWithDataDgv.NumberSelectedRows(printingHouseDataGridView)].Cells["Электронная почта"].Value.ToString());

                    // Если список пуст
                    if (orders.Count == 0)
                        MessageBox.Show("Выбранная типография не выполняет заказы", "Поиск заказов", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        // Выводим номера заказов
                        foreach (string order in orders)
                        {
                            ordersTreeView.Nodes.Add(order);
                        }
                    }


                }
            }
            catch
            {
                MessageBox.Show("Ошибка поиска заказов", "Поиск заказов", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //try
            //{
                // Если пользователь выбрал 0 или несколько записей
                if (WorkWithDataDgv.CountSelectedRows(printingHouseDataGridView) < 1)
                    MessageBox.Show("Неодходимо выбрать одну или несколько записей", "Удаление типографий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);   
                else 
                {
                    // Если пользователь соглашается на удаление записи(-ей)
                    if (MessageBox.Show("Вы точно хотите удалить эту(-и) запись(-и)?", "Удаление типографий", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        // Получаем массив id
                        int[] arrayId = PrintingHouse.GetArrayIdPrintingHouse(printingHouseDataGridView, WorkWithDataDgv.GetListIndexesSelectedRows(printingHouseDataGridView));

                        // Если мы удалили указанное количество записей
                        if (PrintingHouse.DeletePrintingHouses(arrayId) == arrayId.Length)
                        {
                            MessageBox.Show("Записи успешно удалены!", "Удаление типографий", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ReloadData();
                        }
                        else
                        {
                            MessageBox.Show("Количество удаленных записей не совпаадает с количеством выбранных записей", "Удаление типографий", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Удаление типографий", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            
        }

        private void selectForChangeButton_Click(object sender, EventArgs e)
        {
            // Если количество выбранный записей не равно 1
            if (WorkWithDataDgv.CountSelectedRows(printingHouseDataGridView) != 1)
                MessageBox.Show("Неодходимо выбрать одну запись", "Выбор записи для её изменения", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
            else 
            {
                // Получаем номер выбранной записи и создаём объект типографии
                int numberRow = WorkWithDataDgv.NumberSelectedRows(printingHouseDataGridView);
                PrintingHouse printingHouse = new PrintingHouse(printingHouseDataGridView.Rows[numberRow].Cells["Название"].Value.ToString(), printingHouseDataGridView.Rows[numberRow].Cells["Номер телефона"].Value.ToString(), printingHouseDataGridView.Rows[numberRow].Cells["Электронная почта"].Value.ToString(),
                    printingHouseDataGridView.Rows[numberRow].Cells["Тип субъекта"].Value.ToString(), printingHouseDataGridView.Rows[numberRow].Cells["Название субъекта"].Value.ToString(), printingHouseDataGridView.Rows[numberRow].Cells["Город"].Value.ToString(), printingHouseDataGridView.Rows[numberRow].Cells["Тип улицы"].Value.ToString(),
                    printingHouseDataGridView.Rows[numberRow].Cells["Название улицы"].Value.ToString(), printingHouseDataGridView.Rows[numberRow].Cells["Дом №"].Value.ToString());

                // Переходим в меню ввода данных для изменения этих самых данных
                FillDataPrintingHouse fillDataPrintingHouse = new FillDataPrintingHouse(printingHouse, 'C');
                Transition.TransitionByForms(this, fillDataPrintingHouse);
                

            }
        }

        /// <summary>
        /// Метод очистки значений для буфферных переменных
        /// </summary>
        private void ClearBuffer()
        {
            printingHouse = null;
            state = ' ';
        }

        private void resetChangeButton_Click(object sender, EventArgs e)
        {
            // Приводим буфферные данные и компоненты в состояние по умолчанию
            ClearBuffer();
            deleteButton.Enabled = true;
            addButton.Enabled = true;
            changeButton.Enabled = false;
            infoChangeLabel.Text = "";
            infoLabel.Text = "";
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            // Ищём запрашиваемые данные в таблице
            WorkWithDataDgv.GetLikeString(printingHouseDataGridView, columnsComboBox, searchTextBox);
        }

        private void fashionButton_Click(object sender, EventArgs e)
        {
            if (printingHouseDataGridView.Rows.Count > 0) 
            {
                FashionDataPrHouseMenu fashionDataPrHouseMenu = new FashionDataPrHouseMenu();
                Transition.TransitionByForms(this, fashionDataPrHouseMenu);

            }
            else
                MessageBox.Show("Невозможно вывести моду данных о типографиях, так они отсутствуют!", "Вывод моды данных о типографиях", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

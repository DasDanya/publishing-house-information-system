using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace PublishingHouse
{
    public partial class PrintingHouseMenu : Form
    {
        PrintingHouse printingHouse;
        char state = ' ';
        int id = -1;
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

        public PrintingHouseMenu(PrintingHouse printingHouse, char state, int id) 
        {
            InitializeComponent();
            this.printingHouse = printingHouse;
            this.state = state;
            this.id = id;
        }

        private void PrintingHouseMenu_Load(object sender, EventArgs e)
        {
 
            LoadTable();

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

        private void LoadTable() 
        {
            // Загружаем в таблицу данные
            PrintingHouse.LoadPrintingHouse(printingHouseDataGridView);
            WorkWithDataDgv.SetReadOnlyColumns(printingHouseDataGridView);
            printingHouseDataGridView.Columns["Номер телефона"].Width = 148;
            printingHouseDataGridView.Columns["Электронная почта"].Width = 210;
            printingHouseDataGridView.Columns["Название субъекта"].Width = 150;
            printingHouseDataGridView.Columns["Дом №"].Width = 90;
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
            LoadTable();

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
                if (printingHouse == null || state != 'A')
                    MessageBox.Show("Перед добавлением данных о типографии необходимо ввести их", "Добавление типографии", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    if (printingHouse.AddPrintingHouse() == 1)
                    {
                        MessageBox.Show("Запись успешно добавлена!", "Добавление типографии", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Выводим новые данные и делаем комноненты и переменные в состояние по умолчанию
                        ReloadData();
                        DefaultStateOfMenu();
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
            selectAllButton.Visible = false;
            resetSelectButton.Visible = false;

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
            selectAllButton.Visible = false;
            resetSelectButton.Visible = false;

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

                        // Выводим наименование типографии
                        ordersTreeView.Nodes.Add(printingHouseDataGridView.Rows[WorkWithDataDgv.NumberSelectedRows(printingHouseDataGridView)].Cells[1].Value.ToString());

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
            try
            {
                // Если пользователь выбрал 0 записей
                if (WorkWithDataDgv.CountSelectedRows(printingHouseDataGridView) < 1)
                    MessageBox.Show("Неодходимо выбрать одну или несколько записей", "Удаление типографий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);   
                else 
                {
                    // Если пользователь соглашается на удаление записи(-ей)
                    if (MessageBox.Show("Вы точно хотите удалить эту(-и) запись(-и)?", "Удаление типографий", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        // Получаем массив id
                        int[] arrayId = PrintingHouse.GetArrayIdPrintingHouse(printingHouseDataGridView, WorkWithDataDgv.GetListIndexesSelectedRows(printingHouseDataGridView));

                        // Если типография(-и) не выполняет(-ют) заказ
                        if (!PrintingHouse.PrintingHousesIsWorking(arrayId))
                        {
                            // Если мы удалили указанное количество записей
                            if (PrintingHouse.DeletePrintingHouses(arrayId) == arrayId.Length)
                            {
                                MessageBox.Show("Записи успешно удалены!", "Удаление типографий", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ReloadData();
                                
                            }
                            else
                            {
                                MessageBox.Show("Количество удаленных записей не совпадает с количеством выбранных записей", "Удаление типографий", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                            MessageBox.Show("Невозможно удалить записи, так как существует заказ(-ы) с выбранной(-ыми) типографиями. Удалите заказ(-ы), где присутствуют выбранные типографии и повторите попытку", "Удаление типографий", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        
                    }
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка удаления типографий", "Удаление типографий", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void selectForChangeButton_Click(object sender, EventArgs e)
        {
            // Если количество выбранный записей не равно 1
            if (WorkWithDataDgv.CountSelectedRows(printingHouseDataGridView) != 1)
                MessageBox.Show("Неодходимо выбрать одну запись", "Выбор записи для её изменения", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
            else 
            {
                int numberRow = WorkWithDataDgv.NumberSelectedRows(printingHouseDataGridView);

                // Если типография(-и) не выполняет(-ют) заказ
                if (!PrintingHouse.PrintingHouseIsWorking(PrintingHouse.GetIdPrintingHouseByEmail(printingHouseDataGridView.Rows[numberRow].Cells["Электронная почта"].Value.ToString())))
                {
                    // Создаём объект типографии
                    PrintingHouse printingHouse = new PrintingHouse(printingHouseDataGridView.Rows[numberRow].Cells["Название"].Value.ToString(), printingHouseDataGridView.Rows[numberRow].Cells["Номер телефона"].Value.ToString(), printingHouseDataGridView.Rows[numberRow].Cells["Электронная почта"].Value.ToString(),
                        printingHouseDataGridView.Rows[numberRow].Cells["Тип субъекта"].Value.ToString(), printingHouseDataGridView.Rows[numberRow].Cells["Название субъекта"].Value.ToString(), printingHouseDataGridView.Rows[numberRow].Cells["Город"].Value.ToString(), printingHouseDataGridView.Rows[numberRow].Cells["Тип улицы"].Value.ToString(),
                        printingHouseDataGridView.Rows[numberRow].Cells["Название улицы"].Value.ToString(), printingHouseDataGridView.Rows[numberRow].Cells["Дом №"].Value.ToString());

                    // Переходим в меню ввода данных для изменения этих самых данных
                    FillDataPrintingHouse fillDataPrintingHouse = new FillDataPrintingHouse(printingHouse, 'C');
                    Transition.TransitionByForms(this, fillDataPrintingHouse);
                }
                else
                    MessageBox.Show("Невозможно изменить запись, так как существует заказ(-ы) с выбранной типографией. Удалите заказ(-ы), где присутствуют выбранная типография, или создайте новую типографию", "Выбор для изменения", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }
        }

        /// <summary>
        /// Метод очистки значений для буфферных переменных
        /// </summary>
        private void ClearBuffer()
        {
            printingHouse = null;
            state = ' ';
            id = -1;
        }

        private void resetChangeButton_Click(object sender, EventArgs e)
        {
            // Приводим буфферные данные и компоненты в состояние по умолчанию
            DefaultStateOfMenu();
        }

        /// <summary>
        /// Метод,который приводит компоненты и переменные в состояние по умолчанию
        /// </summary>
        private void DefaultStateOfMenu() 
        {
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

        private void changeButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Если пользователь изменяет запись
                if (MessageBox.Show("Вы точно хотите изменить запись?", "Изменение данных о типографии", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                  
                        int countChangeRows = printingHouse.ChangePrintingHouse(id);
                    // Если изменилась только одна запись 
                    if (countChangeRows == 1)
                        MessageBox.Show("Запись успешно изменена!", "Изменение данных о типографии", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    else
                        MessageBox.Show("Количество измененных записей не равно единице", "Изменение данных о типографии", MessageBoxButtons.OK, MessageBoxIcon.Error); 


                        ReloadData();
                        DefaultStateOfMenu();
                    
                }
            }
            catch
            {               
                MessageBox.Show("Ошибка изменения данных о типографии", "Изменение данных о типографии", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void selectTab_Click(object sender, EventArgs e)
        {
            selectAllButton.Visible = true;
            resetSelectButton.Visible = true;
            ordersTreeView.Visible = false;
            searchOrdersButton.Visible = false;
            addButton.Visible = false;
            inputButton.Visible = false;
            deleteButton.Visible = false;
            selectForChangeButton.Visible = false;
            resetChangeButton.Visible = false;
            changeButton.Visible = false;
            infoChangeLabel.Visible = false;
            infoLabel.Visible = false;
            columnsLabel.Visible = false;
            columnsComboBox.Visible = false;
            fashionButton.Visible = false;
            searchDataLabel.Visible = false;
            searchTextBox.Visible = false;
        }

        private void selectAllButton_Click(object sender, EventArgs e)
        {
            if (printingHouseDataGridView.Rows.Count < 1)
                MessageBox.Show("Отсутствуют строки для выбора", "Выбрать всё", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                WorkWithDataDgv.SelectOrCancelSelectAllRows(printingHouseDataGridView, true);
        }

        private void resetSelectButton_Click(object sender, EventArgs e)
        {
            if (printingHouseDataGridView.Rows.Count < 1)
                MessageBox.Show("Отсутствуют строки", "Отменить выбор строк", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                WorkWithDataDgv.SelectOrCancelSelectAllRows(printingHouseDataGridView, false);
        }
    }
}

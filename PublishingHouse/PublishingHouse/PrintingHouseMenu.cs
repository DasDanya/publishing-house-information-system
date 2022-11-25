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
        public PrintingHouseMenu()
        {
            InitializeComponent();
        }

        public PrintingHouseMenu(PrintingHouse printingHouse) 
        {
            InitializeComponent();
            this.printingHouse = printingHouse;
        }


        private void PrintingHouseMenu_Load(object sender, EventArgs e)
        {
            //Загружаем иконки для вкладок
            IconImage.LoadIconBackTab(backTab);
            PrintingHouse.LoadPrintingHouse(printingHouseDataGridView);

            // Если пользователь ввёл данные о типографии
            if(printingHouse != null) 
            {
                infoLabel.Text = "Вы можете добавить запись";
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
                if (printingHouse == null)
                    MessageBox.Show("Перед добавлением данных о типографии необходимо ввести их", "Добавление типографии", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    if (printingHouse.AddPrintingHouse() == 1)
                    {
                        MessageBox.Show("Запись успешно добавлена!", "Добавление типографии", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        infoLabel.Text = "";

                        // Выводим новые данные 
                        ReloadData();
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

        /// <summary>
        /// Метод проверки правильности введенных данных
        /// </summary>
        private void CorrectInputData() 
        {
            //if (nameTextBox.Text == "" || !phoneNumberTextBox.MaskCompleted || !IsCorrectEmail(emailTextBox.Text) || !IsCorrectPartOfAddress(stateTextBox.Text)
            //    || !IsCorrectPartOfAddress(cityTextBox.Text) || !IsCorrectPartOfAddress(stateTextBox.Text) || !IsCorrectNumberOfHouse(houseTextBox.Text))

            

            
        }

        /// <summary>
        /// Метод проверки электронной почты на корректность
        /// </summary>
        /// <param name="email">Электронная почта</param>
        /// <returns>Корректна ли электронная почта</returns>
        private bool IsCorrectEmail(string email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        
        /// <summary>
        /// Метод проверки части адреса на корректность
        /// </summary>
        /// <param name="part">Часть адреса</param>
        /// <returns>Корректна ли часть адреса</returns>
        private bool IsCorrectPartOfAddress(string part) 
        {
            if (part.All(Char.IsLetter) && part != "" && Regex.IsMatch(part, "^[А-Яа-я]+$"))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Метод проверки номера дома на корректность
        /// </summary>
        /// <param name="house">Номер дома</param>
        /// <returns>Корректен ли номер дома</returns>
        private bool IsCorrectNumberOfHouse(string house) 
        {
            if (Regex.IsMatch(house, @"^[1-9]\d*(?: ?(?:[А-Га-г]|[/] ?\d+))?$"))
                return true;
            else
                return false;
        }

        private void inputButton_Click(object sender, EventArgs e)
        {
            FillDataPrintingHouse fillDataPrintingHouse = new FillDataPrintingHouse();
            Transition.TransitionByForms(this, fillDataPrintingHouse);
        }

        private void printingHouseDataGridView_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void searchTab_Click(object sender, EventArgs e)
        {
            ordersTreeView.Visible = true;
            searchOrdersButton.Visible = true;
            addButton.Visible = false;
            inputButton.Visible = false;
            deleteButton.Visible = false;

        }

        private void processingTab_Click(object sender, EventArgs e)
        {
            ordersTreeView.Nodes.Clear();
            ordersTreeView.Visible = false;
            searchOrdersButton.Visible = false;
            deleteButton.Visible = true;
            addButton.Visible = true;
            inputButton.Visible = true;
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
                    if (MessageBox.Show("Вы точно хотите удалить эту(-и) запись(-и)?", "Удаление типографий", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        int[] arrayId = PrintingHouse.GetArrayIdPrintingHouse(printingHouseDataGridView, WorkWithDataDgv.GetListIndexesSelectedRows(printingHouseDataGridView));

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
            if (WorkWithDataDgv.CountSelectedRows(printingHouseDataGridView) != 1)
                MessageBox.Show("Неодходимо выбрать одну запись", "Выбор записи для её изменения", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
            else 
            {
                int numberRow = WorkWithDataDgv.NumberSelectedRows(printingHouseDataGridView);
                PrintingHouse printingHouse = new PrintingHouse(printingHouseDataGridView.Rows[numberRow].Cells["Название"].Value.ToString(), printingHouseDataGridView.Rows[numberRow].Cells["Номер телефона"].Value.ToString(), printingHouseDataGridView.Rows[numberRow].Cells["Электронная почта"].Value.ToString(),
                    printingHouseDataGridView.Rows[numberRow].Cells["Тип субъекта"].Value.ToString(), printingHouseDataGridView.Rows[numberRow].Cells["Название субъекта"].Value.ToString(), printingHouseDataGridView.Rows[numberRow].Cells["Город"].Value.ToString(), printingHouseDataGridView.Rows[numberRow].Cells["Тип улицы"].Value.ToString(),
                    printingHouseDataGridView.Rows[numberRow].Cells["Название улицы"].Value.ToString(), printingHouseDataGridView.Rows[numberRow].Cells["Дом №"].Value.ToString());

            }

            
        }
    }
}

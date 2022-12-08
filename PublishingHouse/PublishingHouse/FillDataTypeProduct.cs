using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PublishingHouse
{
    public partial class FillDataTypeProduct : Form
    {
        TypeProduct typeProduct = null;
        int id = -1;
        char state = ' ';
        public FillDataTypeProduct()
        {
            InitializeComponent();
        }

        public FillDataTypeProduct(char state) 
        {
            InitializeComponent();
            this.state = state;
        }

        public FillDataTypeProduct(TypeProduct typeProduct,char state)
        {
            InitializeComponent();
            this.typeProduct = typeProduct;
            this.state = state;
        }


        private void FillDataTypeProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void backTab_Click(object sender, EventArgs e)
        {
            TypesProductMenu typesProductMenu = new TypesProductMenu();
            Transition.TransitionByForms(this, typesProductMenu);
        }

        private void marginTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Получаем символ, который ввёл пользователь
            char number = e.KeyChar;

            // Если пользователь ввёл не цифру, не нажал на Backspace или запятую, то не отображаем символ в textbox
            if (!Char.IsDigit(number) && number != 8 && number != 44)
                e.Handled = true;
        }

        private void FillDataTypeProduct_Load(object sender, EventArgs e)
        {
            try
            {
                if (typeProduct != null && state == 'C')
                {
                    LoadDataAboutTypeProduct();
                    id = TypeProduct.GetIdTypeProduct(typeProduct.Name, typeProduct.Margin);
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка открытия формы для ввода данных о типе печатной продукции", "Ввод данных о типе печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод заполнения данных о типе печатной продукции в соответствующие поля
        /// </summary>
        private void LoadDataAboutTypeProduct() 
        {
            nameTextBox.Text = typeProduct.Name;
            marginTextBox.Text = typeProduct.Margin.ToString();
        }

        /// <summary>
        /// Метод проверки введённых данных
        /// </summary>
        /// <returns>Правильно ли введены данные</returns>
        private bool CorrectInputData()
        {
            if (nameTextBox.Text == "" || marginTextBox.Text == "" || double.Parse(marginTextBox.Text) == 0 || !CorrectInput.IsRussianString(nameTextBox.Text))
            {
                return false;
            }
            else
                return true;
        }

        private void saveInputDataButton_Click(object sender, EventArgs e)
        {
            TypesProductMenu typesProductMenu = new TypesProductMenu();

            try
            {
                // Если пользователь ввёл корректные данные
                if (CorrectInputData())
                {
                    string name = "";
                    double margin = 0;

                    if (state == 'C')
                    {
                        // Текущие данные о названии типа печатной продукции
                        name = this.typeProduct.Name;
                        margin = this.typeProduct.Margin;
                    }

                    // Если существует тип печатной продукции с введенными данными
                    if (!TypeProduct.ExistTypeProductInDb(state,margin,Convert.ToDouble(marginTextBox.Text), name, nameTextBox.Text))
                    {

                        // Создаём тип печатной продукции
                        TypeProduct typeProduct = new TypeProduct(nameTextBox.Text, Convert.ToDouble(marginTextBox.Text));


                        // Возвращаемся в меню типов печатной продукции
                        if (state == 'A')                           
                            typesProductMenu = new TypesProductMenu(typeProduct, state);
                        else if (state == 'C')
                            typesProductMenu = new TypesProductMenu(typeProduct, state, id);



                        Transition.TransitionByForms(this, typesProductMenu);
                    }
                    else
                        MessageBox.Show("В базе данных не могут существовать типы печатной продукции с одинаковым названием и одинаковой наценкой", "Сохранение данных о типе печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                    MessageBox.Show("Текстовые поля должны быть заполнены! Название типа печатной продукции может в себе содержать только русские буквы и пробелы", "Сохранение данных о типе печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
                MessageBox.Show("Ошибка сохранения данных о типе печатной продукции", "Сохранение данных о о типе печатной продукции", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace PublishingHouse
{
   public class Product
    {

        string name;
        int numberEdition, prodEdition, idTypeProduct;
        byte[] design;
        double cost;
        List<Material> materials = new List<Material>();

        public string Name { get { return name; } }
        public int NumberEdition { get { return numberEdition; } }

        public Product(string name, int numberEdition)
        {
            this.name = name;
            this.numberEdition = numberEdition;
        }

        public Product(string name, int numberEdition, int prodEdition, int idTypeProduct, byte[] design, double cost, List<Material> materials) : this(name, numberEdition)
        {
            this.prodEdition = prodEdition;
            this.idTypeProduct = idTypeProduct;
            this.design = design;
            this.cost = cost;
            this.materials = materials;
        }


        /// <summary>
        /// Метод проверки существования печатной продукции в бд
        /// </summary>
        /// <param name="typeWork">Тип работы с данными</param>
        /// <param name="pastNumEdition">Старый номер тиража</param>
        /// <param name="newNumEdition">Новый номер тиража</param>
        /// <param name="pastName">Прошлое название</param>
        /// <param name="newName">Новое название</param>
        /// <returns>Существует ли печатная продукция в бд</returns>
        public static bool ExistProductInDb(char typeWork, int pastNumEdition, int newNumEdition, string pastName, string newName)
        {
            bool exist = false;

            try
            {
                ConnectionToDb.Open();
                SqlCommand command = new SqlCommand();

                // Если пользователь добавляет запись
                if (typeWork == 'A')
                {
                    // Запрос на существование печатной продукции
                    command = new SqlCommand("SELECT prodId FROM product WHERE prodName = N'" + newName + "' AND prodNumEdition = '"+newNumEdition+"'", ConnectionToDb.Connection);             
                }


                // Если пользователь редактирует запись
                else if (typeWork == 'C')
                {
                    // Получаем id записи
                    int id = GetIdProduct(pastName, pastNumEdition);
                    ConnectionToDb.Open();

                    //Запрос на существование печатной продукции, не учитывая изменяемую запись 
                    command = new SqlCommand("SELECT COUNT(prodId) FROM product WHERE prodNumEdition = '"+newNumEdition+"' AND prodName = N'" + newName + "' AND prodId != '" + id + "' ", ConnectionToDb.Connection);

                }

                // Если печатная продукция найдена
                if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                    exist = true;


                ConnectionToDb.Close();
            }

            catch
            {
                throw new Exception("Ошибка проверки существования печатной продукции в базе данных");
            }

            return exist;
        }

        /// <summary>
        /// Метод получения id печатной продукции
        /// </summary>
        /// <param name="name">Название печатной продукции</param>
        /// <param name="numEdition">Номер тиража печатной продукции</param>
        /// <returns>id печатной продукции</returns>
        public static int GetIdProduct(string name, int numEdition)
        {
            int id = -1;

            try
            {
                ConnectionToDb.Open();

                // Формируем запрос на получение id печатной продукции и выполняем его
                SqlCommand command = new SqlCommand("SELECT prodId FROM product WHERE prodName = N'" + name + "' AND prodNumEdition = '" + numEdition + "'", ConnectionToDb.Connection);
                

                //Получаем id                 
                id = Convert.ToInt32(command.ExecuteScalar());

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения уникального номера записи о печатной продукции");
            }


            return id;
        }

        public static double GetCostProduct(DataGridView dataGridView, int margin, int countProduct) 
        {
            double cost = 0;

            try
            {
                double costWithoutMargin = 0;

                // Получаем стоимость без наценки
                for (int i = 0; i < dataGridView.RowCount; i++)
                {
                    costWithoutMargin += Convert.ToDouble(dataGridView.Rows[i].Cells["cost"].Value) * Convert.ToDouble(dataGridView.Rows[i].Cells["Count"].Value);
                }

                // Стоимость с наценкой
                cost = ((costWithoutMargin / 100) * (margin + 100)) * Convert.ToDouble(countProduct);
                cost = Math.Round(cost, 2);
            }
            catch 
            {
                throw new Exception("Ошибка подсчёта стоимости печатной продукции");
            }

            return cost;
        }

        public int AddProduct() 
        {
            int countSelectedRows = -1;

            try
            {
                ConnectionToDb.Open();

                // Формируем запрос на добавление типа печатной продукции и выполняем его
                SqlCommand command = new SqlCommand("INSERT INTO product (prodNumEdition, prodName, prodVisual, prodEdition, prodCost, ftypeProdId) VALUES ('"+numberEdition+"', N'"+name+"', @visual, '"+prodEdition+"', @cost, '"+idTypeProduct+"')", ConnectionToDb.Connection);
                command.Parameters.Add("@visual", SqlDbType.Image).Value = design;
                command.Parameters.Add("@cost", SqlDbType.Float).Value = cost;
                countSelectedRows = command.ExecuteNonQuery();

                // Получаем id добавленной печатной продукции и заполняем таблицу "Печатная продукция - Материал"
                int idProduct = GetIdProduct(name, numberEdition);
                if (!AddProductTypeProduct(materials, idProduct))
                    countSelectedRows = -1;

                ConnectionToDb.Close();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
                //throw new Exception("Ошибка добавления данных о печатной продукции");
            }

            return countSelectedRows;
        }

        /// <summary>
        /// Метод добавления данных в таблицу "Печатная продукция-Материал"
        /// </summary>
        /// <param name="materials">Список материалов</param>
        /// <param name="idProduct">id печатной продукции</param>
        /// <returns>Добавилось ли в таблицу указанное количество записей</returns>
        private static bool AddProductTypeProduct(List<Material> materials, int idProduct) 
        {
            bool success = false;
            int countAddRows = 0;
            try
            {
                ConnectionToDb.Open();

                // Добавляем данные в таблицу
                for (int i = 0; i < materials.Count; i++)
                {
                    SqlCommand command = new SqlCommand("INSERT INTO productMaterial (matCount, fprodId, fmatId) VALUES ('" + materials[i].Count + "', '" + idProduct + "', '" + materials[i].Id + "')", ConnectionToDb.Connection);
                    countAddRows += command.ExecuteNonQuery();         
                }

                // Если количество добавленных записей равно количеству записей в списке
                if (countAddRows == materials.Count)
                    success = true;

                ConnectionToDb.Close();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
                //throw new Exception("Ошибка добавления данных в таблицу \"Печатная продукция-Материал\"");
            }

            return success;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.IO;

namespace PublishingHouse
{
    public class Product
    {

        string name, nameTypeProduct;
        int numberEdition, prodEdition, idTypeProduct;
        byte[] design;
        double cost;
        Image designAsImage = null;
        List<Material> materials = new List<Material>();

        public string Name { get { return name; } }
        public string NameTypeProduct { get { return nameTypeProduct; } }
        public int NumberEdition { get { return numberEdition; } }
        public int ProdEdition { get { return prodEdition; } }
        public int IdTypeProduct { get { return idTypeProduct; } }
        public double Cost { get { return cost; } }
        public Image DesignAsImage { get { return designAsImage; } }
        public List<Material> Materials { get { return materials; } }


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

        public Product(string name, int numberEdition, int prodEdition, int idTypeProduct, Image designAsImage, List<Material> materials) : this(name, numberEdition)
        {
            this.prodEdition = prodEdition;
            this.idTypeProduct = idTypeProduct;
            this.designAsImage = designAsImage;
            this.materials = materials;
        }

        public Product(string name, string nameTypeProduct, int numberEdition, int prodEdition, Image designAsImage, List<Material> materials, double cost) : this(name, numberEdition)
        {
            this.nameTypeProduct = nameTypeProduct;
            this.prodEdition = prodEdition;
            this.designAsImage = designAsImage;
            this.materials = materials;
            this.cost = cost;
        }

        public Product(string name, int numberEdition, int prodEdition, double cost) : this(name, numberEdition)
        {
            this.prodEdition = prodEdition;         
            this.cost = cost;
        }

        public override string ToString()
        {
            return $"Название печатной продукции: {name}\nНомер тиража: {numberEdition}\nТираж: {prodEdition}\nСтоимость печатной продукции: {cost}";
        }

        /// <summary>
        /// Метод получения данных о печатной продукции
        /// </summary>
        /// <param name="idProduct">id печатной продукции</param>
        /// <returns>Данные о печатной продукции</returns>
        public static Product GetProduct(int idProduct) 
        {
            Product product = null;

            try
            {
                ConnectionToDb.Open();

                // Запрос на получение данных о печатной продукции
                SqlCommand command = new SqlCommand("SELECT * FROM product WHERE prodId = '"+idProduct+"'", ConnectionToDb.Connection);
                SqlDataReader reader = command.ExecuteReader();

                // Считываем полученные данные
                while (reader.Read()) 
                {
                    product = new Product(reader["prodName"].ToString(), Convert.ToInt32(reader["prodNumEdition"]), Convert.ToInt32(reader["prodEdition"]), Convert.ToDouble(reader["prodCost"]));
                }

                reader.Close();
                ConnectionToDb.Close();
            }
            catch 
            {
                throw new Exception("Ошибка получения данных о печатной продукции");
            }

            return product;
        }

        /// <summary>
        /// Метод проверки существования печатной продукции в бд
        /// </summary>
        /// <param name="typeWork">Тип работы с данными</param>
        /// <param name="pastNumEdition">Прошлый номер тиража</param>
        /// <param name="newNumEdition">Новый номер тиража</param>
        /// <param name="pastName">Прошлое название</param>
        /// <param name="newName">Новое название</param>
        /// <returns></returns>
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
                    command = new SqlCommand("SELECT prodId FROM product WHERE prodName = N'" + newName + "' AND prodNumEdition = '" + newNumEdition + "'", ConnectionToDb.Connection);
                }


                // Если пользователь редактирует запись
                else if (typeWork == 'C')
                {
                    // Получаем id записи
                    int id = GetIdProduct(pastName, pastNumEdition);
                    ConnectionToDb.Open();

                    //Запрос на существование печатной продукции, не учитывая изменяемую запись 
                    command = new SqlCommand("SELECT COUNT(prodId) FROM product WHERE prodNumEdition = '" + newNumEdition + "' AND prodName = N'" + newName + "' AND prodId != '" + id + "' ", ConnectionToDb.Connection);

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
        /// <param name="name">Название</param>
        /// <param name="numEdition">Номер тиража</param>
        /// <param name="idTypeProduct">id типа печатной продукции</param>
        /// <returns></returns>
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

        /// <summary>
        /// Метод подсчёта стоимости печатной продукции
        /// </summary>
        /// <param name="dataGridView">Таблица с материалами</param>
        /// <param name="margin">Наценка</param>
        /// <param name="countProduct">Количество печатной продукции</param>
        /// <returns>Стоимость печатной продукции</returns>
        public static double GetCostProduct(DataGridView dataGridView, double margin, int countProduct)
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

            return Math.Round(cost, 2);
        }

        /// <summary>
        /// Метод добавления печатной продукции
        /// </summary>
        /// <returns>1- если количество добавленных строк равно ожидаемому количеству добавленных строк</returns>
        public int AddProduct()
        {
            int countSelectedRows = -1;

            try
            {
                ConnectionToDb.Open();

                // Формируем запрос на добавление типа печатной продукции и выполняем его
                SqlCommand command = new SqlCommand("INSERT INTO product (prodNumEdition, prodName, prodVisual, prodEdition, prodCost, ftypeProdId) VALUES ('" + numberEdition + "', N'" + name + "', @visual, '" + prodEdition + "', @cost, '" + idTypeProduct + "')", ConnectionToDb.Connection);
                command.Parameters.Add("@visual", SqlDbType.Image).Value = design;
                command.Parameters.Add("@cost", SqlDbType.Float).Value = cost;
                countSelectedRows = command.ExecuteNonQuery();

                // Получаем id добавленной печатной продукции и заполняем таблицу "Печатная продукция - Материал"
                int idProduct = GetIdProduct(name, numberEdition);
                if (!AddProductTypeProduct(materials, idProduct))
                    countSelectedRows = -1;

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка добавления данных о печатной продукции");
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
            catch
            {
                throw new Exception("Ошибка добавления данных в таблицу \"Печатная продукция-Материал\"");
            }

            return success;
        }

        /// <summary>
        /// Метод удаления данных из таблицы "Печатная продукция-Материал"
        /// </summary>
        /// <param name="idProduct">id печатной продукции</param>
        /// <returns>Количество удаленных строк</returns>
        private static int DeleteProductTypeProduct(int idProduct)
        {
            int countDeletedRows = -1;
            try
            {
                ConnectionToDb.Open();

                SqlCommand command = new SqlCommand("DELETE FROM productMaterial WHERE fprodId = '" + idProduct + "' ", ConnectionToDb.Connection);
                countDeletedRows = command.ExecuteNonQuery();

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка удаления данных из таблицы \"Печатная продукция-Материал\"");
            }
            return countDeletedRows;
        }


        /// <summary>
        /// Метод загрузки данных о печатных продукциях в таблицу
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        public static void LoadProductsInTable(DataGridView dataGridView)
        {
            try
            {
                ConnectionToDb.Open();

                // Запрос на получение печатных продукций
                SqlCommand command = new SqlCommand("SELECT product.prodName AS N'Название', typeProduct.typeProdName AS N'Тип печ. продукции', product.prodNumEdition AS N'Номер тиража', product.prodEdition AS N'Тираж', product.prodCost AS N'Стоимость' FROM product JOIN typeProduct ON product.ftypeProdId = typeProduct.typeProdId ORDER BY product.prodName", ConnectionToDb.Connection);
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader();

                // Загружаем данные о печатных продукциях в таблицу
                DataTable dt = new DataTable();
                dt.Load(dataReader);
                dataGridView.DataSource = dt;

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения данных о печатных продукциях");
            }

        }

        /// <summary>
        /// Метод загрузки не успользуемых печатных продукций в таблицу
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        public static void LoadProductsWithoutOrdersInTable(DataGridView dataGridView)
        {
            try
            {
                ConnectionToDb.Open();

                // Запрос на получение печатных продукций
                SqlCommand command = new SqlCommand("SELECT product.prodName AS N'Название', typeProduct.typeProdName AS N'Тип печ. продукции', product.prodNumEdition AS N'Номер тиража', product.prodEdition AS N'Тираж', product.prodCost AS N'Стоимость' FROM product JOIN typeProduct ON product.ftypeProdId = typeProduct.typeProdId WHERE product.fbkId IS NULL ORDER BY product.prodName", ConnectionToDb.Connection);
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader();

                // Загружаем данные о печатных продукциях в таблицу
                DataTable dt = new DataTable();
                dt.Load(dataReader);
                dataGridView.DataSource = dt;

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения данных о печатных продукциях");
            }

        }

        /// <summary>
        /// Метод загрузки не успользуемых печатных продукций в таблицу
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        public static void LoadProductsWithoutOrdersInTable(DataGridView dataGridView, int idBooking)
        {
            try
            {
                ConnectionToDb.Open();

                // Запрос на получение печатных продукций
                SqlCommand command = new SqlCommand("SELECT product.prodName AS N'Название', typeProduct.typeProdName AS N'Тип печ. продукции', product.prodNumEdition AS N'Номер тиража', product.prodEdition AS N'Тираж', product.prodCost AS N'Стоимость' FROM product JOIN typeProduct ON product.ftypeProdId = typeProduct.typeProdId WHERE product.fbkId IS NULL OR product.fbkId = '"+idBooking+"' ORDER BY product.prodName", ConnectionToDb.Connection);
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader();

                // Загружаем данные о печатных продукциях в таблицу
                DataTable dt = new DataTable();
                dt.Load(dataReader);
                dataGridView.DataSource = dt;

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения данных о печатных продукциях");
            }

        }

        /// <summary>
        /// Метод получения макета печатной продукции из бд
        /// </summary>
        /// <param name="name">Название печатной продукции</param>
        /// <param name="numEdition">Номер тиража</param>
        /// <returns>Макет в виде массива байт</returns>
        private static byte[] GetPhotoProduct(string name, int numEdition)
        {
            byte[] photo = null;

            try
            {
                ConnectionToDb.Open();

                // Формируем запрос на получение фотографии печатной продукции и выполняем его
                SqlCommand command = new SqlCommand("SELECT prodVisual FROM product WHERE prodName = N'" + name + "' AND prodNumEdition = '" + numEdition + "'", ConnectionToDb.Connection);
                command.CommandType = CommandType.Text;
                photo = (byte[])command.ExecuteScalar();

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения фотографии макета печатной продукции");
            }

            return photo;
        }

        /// <summary>
        /// Метод получения изображения макета печатной продукции
        /// </summary>
        /// <param name="name">Название печатной продукции</param>
        /// <param name="idTypeProduct">id типа печатной продукции</param>
        /// <returns>Макет в виде Image</returns>
        public static Image GetPhotoAsImage(string name, int numEdition)
        {
            Image image = null;
            try
            {
                // Получаем фотографию пользователя из бд
                byte[] photo = GetPhotoProduct(name, numEdition);


                // Переводим изображение из массива байт в Image 
                MemoryStream stream = new MemoryStream(photo);
                image = Image.FromStream(stream);
            }
            catch
            {
                throw new Exception("Ошибка получения изображения");
            }

            return image;
        }

        /// <summary>
        /// Метод определения того, что печатная продукция указана в заказе
        /// </summary>
        /// <param name="idProduct">id печатной продукции</param>
        /// <returns>Печатная продукция указана в заказе</returns>
        public static bool ProductIsSpecified(int idProduct)
        {
            bool isSpecified = false;

            try
            {
                ConnectionToDb.Open();

                // Получаем количество заказов, где указана печатная продукция
                SqlCommand command = new SqlCommand("SELECT fbkId FROM product WHERE prodId = '" + idProduct + "'", ConnectionToDb.Connection);

                if (command.ExecuteScalar() != DBNull.Value)
                    isSpecified = true;

                ConnectionToDb.Close();
            }

            catch
            {
                throw new Exception("Ошибка получения данных о том, указана ли печатная продукция в заказе");
            }

            return isSpecified;
        }

        /// <summary>
        /// Метод определения того, что печатные продукции упоминаются хоть в одном заказе
        /// </summary>
        /// <param name="arrayIdProducts">Массив id печатных продукций</param>
        /// <returns>Упоминаются ли печатные продукции хоть в одном заказе</returns>
        public static bool ProductsAreSpecified(int[] arrayIdProducts)
        {
            bool areSpecified = false;

            try
            {

                for (int i = 0; i < arrayIdProducts.Length; i++)
                {
                    // Если заказ упоминается, то выходим из цикла
                    if (ProductIsSpecified(arrayIdProducts[i]))
                    {
                        areSpecified = true;
                        break;
                    }
                }

            }
            catch
            {
                throw new Exception("Ошибка получения данных о том, указаны ли печатные продукции в заказе(-ах)");
            }

            return areSpecified;
        }

        /// <summary>
        /// Метод изменения данных о печатной продукции
        /// </summary>
        /// <param name="idProduct">id печатной продукции</param>
        /// <returns>1 - если изменение прошло успешно</returns>
        public int ChangeProduct(int idProduct)
        {
            int countChangedRows = -1;
            try
            {
                ConnectionToDb.Open();

                // Формируем запрос на изменение данных о печатной продукции
                SqlCommand command = new SqlCommand("UPDATE product SET prodName = N'" + name + "', prodNumEdition = '" + numberEdition + "', prodVisual = @visual, prodEdition = '" + prodEdition + "', prodCost = @cost, ftypeProdId = '" + idTypeProduct + "' WHERE prodId = '" + idProduct + "'", ConnectionToDb.Connection);
                command.Parameters.Add("@visual", SqlDbType.Image).Value = design;
                command.Parameters.Add("@cost", SqlDbType.Float).Value = cost;
                countChangedRows = command.ExecuteNonQuery();

                // Если строки были удалены
                if (DeleteProductTypeProduct(idProduct) > 0)
                {
                    // Если количество добавленных строк в связующую таблицу равно ожидаемому количеству
                    if (AddProductTypeProduct(materials, idProduct))
                        countChangedRows = 1;
                }

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка изменения данных о печатной продукции");
            }

            return countChangedRows;
        }

        /// <summary>
        /// Метод получения массива id печатных продукций
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        /// <param name="selectedRows">Список номеров выбранных строк</param>
        /// <returns>Массив id печатных продукций</returns>
        public static int[] GetArrayIdProducts(DataGridView dataGridView, List<int> selectedRows)
        {
            int indexArray = 0;
            int[] arrayId = new int[selectedRows.Count];

            try
            {
                ConnectionToDb.Open();

                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    // Если список содержит индекс
                    if (selectedRows.Contains(i))
                    {
                        // Получаем данные о печатной продукции
                        string name = dataGridView.Rows[i].Cells["Название"].Value.ToString();
                        int numEdition = Convert.ToInt32(dataGridView.Rows[i].Cells["Номер тиража"].Value);

                        arrayId[indexArray++] = GetIdProduct(name, numEdition);
                    }
                }

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения массива идентификаторов записей о печатных продукциях");
            }

            return arrayId;
        }


        /// <summary>
        /// Метод удаления печатной продукции
        /// </summary>
        /// <param name="arrayId">Массив id печатной продукции</param>
        /// <returns>Количество удаленных строк</returns>
        public static int DeleteProducts(int[] arrayId)
        {
            int countDeleteRows = 0;

            try
            {

                // Проходимся по массиву id
                for (int i = 0; i < arrayId.Length; i++)
                {
                    // Сначала удаляем данные из таблицы "Печатная продукция-Материал"
                    if (DeleteProductTypeProduct(arrayId[i]) <= 0)
                        break;
                    else
                    {

                        ConnectionToDb.Open();

                        // Удаляем печатную продукцию с конкретным id
                        SqlCommand command = new SqlCommand("DELETE FROM product WHERE prodId = '" + arrayId[i] + "'", ConnectionToDb.Connection);
                        countDeleteRows += command.ExecuteNonQuery();
                    }
                }

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Произошла ошибка удаления печатной продукции");
            }
            return countDeleteRows;
        }


        /// <summary>
        /// Метод получения номера заказа, где указана печатная продукция
        /// </summary>
        /// <param name="idProduct">id печатной продукции</param>
        /// <returns>Номер заказа</returns>
        public static int GetNumberOfOrdersThisProduct(int idProduct)
        {
            int numOrder = -1;
            try
            {

                ConnectionToDb.Open();

                // Запрос на получение номера заказа
                SqlCommand command = new SqlCommand("SELECT fbkId FROM product WHERE prodId = '"+idProduct+"'", ConnectionToDb.Connection);
               
                //Получаем номер заказа
                numOrder = Convert.ToInt32(command.ExecuteScalar());

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка получения номера заказа");
            }

            return numOrder;
        }

        /// <summary>
        /// Метод, устанавливающий печатной продукции заказ
        /// </summary>
        /// <param name="idProducts">Массив id печатных продукций</param>
        /// <param name="idBooking"></param>
        /// <returns></returns>
        public static bool SetBooking(int[] idProducts, int idBooking) 
        {
            bool successSet = false;
            int countSet = 0;

            try
            {
                ConnectionToDb.Open();

                // Указываем каждой печатной продукции номер заказа
                for (int i = 0; i < idProducts.Length; i++)
                {
                    // Устанавливаем заказ
                    SqlCommand command = new SqlCommand("UPDATE product SET fbkId = '"+idBooking+"' WHERE prodId = '"+idProducts[i]+"'", ConnectionToDb.Connection);
                    countSet += command.ExecuteNonQuery();
                }

                // Если для каждой печатной продукции был указан заказ
                if (countSet == idProducts.Length)
                    successSet = true;

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка установки заказа печатной продукции");
            }

            return successSet;
        }

        /// <summary>
        /// Метод, который подсвечивает строки с данными о печатных продукциях
        /// </summary>
        /// <param name="dataGridView">Таблица</param>
        /// <param name="idProducts">Массив id печатных продукций</param>
        public static void SelectRowsInTable(DataGridView dataGridView, int[] idProducts)
        {
            try
            {
                ConnectionToDb.Open();

                // Если нет данных
                if (dataGridView.RowCount < 1 || idProducts.Length < 1)
                    return;

                else
                {
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        for (int j = 0; j < idProducts.Length; j++)
                        {
                            string name = dataGridView.Rows[i].Cells["Название"].Value.ToString();
                            int numEdition = Convert.ToInt32(dataGridView.Rows[i].Cells["Номер тиража"].Value);

                            // Если нашли печатную продукцию
                            if (idProducts[j] == GetIdProduct(name, numEdition))
                                dataGridView.Rows[i].Cells[0].Value = true;
                        }
                    }
                }

                ConnectionToDb.Close();
            }
            catch
            {
                throw new Exception("Ошибка поиска строк с данными о печатных продукциях");
            }
        }

        /// <summary>
        /// Метод сброса заказов
        /// </summary>
        /// <param name="idBooking">id заказа</param>
        /// <returns>Успешно ли сброшены заказы</returns>
        public static bool DeleteBooking(int idBooking)
        {
            bool success = false;

            try
            {
                ConnectionToDb.Open();
                
                // Запрос на сброс заказов
                SqlCommand command = new SqlCommand("UPDATE product SET fbkId = @value WHERE fbkId = '"+idBooking+"'", ConnectionToDb.Connection);
                command.Parameters.Add(new SqlParameter("@value", DBNull.Value));

                // Если сбросили заказы
                if (command.ExecuteNonQuery() > 0)
                    success = true;

                ConnectionToDb.Close();
            }
            catch 
            {
                throw new Exception("Ошибка удаления заказов");
            }

            return success;
        }

    }
}

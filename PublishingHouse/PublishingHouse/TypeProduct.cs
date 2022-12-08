using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PublishingHouse
{
    public class TypeProduct
    {
        string name;
        double margin;

        public string Name { get { return name; } }
        public double Margin { get { return margin; } }

        public TypeProduct(string name, double margin)
        {
            this.name = name;
            this.margin = margin;
        }

        public static int GetIdByName(string name) 
        {
            int id = -1;

            try
            {
                ConnectionToDb.Open();

                //Указываем,что команда является хранимой процедурой
                const string SQLPROCEDURE = "GetIdTypeProduct";
                SqlCommand command = new SqlCommand(SQLPROCEDURE, ConnectionToDb.Connection); 
                command.CommandType = CommandType.StoredProcedure;

                //Передаём название типа печатной продукции
                command.Parameters.AddWithValue("@name", name);

                //Получаем id 
                var result = new SqlParameter("@idTypeProduct", SqlDbType.Int);
                result.Direction = ParameterDirection.Output;
                id = Convert.ToInt32(result.Value);


                ConnectionToDb.Close();
            }
            catch 
            {
                throw new Exception("Ошибка получения уникального номера записи о типе печатной продукции");
            }

            return id;
        }


        /// <summary>
        /// Метод, проверяющий существование названия типа печатной продукции в бд 
        /// </summary>
        /// <param name="typeWork">Тип работы с данными</param>
        /// <param name="pastName">Прошлое название типа печатной продукции</param>
        /// <param name="newName">Новое название типа печатной продукции</param>
        /// <returns>Существует ли название типа печатной продукции в бд</returns>
        public static bool ExistNameInDb(char typeWork, string pastName, string newName)
        {
            bool exist = false;

            try
            {
                ConnectionToDb.Open();
                SqlCommand command = new SqlCommand();

                // Если пользователь добавляет запись
                if (typeWork == 'A')
                    // Запрос на существование названия
                    command = new SqlCommand("SELECT COUNT(typeProdName) FROM typeProduct WHERE typeProdName = '" + newName + "'", ConnectionToDb.Connection);

                // Если пользователь редактирует запись
                else if (typeWork == 'C')
                {
                    // Получаем id записи
                    int id = GetIdByName(pastName);

                    ConnectionToDb.Open();

                    //Запрос на существование названия, не учитывая изменяемую запись 
                    command = new SqlCommand("SELECT COUNT(typeProdName) FROM typeProduct WHERE typeProdName = '" + newName + "' AND typeProdId != '" + id + "' ", ConnectionToDb.Connection);

                }

                // Если название найдено
                if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                    exist = true;

                ConnectionToDb.Close();
            }

            catch
            {
                throw new Exception("Ошибка проверки существования названия типа печатной продукции в базе данных");
            }

            return exist;
        }
    }
}

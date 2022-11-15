using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace PublishingHouse
{
    /// <summary>
    /// Класс для работы с типографией
    /// </summary>
    public class PrintingHouse
    {
        string name, numberPhone, email, typeState, nameState, city, typeStreet, nameStreet, numberHouse;

        public PrintingHouse(string name, string numberPhone, string email, string typeState, string nameState, string city, string typeStreet, string nameStreet, string numberHouse)
        {
            this.name = name;
            this.numberPhone = numberPhone;
            this.email = email;
            this.typeState = typeState;
            this.nameState = nameState;
            this.city = city;
            this.typeStreet = typeStreet;
            this.nameStreet = nameStreet;
            this.numberHouse = numberHouse;
        }

        public override string ToString()
        {
            return $"{name}\n {numberPhone}\n {email}\n {typeState}\n {nameState}\n {city}\n {typeStreet}\n {nameStreet}\n {numberHouse}";
        }

        ///// <summary>
        ///// Метод, определяющий заполнены ли поля класса
        ///// </summary>
        ///// <returns>Заполнены ли поля класса</returns>
        //public bool IsFilled() 
        //{
        //    if (name != "" && numberPhone != "" && email != "" && typeState != "" && nameState != "" && city != "" && typeStreet != "" && nameStreet != "" && numberHouse != "")
        //        return true;
        //    else
        //        return false;
        //}

        /// <summary>
        /// Метод добавления типографии в бд
        /// </summary>
        /// <returns>Количество добавленных записей</returns>
        public int AddPrintingHouse() 
        {
            int count = 0;

            try
            {
                ConnectionToDb.Open();

                // Указываем, что команда является хранимой процедурой
                const string SQLPROCEDURE = "addPrintingHouse";
                SqlCommand command = new SqlCommand(SQLPROCEDURE, ConnectionToDb.Connection);
                command.CommandType = CommandType.StoredProcedure;

                // Передаём данные для добавления записи
                command.Parameters.Add("@phName", SqlDbType.NVarChar).Value = name;
                command.Parameters.Add("@phPhone", SqlDbType.NVarChar).Value = numberPhone;
                command.Parameters.Add("@phEmail", SqlDbType.NVarChar).Value = email;
                command.Parameters.Add("@phTypeState", SqlDbType.NVarChar).Value = typeState;
                command.Parameters.Add("@phState", SqlDbType.NVarChar).Value = nameState;
                command.Parameters.Add("@phCity", SqlDbType.NVarChar).Value = city;
                command.Parameters.Add("@phStreet", SqlDbType.NVarChar).Value = nameStreet;
                command.Parameters.Add("@phHouse", SqlDbType.NVarChar).Value = numberHouse;
                command.Parameters.Add("@phTypeStreet", SqlDbType.NVarChar).Value = typeStreet;

                count = command.ExecuteNonQuery();

                ConnectionToDb.Close();
            }
            catch 
            {
                throw new Exception("Ошибка добавления типографии");
            }

            return count;
        }
    }
}

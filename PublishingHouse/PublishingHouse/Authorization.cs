using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace PublishingHouse
{
    /// <summary>
    /// Класс для авторизации пользователя
    /// </summary>
   public class Authorization
    {
        string login = "";
        string password = "";

        public Authorization(string login, string password) 
        {
            this.login = login;
            this.password = password;
        }

        /// <summary>
        /// Метод авторизации
        /// </summary>
        /// <returns>Логин</returns>
        public string UserAuthorization() 
        {
            string loginUser = "";

            try
            {
                ConnectionToDb.Open();

                // Формируем запрос на получение логина и выполняем его
                SqlCommand command = new SqlCommand("SELECT loginUser FROM authorizationUsers WHERE loginUser = N'"+ login +"' AND passwordUser = N'"+ password +"'", ConnectionToDb.Connection);
                loginUser = Convert.ToString(command.ExecuteScalar());

                ConnectionToDb.Close();
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
                //throw new Exception("Ошибка получения данных о пользователе");
            }

            return loginUser;
        }
    }
}

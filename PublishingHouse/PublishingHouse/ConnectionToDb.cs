using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SqlClient;

namespace PublishingHouse
{
    /// <summary>
    /// Класс подключения/отключения соединения с бд
    /// </summary>
  public static class ConnectionToDb
    {

       static SqlConnection connection = null;

       public static SqlConnection Connection { get { return connection; } }

     
        /// <summary>
        /// Метод подключения соединения с бд
        /// </summary>
        public static void Open() 
        {

            string path = Directory.GetCurrentDirectory();
            path = path.Replace("bin\\Debug\\netcoreapp3.1", string.Empty) + "PublishingHouse.mdf";
            
            // строка подключения к бд
            string connectStr = string.Format("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = {0}; Integrated Security = True", path); 

            connection = new SqlConnection(connectStr);
            connection.Open();
   
        }

        /// <summary>
        /// Метод отключения соединения с бд
        /// </summary>
        public static void Close() { connection.Close(); }
        
    }
}

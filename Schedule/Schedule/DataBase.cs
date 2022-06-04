// библиотека для работы с базой данных MySql
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    

    internal class DataBase
    {
        static string server = "server=localhost;port=3306;username=root;password=root;database=shedules";

        // объект который будет работать с базой данных
        static MySqlConnection connection = new MySqlConnection(server);


        public DataBase(string login, string pass)
        {
            string s = $"server=localhost;port=3306;username={login};password={pass};database=shedules";
            server = s;
        }


        // функция для подключения к базе данных
        public void OpenConnection()
        {
            // если не подключено
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open(); // то подключаемся к базе данных
        }
        
        
        // функция для отключения от базе данных
        public void CloseConnection()
        {
            // если подключено
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close(); // то отключаемся от базе данных
        }


        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}


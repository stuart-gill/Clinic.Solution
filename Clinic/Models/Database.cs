using System;
using MySql.Data.MySqlClient;
using Clinic;
 
namespace Clinic.Models
{
    public class DB
    {
        public static MySqlConnection Connection()
        {
            MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
            return conn;
        }
    }
}

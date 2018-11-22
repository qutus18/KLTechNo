using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace CompareLoggingCode
{
    public class DBMySQLUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string connStr = "server=localhost; user=root; database=latus; port=3306; password=.1torres";
            MySqlConnection conn = new MySqlConnection(connStr);
            return conn;
        }

    }
}

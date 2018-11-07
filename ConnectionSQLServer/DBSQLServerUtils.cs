using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace ConnectionSQLServer
{
    class DBSQLServerUtils
    {
        public static SqlConnection
                 GetDBConnection(string datasource, string database, string username, string password)
        {

            SqlConnection conn = null;
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;
            try
            {
            conn = new SqlConnection(connString);
               
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
          return conn;

           
        }
    }
}

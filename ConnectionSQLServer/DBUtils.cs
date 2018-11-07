using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConnectionSQLServer
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"CHIENPLQSE62554";

            string database = "blockChain";
            string username = "sa";
            string password = "111011001";

            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
    }

    class DBUtilsTuan
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"TuanLSE62583";

            string database = "blockChain";
            string username = "sa";
            string password = "123456";

            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
    }
    class DBUtilsNguyen
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"TuanLSE62583";

            string database = "blockChain";
            string username = "sa";
            string password = "123456";

            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
    }
}

using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectingToSql.connectToSql
{
    internal class connectSQLServer
    {
        public SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-D25JRIJ\SQLEXPRESS;Initial Catalog=userLogin;Integrated Security=true";
            return con;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.DAL
{
    public class Connection
    {
       private readonly SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-PJ4KE6J; initial Catalog=DapperExample; Integrated Security=True;");
        
        public SqlConnection getConnect
        {
            get { return connection; }
        }
        

        public void conOpen()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void conClose()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}

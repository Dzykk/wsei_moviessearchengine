using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;
using System.Data.SqlClient;


namespace Search_Engine_Library
{
    public class DBConnect
    {
        private SqlConnection conn;
        public DBConnect() { }
        
        public SqlConnection Connect()
        {
            //conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\Database.mdf; Integrated Security = True"); physical db
            //conn = new SqlConnection(@"Data Source=DESKTOP-BOFB2DM\SQLEXPRESS;Initial Catalog=MovieDB;Integrated Security=True"); local SQL Server DB
            conn = new SqlConnection(@"Server=tcp:wsei10987.database.windows.net,1433;Initial Catalog=MovieDB;Persist Security Info=False;User ID=Dzykk;Password=Csharp2019;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30"); //Azure SQL Server DB
            return conn;
        }

    }
}


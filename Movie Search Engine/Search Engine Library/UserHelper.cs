using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Data;
using System.Data.SqlClient;


namespace Search_Engine_Library
{
    public class UserHelper
    {
        public static DataTable GetWatchlist(string login)
        {
            DBConnect dbcon = new DBConnect();
            SqlConnection con = dbcon.Connect();
            con.Open();
            string wlquery = "SELECT * FROM [dbo].[Watchlist] WHERE [Login] =" + login;
            SqlCommand cmd = new SqlCommand(wlquery, con);

            DataTable moviedt = new DataTable();
            moviedt.Load(cmd.ExecuteReader());
            con.Close();
            return moviedt;
        }     
        public static void UserObject(string login, string password)
        {
            User CurrentUser = new User(login, password);            
        }

    }
}


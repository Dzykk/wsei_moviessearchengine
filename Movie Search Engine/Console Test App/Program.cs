using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Search_Engine_Library;
using System.Data;
using System.Data.SqlClient;

namespace Console_Test_App
{
    class Program
    {
        static void Main(string[] args)
        {
            DBConnect connection = new DBConnect();
            DataManipulator dm = new DataManipulator();
            UserHelper.UserObject("User1", "q1w2e3");
            Watchlist CurrentWatchList = new Watchlist(UserHelper.GetWatchlist("User1"));

            foreach (Movie m in dm.MovieList)
            {
                Console.WriteLine(m.Title);
            }
        }
    }
}

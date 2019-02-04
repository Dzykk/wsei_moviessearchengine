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
            //DataManipulator.ShowTable(DataManipulator.GetMovieData());

            foreach (Movie m in dm.MovieList)
            {
                Console.WriteLine(m.Title);
            }
        }
    }
}

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
            using (SqlConnection con = connection.Connect())
            { 
            using (SqlCommand command = new SqlCommand("SELECT * FROM Movie", con))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(1));
                }
            }

            }


            Console.ReadKey();
        }
    }
}

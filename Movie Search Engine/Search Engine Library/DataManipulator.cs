using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;


namespace Search_Engine_Library
{
    public class DataManipulator
    {

        public static DataTable GetMovieData()
        {
            DBConnect dbcon = new DBConnect();
            SqlConnection con = dbcon.Connect();
            con.Open();
            string moviequery = "SELECT * FROM [dbo].[Movie]";
            SqlCommand cmd = new SqlCommand(moviequery, con);

            DataTable moviedt = new DataTable();
            moviedt.Load(cmd.ExecuteReader());
            con.Close();
            return moviedt;
        }

        public static DataTable GetUserData()
        {
            DBConnect dbcon = new DBConnect();
            SqlConnection con = dbcon.Connect();
            con.Open();
            string userquery = "SELECT * FROM [dbo].[Account] WHERE [AccountType] = 'AppUser'";
            SqlCommand cmd = new SqlCommand(userquery, con);

            DataTable userdt = new DataTable();
            userdt.Load(cmd.ExecuteReader());
            con.Close();
            return userdt;
        }

        public List<Movie> MovieList = (DataManipulator.GetMovieData()).AsEnumerable().Select(row =>
       new Movie
       {
           Id = row.Field<int>("MovieID"),
           Title = row.Field<string>("Title"),
           Price = row.Field<string>("Price"),
           Releasedate = row.Field<DateTime>("ReleaseDate"),
           Genre = DataManipulator.ParseEnum<Genre>((row.Field<string>("Genre").ToString())),
           Language = DataManipulator.ParseEnum<Language>((row.Field<string>("Language").ToString())),
           Runtime = row.Field<string>("Runtime"),
           Poster = row.Field<byte[]>("Poster")
       }
        ).ToList();

        public static void ShowTable(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine();
                for (int x = 0; x < table.Columns.Count; x++)
                {
                    Console.Write(row[x].ToString() + " ");
                }
            }
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase: true);
        }
            
        //public void mv()
        //{
        //    DBConnect dbcon = new DBConnect();
        //    SqlConnection con = dbcon.Connect();
        //    con.Open();
        //    string userquery =
        //        "MERGE [dbo].[Movie] AS tab " +
        //        "USING (SELECT @Title AS Title, @Price AS Price, @ReleaseDate AS ReleaseDate, @Genre AS Genre, @Language AS [Language], @Runtime AS Runtime) AS src " +
        //        "ON tab.Title = src.Title AND tab.ReleaseDate = src.ReleaseDate " +
        //        "WHEN NOT MATCHED THEN " +
        //        "INSERT (Title, Price, ReleaseDate, Genre, [Language], Runtime)" +
        //        "VALUES (src.Title, src.Price, src.ReleaseDate, src.Genre, src.[Language], src.Runtime) " +
        //        "END";                
        //    SqlCommand cmd = new SqlCommand(userquery, con);
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Parameters.AddWithValue("@Title", txt1.Text);
        //    cmd.Parameters.AddWithValue("@Price", txt2.Password);
        //    cmd.Parameters.AddWithValue("@ReleaseDate", txt3.Password);
        //    cmd.Parameters.AddWithValue("@Genre", txt4.Password);
        //    cmd.Parameters.AddWithValue("@Language", txt5.Password);
        //    cmd.Parameters.AddWithValue("@Runtime", txt6.Password);
        //}


    }
}
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
        

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase: true);
        }

        public static byte[] GetPoster(string path)
        {
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);
            byte[] poster = reader.ReadBytes((int)stream.Length);
            reader.Close();
            stream.Close();
            return poster;

        }



       
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Search_Engine_Library
{
   public class DBQueries
    {
        public static int CheckExistingUser(SqlConnection con, string username)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT COUNT(*) FROM[dbo].[Account] WHERE[Login] = @Login";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Login", username);
            int usercheck = (int)cmd.ExecuteScalar();
            return usercheck;
        }

        public static void RegisterNewUser(SqlConnection con, string username, string password)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO[dbo].[Account]([Login], [Password], [AccountType] ) VALUES(@Login, @Password, 'AppUser')";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Login", username);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.ExecuteNonQuery();
        }

        public static int UserLogIn(SqlConnection con, string username, string password)
        {         
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT COUNT(1) FROM Account WHERE Login=@Username AND Password=@Password";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            int usercheck = (int)cmd.ExecuteScalar();
            return usercheck;
        }

        public static int CheckExistingMovie(SqlConnection con, string title)
        {                        
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM [dbo].[Movie] WHERE [Title] = @Title";
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Title", title);
            int recordscheck = (int)cmd.ExecuteScalar();
            return recordscheck;
        }

        public static void AddNewMovie(SqlConnection con, string title, string price, string releasedate, string genre, string language, string runtime)
        {
            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"posters\", "default.jpg");
            byte[] poster = DataManipulator.GetPoster(path);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO [dbo].[Movie] (Title, Price, ReleaseDate, Genre, [Language], Runtime, Poster) VALUES (@Title, @Price, @ReleaseDate, @Genre, @Language, @Runtime, @Poster)";
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.Parameters.AddWithValue("@ReleaseDate", releasedate);
            cmd.Parameters.AddWithValue("@Genre", genre);
            cmd.Parameters.AddWithValue("@Language", language);
            cmd.Parameters.AddWithValue("@Runtime", runtime);
            cmd.Parameters.Add("Poster", SqlDbType.Image, poster.Length).Value = poster;
            cmd.ExecuteNonQuery();
        }

    }
}

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

        public void mv()
        {
            DBConnect dbcon = new DBConnect();
            SqlConnection con = dbcon.Connect();
            con.Open();
            string userquery = "SELECT TOP (1) [Title] FROM [dbo].[Movie] WHERE [Title] = @Title AND [ReleaseDate] = @ReleaseDate";
            SqlCommand cmd = new SqlCommand(userquery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Title", txt1.Text);
            cmd.Parameters.AddWithValue("@ReleaseDate", txt3.Password);
            string movieindb = cmd.ExecuteScalar().ToString();
            if (!string.IsNullOrEmpty(movieindb))
            {
                MessageBox.Show("Movie already in the database!");
            }
            else
            { 
                string userquery2 = "INSERT INTO [dbo].[Movie] (Title, Price, ReleaseDate, Genre, [Language], Runtime) VALUES (@Title, @Price, @ReleaseDate, @Genre, @Language, @Runtime)";
                SqlCommand cmd2 = new SqlCommand(userquery2, con);
                cmd2.CommandType = CommandType.Text;
                cmd2.Parameters.AddWithValue("@Title", txt1.Text);
                cmd2.Parameters.AddWithValue("@Price", txt2.Password);
                cmd2.Parameters.AddWithValue("@ReleaseDate", txt3.Password);
                cmd2.Parameters.AddWithValue("@Genre", txt4.Password);
                cmd2.Parameters.AddWithValue("@Language", txt5.Password);
                cmd2.Parameters.AddWithValue("@Runtime", txt6.Password);
                cmd2.ExecuteNonQuery();

            }           

        }



        public void newuser()
        {
            DBConnect dbcon = new DBConnect();
            SqlConnection con = dbcon.Connect();
            con.Open();
            string userquery = "SELECT TOP (1) [Login] FROM [dbo].[Account] WHERE [Login] = @Login";
            SqlCommand cmd = new SqlCommand(userquery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Login", txtUsername.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Password);
            string existinguser = cmd.ExecuteScalar().ToString();
            if (!string.IsNullOrEmpty(existinguser))
            {
                MessageBox.Show("Login already taken!");
            }
            else
            {
                string userquery2 = "INSERT INTO [dbo].[Account] ([Login], [Password], [AccountType] ) VALUES (@Login, @Password, 'AppUser')";
                SqlCommand cmd2 = new SqlCommand(userquery2, con);
                cmd2.Parameters.AddWithValue("@Login", txtUsername.Text);
                cmd2.Parameters.AddWithValue("@Password", txtPassword.Password);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("You can now log in!");
            }
        }
    }
}
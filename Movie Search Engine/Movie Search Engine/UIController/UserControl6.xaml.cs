using Search_Engine_Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Movie_Search_Engine.UIController
{
    /// <summary>
    /// Logika interakcji dla klasy UserControl6.xaml
    /// </summary>
    public partial class UserControl6 : UserControl
    {
        public UserControl6()
        {
            InitializeComponent();
        }

        
        


        private void addMovie_Click(object sender, RoutedEventArgs e)

        { DBConnect dbcon = new DBConnect();
            SqlConnection con = dbcon.Connect();
            try
            {
               
                if (con.State == ConnectionState.Closed)
                {                
                    con.Open();
                    string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"posters\", "default.jpg");
                    byte[] poster = DataManipulator.GetPoster(path);
                    string userquery = "SELECT COUNT(*) FROM [dbo].[Movie] WHERE [Title] = @Title";
                    SqlCommand cmd = new SqlCommand(userquery, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Title", txt1.Text);
                    int recordscheck = (int)cmd.ExecuteScalar();
                    if (recordscheck == 0)
                    { 
                        userquery = "INSERT INTO [dbo].[Movie] (Title, Price, ReleaseDate, Genre, [Language], Runtime, Poster) VALUES (@Title, @Price, @ReleaseDate, @Genre, @Language, @Runtime, @Poster)";
                        cmd.CommandText = userquery;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Title", txt1.Text);
                        cmd.Parameters.AddWithValue("@Price", txt2.Text);
                        cmd.Parameters.AddWithValue("@ReleaseDate", txt3.Text);
                        cmd.Parameters.AddWithValue("@Genre", txt4.Text);
                        cmd.Parameters.AddWithValue("@Language", txt5.Text);
                        cmd.Parameters.AddWithValue("@Runtime", txt6.Text);
                        cmd.Parameters.Add("Poster", SqlDbType.Image, poster.Length).Value = poster;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Movie added successfully.");
                    }                 
                    else
                    {
                        MessageBox.Show("Movie already in the database!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
    }
    


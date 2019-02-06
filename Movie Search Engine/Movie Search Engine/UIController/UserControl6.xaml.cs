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
                    string userquery = "SELECT TOP (1) [Title] FROM [dbo].[Movie] WHERE [Title] = @Title AND [ReleaseDate] = @ReleaseDate";
                    SqlCommand cmd = new SqlCommand(userquery, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Title", txt1.Text);
                    cmd.Parameters.AddWithValue("@ReleaseDate", txt3.Text);
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
                        cmd2.Parameters.AddWithValue("@Price", txt2.Text);
                        cmd2.Parameters.AddWithValue("@ReleaseDate", txt3);
                        cmd2.Parameters.AddWithValue("@Genre", txt4.Text);
                        cmd2.Parameters.AddWithValue("@Language", txt5.Text);
                        cmd2.Parameters.AddWithValue("@Runtime", txt6.Text);
                        cmd2.ExecuteNonQuery();

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
    


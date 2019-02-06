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
            string userquery =
                "MERGE [dbo].[Movie] AS tab " +
                "USING (SELECT @Title AS Title, @Price AS Price, @ReleaseDate AS ReleaseDate, @Genre AS Genre, @Language AS [Language], @Runtime AS Runtime) AS src " +
                "ON tab.Title = src.Title AND tab.ReleaseDate = src.ReleaseDate " +
                "WHEN NOT MATCHED THEN " +
                "INSERT (Title, Price, ReleaseDate, Genre, [Language], Runtime)" +
                "VALUES (src.Title, src.Price, src.ReleaseDate, src.Genre, src.[Language], src.Runtime) " +
                "END";
            SqlCommand cmd = new SqlCommand(userquery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Title", txt1.Text);
            cmd.Parameters.AddWithValue("@Price", txt2.Text);
            cmd.Parameters.AddWithValue("@ReleaseDate", txt3.Text);
            cmd.Parameters.AddWithValue("@Genre", txt4.Text);
            cmd.Parameters.AddWithValue("@Language", txt5.Text);
            cmd.Parameters.AddWithValue("@Runtime", txt6.Text);
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
    


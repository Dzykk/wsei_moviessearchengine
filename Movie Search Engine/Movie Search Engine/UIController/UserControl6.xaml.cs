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
                    int recordscheck = DBQueries.CheckExistingMovie(con, txt1.Text);
                    if (recordscheck == 0)
                    {                       
                        DBQueries.AddNewMovie(con, txt1.Text, txt2.Text, txt3.Text, txt4.Text, txt5.Text, txt6.Text);
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
    


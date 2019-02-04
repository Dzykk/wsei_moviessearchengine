using Search_Engine_Library;
using System;
using System.Collections.Generic;
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

        private void add_movie_Click(object sender, RoutedEventArgs e)
        {
            DBConnect con = new DBConnect();
            SqlConnection sqlCon = con.Connect();
            try
            {

                sqlCon.Open();
                string query = "insert into movies (name, mm) values ;
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;

            }
    }
}

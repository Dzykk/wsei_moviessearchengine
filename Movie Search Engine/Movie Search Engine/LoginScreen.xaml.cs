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
using System.Windows.Shapes;
using Search_Engine_Library;

namespace Movie_Search_Engine
{
    /// <summary>
    /// Logika interakcji dla klasy loginScreen.xaml
    /// </summary>
    public partial class loginScreen : Window
    {

        private void wnd_move_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public loginScreen()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            DBConnect dbcon = new DBConnect();
            SqlConnection con = dbcon.Connect();
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();                  
                    int usercheck = DBQueries.UserLogIn(con, txtUsername.Text, txtPassword.Password);
                    if (usercheck == 1)
                    {
                        MainWindow dashboard = new MainWindow(txtUsername.Text);
                        dashboard.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Username or password is incorrect.");
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

        private void Register_btn_Click(object sender, RoutedEventArgs e)
        {
            RegisterScreen regScreen = new RegisterScreen();
            regScreen.Show();
            this.Close();
        }

      

        private void Mnimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
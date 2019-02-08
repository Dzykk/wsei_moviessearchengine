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
using System.Windows.Shapes;

namespace Movie_Search_Engine
{
    /// <summary>
    /// Logika interakcji dla klasy RegisterScreen.xaml
    /// </summary>
    /// <remarks>
    /// Przekazuje dane wpisane do rejestracji w celu dodania nowego użytkownika
    /// Po rejestracji wyłącza bieżące okno i włącza LoginScreen
    /// </remarks>
    public partial class RegisterScreen : Window
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
        public RegisterScreen()
        {
            InitializeComponent();
        }


        private void btnSignin_Click(object sender, RoutedEventArgs e)
        {
            DBConnect dbcon = new DBConnect();
            SqlConnection con = dbcon.Connect();

            try
            {

                if (con.State == ConnectionState.Closed)
                {

                    con.Open();
                    int usercheck = DBQueries.CheckExistingUser(con, txtUsername.Text);                 
                    if (usercheck == 0)
                    {                     
                        DBQueries.RegisterNewUser(con, txtUsername.Text, txtPassword.Password);
                        MessageBox.Show("You can now log in!");
                        loginScreen logScreen = new loginScreen();
                        logScreen.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Login already taken!");
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


   

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
    this.WindowState = WindowState.Minimized;
        }
    }
}
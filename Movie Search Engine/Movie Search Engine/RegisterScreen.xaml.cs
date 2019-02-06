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
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT COUNT(*) FROM[dbo].[Account] WHERE[Login] = @Login";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Login", txtUsername.Text);


                    int usercheck = (int)cmd.ExecuteScalar();
                    if (usercheck == 0)
                    {
                        cmd.CommandText = "INSERT INTO[dbo].[Account]([Login], [Password], [AccountType] ) VALUES(@Login, @Password, 'AppUser')";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Login", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Password);
                        cmd.ExecuteNonQuery();
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
    }
}
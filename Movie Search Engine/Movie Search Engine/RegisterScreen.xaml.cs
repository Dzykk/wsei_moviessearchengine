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
            //DBConnect dbcon = new DBConnect();
            //SqlConnection con = dbcon.Connect();
            //con.Open();
            //string userquery = "SELECT TOP (1) [Login] FROM [dbo].[Account] WHERE [Login] = @Login";
            //SqlCommand cmd = new SqlCommand(userquery, con);
            //cmd.CommandType = CommandType.Text;
            //cmd.Parameters.AddWithValue("@Login", txtUsername.Text);
            //cmd.Parameters.AddWithValue("@Password", txtPassword.Password);
            //string existinguser = cmd.ExecuteScalar().ToString();
            //if (!string.IsNullOrEmpty(existinguser))
            //{
            //    MessageBox.Show("Login already taken!");
            //}
            //else
            //{
            //    string userquery2 = "INSERT INTO [dbo].[Account] ([Login], [Password], [AccountType] ) VALUES (@Login, @Password, 'AppUser')";
            //    SqlCommand cmd2 = new SqlCommand(userquery2, con);
            //    cmd2.Parameters.AddWithValue("@Login", txtUsername.Text);
            //    cmd2.Parameters.AddWithValue("@Password", txtPassword.Password);
            //    cmd2.ExecuteNonQuery();
            //    MessageBox.Show("You can now log in!");
            //    loginScreen logScreen = new loginScreen();
            //    logScreen.Show();
            //    this.Close();
            //}
            DBConnect dbcon = new DBConnect();
            SqlConnection con = dbcon.Connect();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText= "INSERT INTO[dbo].[Account]([Login], [Password], [AccountType] ) VALUES(@Login, @Password, 'AppUser')";
            cmd.Parameters.AddWithValue("@Login", txtUsername.Text);
           cmd.Parameters.AddWithValue("@Password", txtPassword.Password);
            cmd.Connection = con;
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("You can now log in!");
                  loginScreen logScreen = new loginScreen();
                  logScreen.Show();
                 this.Close();
            }


        }
    }
}

using Movie_Search_Engine.Menu_Klasy;
using Movie_Search_Engine.UIController;
using Search_Engine_Library;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Movie_Search_Engine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(string Username)
        {
            InitializeComponent();
            Username_txt.Content = Username;
            if (Username == "Administrator1")
            {
                menubuton_admin.Visibility = Visibility.Visible;

            }
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void wnd_move_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }


        private void menubutton_first_Click(object sender, RoutedEventArgs e)
        {
Class1.User_Choice(content_inner, new UserControl2());
        }

        private void menubutton_second_Click(object sender, RoutedEventArgs e)
        {
            Class1.User_Choice(content_inner, new UserControl3());
        }

        private void menubutton_third_Click(object sender, RoutedEventArgs e)
        {
         
                Class1.User_Choice(content_inner, new UserControl4());
           
        }

        private void menubutton_fourth_Click(object sender, RoutedEventArgs e)
        {
            Class1.User_Choice(content_inner, new UserControl5());
        }

        private void menubuton_home_Loaded(object sender, RoutedEventArgs e)
        {
            Class1.User_Choice(content_inner, new UserControl1());
        }

        private void menubutton_home_Click(object sender, RoutedEventArgs e)
        {
            Class1.User_Choice(content_inner, new UserControl1());
        }

        private void menubutton_admin_Click(object sender, RoutedEventArgs e)
        {
            Class1.User_Choice(content_inner, new UserControl6());
        }

        private void menubuton_fifth_Click(object sender, RoutedEventArgs e)
        {
            Class1.User_Choice(content_inner, new UserControl7());
        }

        private void menubuton_sixth_Click(object sender, RoutedEventArgs e)
        {
            Class1.User_Choice(content_inner, new UserControl8());
        }

        private void menubuton_seventh_Click(object sender, RoutedEventArgs e)
        {
            Class1.User_Choice(content_inner, new UserControl9());
        }

        private void menubuton_eighth_Click(object sender, RoutedEventArgs e)
        {
            Class1.User_Choice(content_inner, new UserControl10());
        }

        private void menubuton_ninth_Click(object sender, RoutedEventArgs e)
        {
            Class1.User_Choice(content_inner, new UserControl11());
        }

     

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            loginScreen logscr = new loginScreen();
            logscr.Show();
            this.Close();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
 this.WindowState = WindowState.Minimized;
        }

     

        private void Search_btn_Click(object sender, RoutedEventArgs e)
        {
Class1.User_Choice(content_inner, new UserControl12(txtSearch.Text));
        }
    }
}

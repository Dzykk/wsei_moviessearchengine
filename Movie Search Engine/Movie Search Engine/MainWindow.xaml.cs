using Movie_Search_Engine.Menu_Klasy;
using Movie_Search_Engine.UIController;
using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();
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

    private void menubutton_home_Click(object sender, RoutedEventArgs e)
        {
            Class1.User_Choice(content_inner, new UserControl1());
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

        private void menubutton_admin_Click(object sender, RoutedEventArgs e)
        { 

            Class1.User_Choice(content_inner, new UserControl6());
        }
    }
}

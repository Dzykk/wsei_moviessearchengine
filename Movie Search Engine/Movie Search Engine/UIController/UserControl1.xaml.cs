using Search_Engine_Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    public class ImageClass

    {

        public int Id { get; set; }

        public string ImagePath { get; set; }

        public byte[] ImageToByte { get; set; }

    }
 

    /// <summary>
    /// Logika interakcji dla klasy UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();


            DBConnect connection = new DBConnect();
            DataManipulator movies = new DataManipulator();
            //DataManipulator.ShowTable(DataManipulator.GetMovieData());

            //Image img = new System.Windows.Controls.Image();



            //title.Content = movies.MovieList[1].Title;
            //Polecane.Children.Add(title);
       
        StackPanel stack = new System.Windows.Controls.StackPanel();
                stack.HorizontalAlignment = HorizontalAlignment.Center;
                Polecane.Children.Add(stack);

            for (int i = 0; i < movies.MovieList.Count; i++)
            { 
                Image img = new Image();
                ImageClass images = new ImageClass();
                var result = movies.MovieList[i].Poster;
                Stream StreamObj = new MemoryStream(result);
                BitmapImage BitObj = new BitmapImage();
                BitObj.BeginInit();
                BitObj.StreamSource = StreamObj;
                BitObj.EndInit();
                img.Source = BitObj;
                img.Height = 100;
                img.Width = 100;

                Label title = new System.Windows.Controls.Label();
                Label rlsDate = new System.Windows.Controls.Label();
                Label genre = new System.Windows.Controls.Label();
                Label lng = new System.Windows.Controls.Label();
                Label rnTime = new System.Windows.Controls.Label();
                Label price = new System.Windows.Controls.Label();
              
                title.Content = "Title" + movies.MovieList[i].Title;
                rlsDate.Content = "Realise date: " +movies.MovieList[i].Releasedate;
                genre.Content = "Genre" + movies.MovieList[i].Genre;
                lng.Content = "Language" + movies.MovieList[i].Language;
                rnTime.Content = "Runtime"+ movies.MovieList[i].Runtime;
                price.Content = "Price: " + movies.MovieList[i].Price;

                stack.Children.Add(img);
                stack.Children.Add(price);
                stack.Children.Add(title);
                stack.Children.Add(rlsDate);
                stack.Children.Add(lng);
                stack.Children.Add(rnTime);
            }


        }
            //foreach (Movie m in movies.MovieList)
            //{
            //    title.Content = m.Title;


            //    Polecane.Children.Add(img);
            //    Polecane.Children.Add(title);
            //}



    }


    
}

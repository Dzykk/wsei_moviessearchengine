using Search_Engine_Library;
using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Logika interakcji dla klasy UserControl9.xaml
    /// </summary>
    /// <remarks>
    /// Wyświetla filmy z kategorii Horror w interfejsie graficznym
    /// </remarks>
    public partial class UserControl9 : UserControl
    {
        public UserControl9()
        {
            InitializeComponent();
            DBConnect connection = new DBConnect();
            DataManipulator movies = new DataManipulator();
            for (int i = 0; i < movies.MovieList.Count; i++)
            {
                if (movies.MovieList[i].Genre.ToString() == "Horror")
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
                    img.Height = 130;
                    img.Width = 130;
                    img.HorizontalAlignment = HorizontalAlignment.Center;
                    img.VerticalAlignment = VerticalAlignment.Center;

                    Label title = new System.Windows.Controls.Label();
                    Label rlsDate = new System.Windows.Controls.Label();
                    Label genre = new System.Windows.Controls.Label();
                    Label lng = new System.Windows.Controls.Label();
                    Label rnTime = new System.Windows.Controls.Label();
                    Label price = new System.Windows.Controls.Label();


                    title.Content = "Title: " + movies.MovieList[i].Title;
                    rlsDate.Content = "Realise date: " + movies.MovieList[i].Releasedate;
                    genre.Content = "Genre: " + movies.MovieList[i].Genre;
                    lng.Content = "Language: " + movies.MovieList[i].Language;
                    rnTime.Content = "Runtime: " + movies.MovieList[i].Runtime;
                    price.Content = "Price: " + movies.MovieList[i].Price;

                    DockPanel dock = new System.Windows.Controls.DockPanel();
                    dock.Height = 200;
                    Category.Children.Add(dock);
                    dock.Children.Add(img);
                    StackPanel newstack = new System.Windows.Controls.StackPanel();
                    newstack.VerticalAlignment = VerticalAlignment.Center;
                    title.FontSize = 20;

                    dock.Children.Add(newstack);
                    newstack.Children.Add(title);
                    newstack.Children.Add(genre);
                    newstack.Children.Add(price);
                    newstack.Children.Add(rlsDate);
                    newstack.Children.Add(lng);
                    newstack.Children.Add(rnTime);
                    newstack.Children.Add(new Separator());
                }
                else continue;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Search_Engine_Library
{   
    /// <summary>
    /// Klasa Movie
    /// Zawiera pola odpowiedzialne za dane dotyczące filmów w aplikacji.
    /// </summary>
    /// <remarks>
    /// Zawiera implementacje interfejsów IComparable oraz IEquatable w celu porównywania i sortowania filmów.
    /// W związku z integracją aplikacji z bazą danych, to ona odpowiada za sprawdzenie, czy nie występują powtórzenia.
    /// Porównywanie jest jednak wykorzystywane w celu wyświetlania filmów w kolejności w interfejsie graficznym.
    /// Zawiera również przeciążoną metodą ToString;
    /// </remarks>
    public class Movie : IComparable<Movie>, IEquatable<Movie>
    {
        public Movie (int id, string title)
        {
            this.Id = id;
            this.Title = title;
        }

        public Movie(int id, string title, DateTime releasedate)
        {
            this.Id = id;
            this.Title = title;
            this.Releasedate = releasedate;
        }

        private int id;
       
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        private string title;
       
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }
        
        private string price;
     
        public string Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }

        private DateTime releasedate;
     
        public DateTime Releasedate
        {
            get
            {
                return this.releasedate;
            }
            set
            {
                this.releasedate = value;
            }
        }

        private Genre genre;
    
        public Genre Genre
        {
            get
            {
                return this.genre;
            }
            set
            {
                this.genre = value;
            }
        }

        private Language language;
   
        public Language Language
        {
            get
            {
                return this.language;
            }
            set
            {
                this.language = value;
            }
        }

        private string runtime;
      
        public string Runtime
        {
            get
            {
                return this.runtime;
            }
            set
            {
                this.runtime = value;
            }
        }
        private byte[] poster;
 
        public byte[] Poster
        {
            get
            {
                return this.poster;
            }
            set
            {
                this.poster = value;
            }
        }
        /// <summary>
        /// Dodatkowe pole zawierające przekształcony Plakat z formatu byte[] na Image.
        /// </summary>
        public Image PosterImage => PosterByteToImage(Poster);

        public Movie (){}

        /// <summary>
        /// Metoda Equals
        /// Sprawdza tytuł i datę wydania filmów, a następnie zwraca true gdy są takie same, i false gdy się różnią.
        /// </summary>
        /// <param name="other">Odpowiada za porównywany film, w formacie Movie</param>
        /// <returns>Wartość boolowską 0 lub 1</returns>
        public bool Equals(Movie other)
        {            
            return (this.Title.Equals(other.Title) && this.Releasedate.Equals(other.Releasedate));              
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType())) return false;
            else return (this.Title.Equals(((Movie)obj).Title) && this.Releasedate.Equals(((Movie)obj).Releasedate));            
        }

        public static bool Equals(Movie m1, Movie m2)
        {
            return m1.Equals(m2);
        }

        public static bool operator == (Movie m1, Movie m2)
        {
            return m1.Equals(m2);
        }

        public static bool operator !=(Movie m1, Movie m2)
        {
            return !m1.Equals(m2);
        }

        /// <summary>
        /// Metoda CompareTo
        /// Najpierw sprawdza tytuły filmów. Jeśli tytuły okażą się być takie same, porównywane są pod kątem ich daty wydania.
        /// </summary>
        /// <param name="other">Odpowiada za porównywany film, w formacie Movie</param>
        /// <returns>Wartość 1 gdy obiekt jest większy, 0 gdy taki sam, -1 gdy mniejszy.</returns>
        public int CompareTo(Movie other)
        {
            if (this.Title.CompareTo(other.Title) > 0) return 1;
            else if (this.Title.CompareTo(other.Title) == 0)
            {
                return this.Releasedate.CompareTo(other.Releasedate);
            }
            else return -1;
        }

        public static int CompareTo(Movie m1, Movie m2)
        {
            return m1.CompareTo(m2);
        }

        public static bool operator > (Movie m1, Movie m2)
        {
            return m1.CompareTo(m2) == 1;
        }

        public static bool operator <(Movie m1, Movie m2)
        {
            return m1.CompareTo(m2) == -1;
        }

        public static bool operator >=(Movie m1, Movie m2)
        {
            return m1.CompareTo(m2) >= 0;
        }

        public static bool operator <=(Movie m1, Movie m2)
        {
            return m1.CompareTo(m2) <= 0;
        }

        /// <summary>
        /// Metoda PosterByteToImage
        /// Pobiera argument byteposter będący byte[] i przekształca go na Image, który potem wyświetlany będzie w aplikacji.
        /// </summary>
        /// <param name="byteposter">Odpowiada za plakat, w formacie byte[]</param>
        /// <returns>Plakat w formacie Image</returns>
        public Image PosterByteToImage(byte[] byteposter)
        {
            using (MemoryStream mstream = new MemoryStream(byteposter))
            {
                return Image.FromStream(mstream);
            }
        }

        public override string ToString()
        {
            return Title;
        }
    }
}

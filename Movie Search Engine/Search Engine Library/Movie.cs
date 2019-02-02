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
    [Table(Name = "Movie")]
    public class Movie : IComparable<Movie>, IEquatable<Movie>
    {
        
        private int id;
        [Column(Name = "MovieID", Storage ="id", IsPrimaryKey = true)]
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
        [Column(Name = "Title", Storage = "title", CanBeNull = false)]
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
        
        private int price;
        [Column(Name = "Price", Storage = "price", CanBeNull = true)]
        public int Price
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
        [Column(Name = "ReleaseDate", Storage = "releasedate", CanBeNull = true)]
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
        [Column(Name = "Genre", Storage = "genre", CanBeNull = true)]
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
        [Column(Name = "Language", Storage = "language", CanBeNull = true)]
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
        [Column(Name = "Runtime", Storage = "runtime", CanBeNull = true)]
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
        private Image poster;
        [Column(Name = "Poster", Storage = "poster", CanBeNull = true)]
        public Image Poster
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

        public Movie (){}

        public bool Equals(Movie other)
        {
            return (this.id.Equals(other.id));              
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

        public int CompareTo(Movie other)
        {
            if (this.Title.CompareTo(other.Title) > 0) return 1;
            else if (this.Title.CompareTo(other.Title) == 0)
            {
                return this.releasedate.CompareTo(other.Releasedate);
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
            return m1.CompareTo(m2) == 0;
        }

        public static bool operator <=(Movie m1, Movie m2)
        {
            return m1.CompareTo(m2) == 0;
        }
    }
}

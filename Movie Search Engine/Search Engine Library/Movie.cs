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
        [Column(Name = "MovieID", IsPrimaryKey = true)]
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
        [Column(Name = "Title", CanBeNull = false)]
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
        [Column(Name = "Price", CanBeNull = true)]
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
        public DateTime Releasedate => releasedate;

        private Genre[] genres;
        public Genre[] Genres => genres;

        private Language[] languages;
        public Language[] Languages => languages;

        private string runtime;
        public string Runtime => runtime;

        public Image poster;

        public Movie (int id, string title, int price, DateTime releasedate, Genre[] genres, Language[] languages, string runtime)
        {

        }

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

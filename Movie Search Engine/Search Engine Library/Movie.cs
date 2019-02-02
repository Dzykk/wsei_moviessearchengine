using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search_Engine_Library
{
    public class Movie : IComparable<Movie>, IEquatable<Movie>
    {

        private readonly int id;

        private readonly string title;
        public string Title => title;
        
        private readonly int price;
        public int Price => price;

        private readonly DateTime releasedate;
        public DateTime Releasedate => releasedate;

        private readonly Genre[] genres;
        public Genre[] Genres => genres;

        private readonly Language[] languages;
        public Language[] Languages => languages;

        private readonly string runtime;
        public string Runtime => runtime;

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

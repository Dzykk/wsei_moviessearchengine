using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Search_Engine_Library
{
    public class Watchlist
    {
        public Watchlist(DataTable wl)
        {
            this.WatchList = wl.AsEnumerable().Select(row =>
        new WatchlistEntry
        {
            id = row.Field<int>("MovieID"),
            title = row.Field<string>("Title")            
        }).ToList();
        }

        public List<WatchlistEntry> WatchList;

        [Table(Name = "Movie")]
        public class WatchlistEntry : IComparable<WatchlistEntry>
        {          
            [Column(Name = "MovieID", Storage = "id", IsPrimaryKey = true)]
            public int id { get; set; }
            [Column(Name = "Title", Storage = "title", IsPrimaryKey = true)]
            public string title { get; set; }
            protected DataTable wltb;

            public int CompareTo(WatchlistEntry other)
            {
                return this.title.CompareTo(other.title);

            }

            public static int CompareTo(WatchlistEntry w1, WatchlistEntry w2)
            {
                return w1.CompareTo(w2);
            }

            public static bool operator >(WatchlistEntry w1, WatchlistEntry w2)
            {
                return w1.CompareTo(w2) == 1;
            }

            public static bool operator <(WatchlistEntry w1, WatchlistEntry w2)
            {
                return w1.CompareTo(w2) == -1;
            }

            public static bool operator >=(WatchlistEntry w1, WatchlistEntry w2)
            {
                return w1.CompareTo(w2) == 0;
            }

            public static bool operator <=(WatchlistEntry w1, WatchlistEntry w2)
            {
                return w1.CompareTo(w2) == 0;
            }

            
           

    }
    }
}

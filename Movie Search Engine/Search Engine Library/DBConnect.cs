using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Search_Engine_Library
{
    class DBConnect
    {
        public void Connect()
        {
            DataContext database = new DataContext(@"\Movie Search Engine\Search Engine Library\Database.mdf");
            Table<Movie> Movies = database.GetTable<Movie>();

            IQueryable<Movie> movQuer =
                from mov in Movies
                select mov;
        }
    }
}

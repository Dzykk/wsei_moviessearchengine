using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;
using System.Data.SqlClient;


namespace Search_Engine_Library
{
    /// <summary>
    /// Klasa DBConnect
    /// Odpowiada za utworzenie połączenia z bazą danych, z którą zintegrowana jest aplikacja.
    /// </summary>
    /// <remarks>
    /// Podczas tworzenia aplikacji korzystano z kilku baz danych. Fizyczna baza danych okazała się niedoskonała, przez co została zamieniona na bazę danych
    /// na lokalnym serwerze SQL.
    /// Jednakże by mieć możliwość korzystania z bazy na wielu maszynach, została ona przeniesiona na MS Azure SQL Server.
    /// </remarks>
    public class DBConnect
    {
        private SqlConnection conn;
        public DBConnect() { }
        
        /// <summary>
        /// Metoda Connect()
        /// Zwraca połączenie z bazą danych, używane do różnych działań związanych z bazą.
        /// </summary>
        /// <returns></returns>
        public SqlConnection Connect()
        {
            //conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\Database.mdf; Integrated Security = True"); physical db
            //conn = new SqlConnection(@"Data Source=DESKTOP-BOFB2DM\SQLEXPRESS;Initial Catalog=MovieDB;Integrated Security=True"); local SQL Server DB
            conn = new SqlConnection(@"Server=tcp:wsei10987.database.windows.net,1433;Initial Catalog=MovieDB;Persist Security Info=False;User ID=Dzykk;Password=Csharp2019;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30"); //Azure SQL Server DB
            return conn;
        }

    }
}


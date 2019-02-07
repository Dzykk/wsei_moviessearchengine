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
    public class DataManipulator
    {
        /// <summary>
        /// Metoda GetMovieData
        /// Służy do tworzenia tabeli danych zawierających filmy.
        /// </summary>
        /// <remarks>
        /// Korzystając z metody DBConnect.Connect(), otwierane jest połączenie i tworzona kwerenda, która pobiera dane o filmach z bazy danych.
        /// Dane następnie ładowane są do tabeli danych, połączenie zamykane, wypełniona tabela zwracana jako wynik metody.
        /// </remarks>
        /// <returns>Tabela danych z filmami.</returns>
        public static DataTable GetMovieData()
        {
            DBConnect dbcon = new DBConnect();
            SqlConnection con = dbcon.Connect();
            con.Open();
            string moviequery = "SELECT * FROM [dbo].[Movie]";
            SqlCommand cmd = new SqlCommand(moviequery, con);

            DataTable moviedt = new DataTable();
            moviedt.Load(cmd.ExecuteReader());
            con.Close();
            return moviedt;
        }
        /// <summary>
        /// Metoda GetUserData
        /// Służy do tworzenia tabeli danych zawierających użytkoników aplikacji.
        /// </summary>
        /// <remarks>
        /// Korzystając z metody DBConnect.Connect(), otwierane jest połączenie i tworzona kwerenda, która pobiera dane o użytkownikach z bazy danych.
        /// Dane następnie ładowane są do tabeli danych, połączenie zamykane, wypełniona tabela zwracana jako wynik metody.
        /// </remarks>
        /// <returns>Tabela danych z użytkownikami.</returns>
        public static DataTable GetUserData()
        {
            DBConnect dbcon = new DBConnect();
            SqlConnection con = dbcon.Connect();
            con.Open();
            string userquery = "SELECT * FROM [dbo].[Account] WHERE [AccountType] = 'AppUser'";
            SqlCommand cmd = new SqlCommand(userquery, con);

            DataTable userdt = new DataTable();
            userdt.Load(cmd.ExecuteReader());
            con.Close();
            return userdt;
        }

        /// <summary>
        /// Lista MovieList
        /// Tworzona z danych z tabeli danych stworzonej w metodzie GetMovieData().
        /// </summary>
        /// <remarks>
        /// Pobierane są poszczególne wiersze z tabeli danych, a następnie tworzone są nowe obiekty typu Movie i dodawane są do Listy
        /// w celu późniejszego wykorzystania i łatwości dostępu.
        /// </remarks>
        public List<Movie> MovieList = (DataManipulator.GetMovieData()).AsEnumerable().Select(row =>
       new Movie
       {
           Id = row.Field<int>("MovieID"),
           Title = row.Field<string>("Title"),
           Price = row.Field<string>("Price"),
           Releasedate = row.Field<DateTime>("ReleaseDate"),
           Genre = DataManipulator.ParseEnum<Genre>((row.Field<string>("Genre").ToString())),
           Language = DataManipulator.ParseEnum<Language>((row.Field<string>("Language").ToString())),
           Runtime = row.Field<string>("Runtime"),
           Poster = row.Field<byte[]>("Poster")
       }
        ).ToList();   
        
        /// <summary>
        /// Metoda ParseEnum<T>
        /// Służy do przekonwertowywania wartości (np. string) na odpowiadającą im wartość Enumeratora. Używana przy dodawaniu filmów do MovieList.
        /// </summary>
        /// <param name="value">Wartość enumeratora, w formacie string</param>
        /// <returns>Enumerator odpowiedniego typu.</returns>
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase: true);
        }

        /// <summary>
        /// Metoda GetPoster
        /// Służy do pobierania plakatu z danej lokacji z dysku.
        /// </summary>
        /// <remarks>
        /// Wykorzystana głównie do załadowania plakatu-zamiennika do nowo dodawanych filmów z poziomu aplikacji.
        /// </remarks>
        /// <param name="path">Lokalizacja pliku, w formacie string</param>
        /// <returns>Plakat, w formacie byte[]</returns>
        public static byte[] GetPoster(string path)
        {
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);
            byte[] poster = reader.ReadBytes((int)stream.Length);
            reader.Close();
            stream.Close();
            return poster;
        }



       
    }
}
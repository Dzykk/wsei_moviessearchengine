using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Search_Engine_Library
{
   public class DBQueries
    {
        /// <summary>
        /// Metoda statyczna CheckExistingUser
        /// Sprawdza, czy podany użytkownik istnieje już w bazie i zwraca wartość 1, jeśli istnieje i 0, jeśli nie istnieje.
        /// </summary>
        /// <remarks>
        /// Wykorzystując połączenie z bazą danych SQL, wysyła kwerendę liczącą ilość wierszy zawierających podany przez użytkownika login. Jeśli zwróci wartość większą niż 0, to znaczy, że 
        /// użytkownik o podanym loginie już istnieje.
        /// </remarks>
        /// <param name="con">Odpowiada za połączenie z bazą danych, w formacie SqlConnection</param>
        /// <param name="username">Odpowiada za login użytkownika, w formacie string</param>
        /// <returns>Wartość 0 lub 1, w zależności od tego, czy użytkownik nie istnieje lub istnieje.</returns>
        public static int CheckExistingUser(SqlConnection con, string username)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT COUNT(*) FROM[dbo].[Account] WHERE[Login] = @Login";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Login", username);
            int usercheck = (int)cmd.ExecuteScalar();
            return usercheck;
        }

        /// <summary>
        /// Metoda statyczna RegisterNewUser
        /// Pobiera dane podane przez użytkownika aplikacji i tworzy nowego użytkownika.
        /// </summary>
        /// <remarks>
        /// Wykorzystując połączenie z bazą danych SQL, wysyła polecenie INSERT do bazy danych, tworząc w bazie nowego użytkownika korzystając z podanych danych.
        /// </remarks>
        /// <param name="con">Odpowiada za połączenie z bazą danych, w formacie SqlConnection</param>
        /// <param name="username">Odpowiada za login użytkownika, w formacie string</param>
        /// <param name="password">Odpowiada za hasło użytkownika, w formacie string</param>
        public static void RegisterNewUser(SqlConnection con, string username, string password)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO[dbo].[Account]([Login], [Password], [AccountType] ) VALUES(@Login, @Password, 'AppUser')";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Login", username);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Metoda statyczna UserLogIn
        /// Sprawdza, czy podany użytkownik istnieje w bazie i zwraca wartość 1, jeśli istnieje i 0, jeśli nie istnieje.
        /// </summary>
        /// <remarks>
        /// Wykorzystując połączenie z bazą danych SQL, wysyła kwerendę liczącą ilość wierszy zawierających podany przez użytkownika login i hasło. Jeśli zwróci wartość większą niż 0, to znaczy, że 
        /// użytkownik o podanym loginie istnieje i może się zalogować.
        /// </remarks>
        /// <param name="con">Odpowiada za połączenie z bazą danych, w formacie SqlConnection</param>
        /// <param name="username">Odpowiada za login użytkownika, w formacie string</param>
        /// <param name="password">Odpowiada za hasło użytkownika, w formacie string</param>
        /// <returns>Wartość 0 lub 1, w zależności od tego, czy użytkownik nie istnieje lub istnieje.</returns>
        public static int UserLogIn(SqlConnection con, string username, string password)
        {         
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT COUNT(1) FROM Account WHERE Login=@Username AND Password=@Password";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            int usercheck = (int)cmd.ExecuteScalar();
            return usercheck;
        }

        /// <summary>
        /// Metoda statyczna CheckExistingMovie
        /// Sprawdza, czy podany film istnieje już w bazie i zwraca wartość 1, jeśli istnieje i 0, jeśli nie istnieje.
        /// </summary>
        /// <remarks>
        /// Wykorzystując połączenie z bazą danych SQL, wysyła kwerendę liczącą ilość wierszy zawierających podany przez administratora tytuł filmu. Jeśli zwróci wartość większą niż 0, to znaczy, że 
        /// film o podanym tytule już istnieje.
        /// </remarks>
        /// <param name="con">Odpowiada za połączenie z bazą danych, w formacie SqlConnection</param>
        /// <param name="title">Odpowiada za tytuł filmu, w formacie string</param>
        /// <returns></returns>
        public static int CheckExistingMovie(SqlConnection con, string title)
        {                        
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM [dbo].[Movie] WHERE [Title] = @Title";
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Title", title);
            int recordscheck = (int)cmd.ExecuteScalar();
            return recordscheck;
        }

        /// <summary>
        /// Metoda statyczna AddNewMovie
        /// Pobiera dane podane przez administratora w aplikacji dane, by dodać nowy film do bazy danych.
        /// </summary>
        /// <remarks>
        /// Wykorzystując połączenie z bazą danych SQL, wysyła polecenie INSERT do bazy danych, tworząc w bazie nowy film zgodnie z podanymi danymi. Pobiera także z dysku plakat-zamiennik,
        /// który zajmie miejsce prawdziwego plakatu (problemy z implementacją) i korzystając z metody GetPoster, zamienia go na tablicę byte.
        /// </remarks>
        /// <param name="con">Odpowiada za połączenie z bazą danych, w formacie SqlConnection</param>
        /// <param name="title">Odpowiada za tytuł filmu, w formacie string</param>
        /// <param name="price">Odpowiada za cenę filmu, w formacie string</param>
        /// <param name="releasedate">Odpowiada za datę wydania filmu, w formacie string</param>
        /// <param name="genre">Odpowiada za gatunek filmu, w formacie string</param>
        /// <param name="language">Odpowiada za język filmu, w formacie string</param>
        /// <param name="runtime">Odpowiada za czas trwania filmu, w formacie string</param>
        public static void AddNewMovie(SqlConnection con, string title, string price, string releasedate, string genre, string language, string runtime)
        {
            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"posters\", "default.jpg");
            byte[] poster = DataManipulator.GetPoster(path);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO [dbo].[Movie] (Title, Price, ReleaseDate, Genre, [Language], Runtime, Poster) VALUES (@Title, @Price, @ReleaseDate, @Genre, @Language, @Runtime, @Poster)";
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.Parameters.AddWithValue("@ReleaseDate", releasedate);
            cmd.Parameters.AddWithValue("@Genre", genre);
            cmd.Parameters.AddWithValue("@Language", language);
            cmd.Parameters.AddWithValue("@Runtime", runtime);
            cmd.Parameters.Add("Poster", SqlDbType.Image, poster.Length).Value = poster;
            cmd.ExecuteNonQuery();
        }

    }
}

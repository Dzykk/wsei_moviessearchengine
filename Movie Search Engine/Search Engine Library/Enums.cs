namespace Search_Engine_Library
{
   /// <summary>
   /// Enum Genre
   /// Odpowiada za wszystkie gatunki filmów, jakie mogą mieć filmy znajdujące się w aplikacji.
   /// </summary>
        public enum Genre
        {
            Action = 1, Adventure, Comedy, Documentary, Drama, Family, Fantasy, Horror, Scifi, Thriller
        }
    /// <summary>
    /// Enum Language
    /// Odpowiada za wszystkie języki, w których filmy mogą występować w aplikacji
    /// </summary>
        public enum Language
        {
            English = 1, Polish, German, Spanish
        }
    /// <summary>
    /// Enum Privilege
    /// Odpowiada za przypisanie uprawnień administratorom oraz użytkownikom
    /// </summary>
        public enum Privilege
    {
        Admin, AppUser
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;
using System.Data.SqlClient;

namespace Search_Engine_Library
{   
    /// <summary>
    /// Klasa User
    /// Dziedziczy po klasie abstrakcyjnej Account.
    /// </summary>
    /// <remarks>
    /// Dodatkowo zawiera pole przechowujące rodzaj użytkownika jako enumerator oraz metodę przeciążoną ToString.
    /// Posiada konstruktor dwuargumentowy na wypadek konieczności sztucznego utworzenia użytkownika.
    /// </remarks>
    public class User : Account
    {
        /// <summary>
        /// Konstruktor dwuargumentowy
        /// Tworzy użytkownika z podanego loginu oraz hasła, przypisując mu z góry rodzaj użytkownika AppUser.
        /// </summary>
        /// <param name="login">Odpowiada za login, w formacie string</param>
        /// <param name="password">Odpowiada za hasło, w formacie string</param>
        public User (string login, string password)
        {
            this.login = login;
            this.password = password;
            this.privileges = Privilege.AppUser;
        }
       
        protected Privilege privileges
        {
            set
            {
                this.privileges = value;
            }
        }

        public override string ToString()
        {
            return Login + "is a registered App User";
        }
    }
}

﻿using System;
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

    
    /// <summary>
    /// Klasa Abstrakcyjna Account
    /// Zawiera pola odpowiedzialne za dane użytkowników aplikacji.
    /// </summary>
    /// <remarks>
    /// Zawiera implementacje interfejsów IComparable oraz IEquatable w celu porównywania ze sobą użytkowników.
    /// W związku z integracją aplikacji z bazą danych, wszelkie dane pobierane są z bazy, a jej budowa odpowiada za brak powtórzeń i sortowanie.
    /// </remarks>
    public abstract class Account : IComparable<Account>, IEquatable<Account>
    {     

        protected string login;
        public string Login
        {
            get
            {
                return this.login;
            }
            set
            {
                this.login = value;
            }
        }
        
        protected string password
        {
            set
            {
                this.password = value;
            }
        }
        /// <summary>
        /// Metoda Equals
        /// Sprawdza loginy użytkowników, a następnie zwraca true gdy są takie same, i false gdy się różnią.
        /// </summary>
        /// <param name="other">Odpowiada za porównywanego użytkownika, w formacie Account</param>
        /// <returns>Wartość boolowską 0 lub 1</returns>
        public bool Equals(Account other)
        {
            return this.Login.Equals(other.Login);
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType())) return false;
            else return this.Login.Equals(((Account)obj).Login);
        }

        public static bool Equals(Account a1, Account a2)
        {
            return a1.Equals(a2);
        }

        public static bool operator ==(Account a1, Account a2)
        {
            return a1.Equals(a2);
        }
        public static bool operator !=(Account a1, Account a2)
        {
            return !a1.Equals(a2);
        }

        /// <summary>
        /// Metoda CompareTo
        /// Sprawdza użytkowników pod kątem ich nazw loginów i ustala, który jest większy, a który mniejszy.
        /// </summary>
        /// <param name="other">Odpowiada za porównywanego użytkownika, w formacie Account</param>
        /// <returns>Wartość 1 gdy obiekt jest większy, 0 gdy taki sam, -1 gdy mniejszy.</returns>
        public int CompareTo(Account other)
        {
            return this.Login.CompareTo(other.Login);
        }

        public static int CompareTo(Account a1, Account a2)
        {
            return a1.CompareTo(a2);
        }

        public static bool operator >(Account a1, Account a2)
        {
            return a1.CompareTo(a2) == 1;
        }

        public static bool operator <(Account a1, Account a2)
        {
            return a1.CompareTo(a2) == -1;
        }

        public static bool operator >=(Account a1, Account a2)
        {
            return a1.CompareTo(a2) >= 0;
        }

        public static bool operator <=(Account a1, Account a2)
        {
            return a1.CompareTo(a2) <= 0;
        }       

        

    }
}

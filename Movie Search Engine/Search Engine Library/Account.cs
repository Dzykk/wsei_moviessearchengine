using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search_Engine_Library
{
    class Account : IComparable<Account>, IEquatable<Account>
    {
        protected string login;
        public string Login => login;
        protected string password;

        public bool Equals(Account other)
        {
            return this.Login.Equals(other.Login);
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
            return a1.CompareTo(a2) == 0;
        }

        public static bool operator <=(Account a1, Account a2)
        {
            return a1.CompareTo(a2) == 0;
        }

    }
}

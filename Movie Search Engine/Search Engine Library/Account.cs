using System;
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
    [Table(Name = "Account")]
    public abstract class Account : IComparable<Account>, IEquatable<Account>
    {

        protected string login;
        [Column(Name = "Login", Storage = "login", IsPrimaryKey = false)]
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
        [Column(Name = "Password", Storage = "password", IsPrimaryKey = false)]
        protected string password
        {
            set
            {
                this.password = value;
            }
        }

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

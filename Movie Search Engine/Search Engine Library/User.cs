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
    [Table(Name = "Account")]
    public class User : Account
    {
        public User (string login, string password)
        {
            this.login = login;
            this.password = password;
        }
        [Column(Name = "AccountType", Storage = "privileges", IsPrimaryKey = false)]
        protected Privilege privileges
        {
            set
            {
                this.privileges = value;
            }
        }               
    }
}

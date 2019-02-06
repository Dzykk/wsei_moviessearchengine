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
    class Administrator : Account
    {
        [Column(Name = "AccountType", Storage = "privileges", IsPrimaryKey = false)]
        protected Privilege privileges
        {
            set
            {
                this.privileges = value;
            }
        }

        public override string ToString()
        {
            return Login + "is an Administrator.";
        }
    }
}

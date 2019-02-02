using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search_Engine_Library
{
    class User : Account
    {
        protected Privilege privileges = Privilege.AppUser;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search_Engine_Library
{
    class Administrator : Account
    {
        protected Privilege privileges = Privilege.Admin;
    }
}

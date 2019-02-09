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
    /// <summary>
    /// Klasa Administrator
    /// Dziedziczy po klasie abstrakcyjnej Account.
    /// </summary>
    /// <remarks>
    /// Dodatkowo zawiera pole przechowujące rodzaj użytkownika (jako Enum) oraz metodę przeciążoną ToString().
    /// </remarks>
    class Administrator : Account
    {        
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

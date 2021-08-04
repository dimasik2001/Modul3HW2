using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul3HW2.Models;

namespace Modul3HW2.Helpers
{
    public class ContactComparer : IComparer<Contact>
    {
        public int Compare(Contact x, Contact y)
        {
            return string.Compare(x.FullName, y.FullName);
        }
    }
}

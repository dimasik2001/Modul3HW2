using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul3HW2.Models;

namespace Modul3HW2.Helpers
{
    public class GroupsComparer : IComparer<KeyValuePair<string, List<Contact>>>
    {
        private string _sequence;
        public GroupsComparer(string alphabet)
        {
            _sequence = alphabet;
        }

        public int Compare(KeyValuePair<string, List<Contact>> x, KeyValuePair<string, List<Contact>> y)
        {
               if (GetPosition(x.Key) > GetPosition(y.Key))
               {
                    return 1;
               }
               else if (GetPosition(x.Key) < GetPosition(y.Key))
                {
                    return -1;
                }
               else
                {
                    return 0;
                }
        }

        private int GetPosition(string x)
        {
           return _sequence.IndexOf(x);
        }
    }
}

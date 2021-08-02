using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul3HW2.Models;

namespace Modul3HW2.Services.Abstractions
{
    public interface IContactService
    {
        public void Add(Contact contact);

        public void Delete(Contact contact);

        public void ChangeCulture(CultureInfo culture);
        public IReadOnlyCollection<KeyValuePair<string, List<Contact>>> GetAllGroups();
    }
}

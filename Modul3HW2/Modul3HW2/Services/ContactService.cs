using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul3HW2.Collections;
using Modul3HW2.Enums;
using Modul3HW2.Models;
using Modul3HW2.Services.Abstractions;

namespace Modul3HW2.Services
{
    public class ContactService : IContactService
    {
        private readonly IConfigService _config;
        private ContactCollection _phoneBook;
        private CultureInfo _cultureInfo;
        public ContactService(IConfigService config)
        {
            _config = config;
            Init(CultureInfo.CurrentCulture);
        }

        public void Add(Contact contact)
        {
            switch (_config.NamePriority)
            {
                case NamePriority.FirstName:
                    contact.FullName = $"{contact.FirstName} {contact.LastName}";
                    break;
                case NamePriority.LastName:
                    contact.FullName = $"{contact.LastName} {contact.FirstName}";
                    break;
            }

            _phoneBook.Add(contact);
            _phoneBook.SortGroups(_config.GetAlphabet(_cultureInfo));
            _phoneBook.SortContacts();
        }

        public void Delete(Contact contact)
        {
            _phoneBook.Delete(contact);
        }

        public void ChangeCulture(CultureInfo culture)
        {
            if (_cultureInfo != culture)
            {
                var oldTelephoneBook = _phoneBook;
                Init(culture);
                foreach (var contact in oldTelephoneBook)
                {
                    Add(contact);
                }
            }
        }

        public IReadOnlyCollection<KeyValuePair<string, List<Contact>>> GetAllGroups()
        {
            return _phoneBook.GetAllGroups();
        }

        private void Init(CultureInfo culture)
        {
            _cultureInfo = culture;
            _phoneBook = new ContactCollection(_config.GetAlphabet(_cultureInfo));
        }
    }
}

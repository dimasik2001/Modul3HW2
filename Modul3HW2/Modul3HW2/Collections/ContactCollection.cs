using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul3HW2.Helpers;
using Modul3HW2.Models;

namespace Modul3HW2.Collections
{
    public class ContactCollection : IReadOnlyCollection<Contact>
    {
        private const string _numKey = "0 - 9";
        private const string _otherCharKey = "#";

        private readonly Alphabet _alphabet;
        private List<KeyValuePair<string, List<Contact>>> _phoneBook;

        public ContactCollection(Alphabet alphabet)
        {
            _phoneBook = new List<KeyValuePair<string, List<Contact>>>();
            _alphabet = alphabet;
        }

        public int Count => GetCount();

        public IEnumerator<Contact> GetEnumerator()
        {
            foreach (var group in _phoneBook)
            {
                foreach (var contact in group.Value)
                {
                    yield return contact;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }

        public KeyValuePair<string, List<Contact>> GetGroup(string key)
        {
            foreach (var group in _phoneBook)
            {
                if (group.Key == key)
                {
                    return group;
                }
            }

            throw new KeyNotFoundException("Contacts didn't find");
        }

        public IReadOnlyCollection<KeyValuePair<string, List<Contact>>> GetAllGroups()
        {
            return _phoneBook;
        }

        public void Add(Contact contact)
        {
            var currentkey = DefineGroup(contact);
            try
            {
                GetGroup(currentkey).Value.Add(contact);
            }
            catch (KeyNotFoundException)
            {
                var newList = new List<Contact>();
                newList.Add(contact);
                _phoneBook.Add(new KeyValuePair<string, List<Contact>>(currentkey, newList));
            }
        }

        public bool Delete(Contact contact)
        {
            try
            {
                var group = GetGroup(DefineGroup(contact));
                if (group.Value.Remove(contact) && group.Value.Count == 0)
                {
                    _phoneBook.Remove(group);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }

        public void SortGroups(Alphabet alphabet)
        {
            _phoneBook.Sort(new GroupsComparer(_numKey + alphabet.Letters + _otherCharKey));
        }

        public void SortContacts()
        {
            foreach (var group in _phoneBook)
            {
                group.Value.Sort(new ContactComparer());
            }
        }

        private int GetCount()
        {
            var count = 0;
            foreach (var group in _phoneBook)
            {
                count += group.Value.Count;
            }

            return count;
        }

        private string DefineGroup(Contact contact)
        {
            var contactKey = contact.FullName[0].ToString();
            if (_alphabet.Letters.Contains(contactKey, StringComparison.OrdinalIgnoreCase))
            {
                return contactKey.ToUpper();
            }
            else if (int.TryParse(contactKey, out var result))
            {
                return _numKey;
            }
            else
            {
                return _otherCharKey;
            }
        }
    }
}

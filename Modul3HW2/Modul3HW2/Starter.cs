using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul3HW2.Providers;
using Modul3HW2.Services;
using Modul3HW2.Services.Abstractions;

namespace Modul3HW2
{
    public class Starter
    {
        private readonly IContactService _contactService;
        private readonly ContactProvider _contactProvider;
        public Starter(IContactService contactService, ContactProvider contactProvider)
        {
            _contactService = contactService;
            _contactProvider = contactProvider;
        }

        public void Run()
        {
            foreach (var item in _contactProvider.Contacts)
            {
                _contactService.Add(item);
            }

            Console.WriteLine("Current culture:");
            Console.WriteLine("______________________________");
            foreach (var group in _contactService.GetAllGroups())
            {
                Console.WriteLine($"KEY '{group.Key}' :");
                Console.WriteLine();
                foreach (var contact in group.Value)
                {
                    Console.WriteLine($"Full Name: {contact.FullName}  Phone: {contact.Phone}");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("English culture:");
            Console.WriteLine("______________________________");
            _contactService.ChangeCulture(CultureInfo.GetCultureInfoByIetfLanguageTag("en-US"));
            foreach (var group in _contactService.GetAllGroups())
            {
                Console.WriteLine($"KEY '{group.Key}' :");
                Console.WriteLine();
                foreach (var contact in group.Value)
                {
                    Console.WriteLine($"Full Name: {contact.FullName}  Phone: {contact.Phone}");
                    Console.WriteLine();
                }
            }
        }
    }
}

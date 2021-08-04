using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul3HW2.Models;

namespace Modul3HW2.Providers
{
    public class ContactProvider
    {
        private Contact[] _contacts;
        public ContactProvider()
        {
            _contacts = new Contact[]
            {
                new Contact()
                {
                    FirstName = "Bill",
                    LastName = "Smith",
                    Phone = "166-722-555"
                },
                new Contact()
                {
                    FirstName = "Олег",
                    LastName = "Иванов",
                    Phone = "099-122-1321"
                },
                new Contact()
                {
                    FirstName = "35382",
                    LastName = string.Empty,
                    Phone = "055-444-33"
                },
                new Contact()
                {
                    FirstName = "Дмитрий",
                    LastName = "Субота",
                    Phone = "8-800-555-3535"
                },
                new Contact()
                {
                    FirstName = "Wendy",
                    LastName = "Grace",
                    Phone = "777-543"
                },
                new Contact()
                {
                    FirstName = "Rick",
                    LastName = "Sanchez",
                    Phone = "137-532"
                },
                new Contact()
                {
                    FirstName = "Владимир",
                    LastName = "Зеленский",
                    Phone = "044-674-645"
                }, new Contact()
                {
                    FirstName = "Bro",
                    LastName = string.Empty,
                    Phone = "055-532-46"
                },
                new Contact()
                {
                    FirstName = "&($@",
                    LastName = "$^*(",
                    Phone = "111-1111-11"
                },
                new Contact()
                {
                    FirstName = "1515",
                    LastName = "Hello",
                    Phone = "98-7678"
                }
            };
        }

        public Contact[] Contacts => _contacts;
    }
}

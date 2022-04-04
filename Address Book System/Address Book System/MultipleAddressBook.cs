using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Address_Book_System
{
    public class MultipleAddressBook
    {
        private ArrayList contactList;
        public Dictionary<string, AddressBook> contacts;
        private Dictionary<string, Dictionary<string, AddressBook>> multipleContacts;

        public MultipleAddressBook()
        {
            contactList = new ArrayList();
            contacts = new Dictionary<string, AddressBook>();
            multipleContacts = new Dictionary<string, Dictionary<string, AddressBook>>();
        }
        public void AddContact()
        {
            Console.WriteLine("Enter your First Name: ");
            string firstName = Console.ReadLine();
            if (!multipleContacts.ContainsKey(firstName))
            {
                Console.WriteLine("Firstname already exists");
            }
            Console.WriteLine("Enter your Last Name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter your Address: ");
            string address = Console.ReadLine();
            Console.WriteLine("Enter your city: ");
            string city = Console.ReadLine();
            Console.WriteLine("Enter your State: ");
            string state = Console.ReadLine();
            Console.WriteLine("Enter your Zip: ");
            string zipCode = Console.ReadLine();
            Console.WriteLine("Enter your Phone Number: ");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter your Email: ");
            string email = Console.ReadLine();

            AddressBook addresses = new AddressBook(firstName.ToLower(), lastName, address, city, state, zipCode, phoneNumber, email);
            contactList.Add(addresses);
            contacts.Add(firstName, addresses);
        }
        public void GetContact()
        {
            foreach (KeyValuePair<string, AddressBook> item in contacts)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}

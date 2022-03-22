using System;
using System.Collections;
using System.Collections.Generic;

namespace Address_Book_System
{
    public class AddressBook
    {
        private string firstName;
        private string lastName;
        private string address;
        private string city;
        private string state;
        private string zipCode;
        private string phoneNumber;
        private string email;

        public AddressBook(string firstName, string lastName, string address, string city,
            string state, string zipCode, string phoneNumber, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zipCode = zipCode;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }

        public override string ToString()
        {
            return "Details are: " + "\nFirstName - " + firstName +
                "\nLastName " + lastName +
                "\nAddress: " + address +
                "\nCity: " + city + ", state: " + state + "" +
                "\nZip " + zipCode + " \nPhone: " + phoneNumber + " \nEmail: " + email;
        }

        internal class Program
        {
            private ArrayList contactList;
            private Dictionary<string, AddressBook> contacts;

            public Program()
            {
                contactList = new ArrayList();
                contacts = new Dictionary<string, AddressBook>();
            }

            public void AddContact()
            {
                Console.WriteLine("Enter your First Name: ");
                string firstName = Console.ReadLine();
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
                try
                {
                    contacts.Add(firstName.ToLower(), addresses);
                }
                catch (Exception)
                {
                    Console.WriteLine("Key already exists");
                }
            }
            public void GetContact()
            {
                foreach (KeyValuePair<string, AddressBook> item in contacts)
                {
                    Console.WriteLine(item.Value);
                }
            }

            public void EditContacts(string key)
            {
                if (contacts.ContainsKey(key))
                {
                    Console.WriteLine("Enter your First Name: ");
                    string firstName = Console.ReadLine();
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
                    contacts[key] = addresses;
                }
                else
                {
                    Console.WriteLine("First Name doesnt exist");
                }
            }
            private void DeleteContacts()
            {
                Console.WriteLine("Enter first name to Delete");
                string input = Console.ReadLine();
                if (contacts.ContainsKey(input.ToLower()))
                {
                    contacts.Remove(input.ToLower());
                }
                else
                {
                    Console.WriteLine("first name doesnt exist");
                }
            }

            static void Main(string[] args)
            {
                Console.WriteLine("Welcome to Address Book Program");
                var program = new Program();
                int option = 0;
                do
                {
                    Console.WriteLine("Choose 1: To Add a Contact");
                    Console.WriteLine("Choose 2: To get Contacts");
                    Console.WriteLine("Choose 3: To Edit a contact");
                    Console.WriteLine("Choose 4: To Delete a Contact");
                    Console.WriteLine("Choose 0: To Exit");
                    try
                    {
                        option = int.Parse(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                program.AddContact();
                                continue;
                            case 2:
                                program.GetContact();
                                continue;
                            case 3:
                                Console.WriteLine("Enter first name");
                                string key = Console.ReadLine();
                                program.EditContacts(key);
                                break;
                            case 4:
                                program.DeleteContacts();
                                break;
                            case 0:
                                Console.WriteLine("Good Day");
                                break;
                            default:
                                Console.WriteLine("Choose valid Option");
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please choose an option");
                    }
                } while (option != 0);
            }
        }
    }
}

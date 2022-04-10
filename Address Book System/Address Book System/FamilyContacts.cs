using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Address_Book_System
{
    internal class FamilyContacts
    {
        private List<Person> contactList;
        private Dictionary<string, Person> contacts;

        public FamilyContacts()
        {
            contactList = new List<Person>();
            contacts = new Dictionary<string, Person>();
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
            Person addresses = new Person(firstName.ToLower(), lastName, address, city, state, zipCode, phoneNumber, email);
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
            foreach (KeyValuePair<string, Person> item in contacts)
            {
                Console.WriteLine(item.Value);
            }
        }

        public void EditContacts()
        {
            Console.WriteLine("Enter first name");
            string key = Console.ReadLine();
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
                Person addresses = new Person(firstName.ToLower(), lastName, address, city, state, zipCode, phoneNumber, email);
                contactList.Add(addresses);
                contacts[key] = addresses;
            }
            else
                Console.WriteLine("First Name doesnt exist");
        }
        public void DeleteContacts()
        {
            Console.WriteLine("Enter first name to Delete:");
            string input = Console.ReadLine();
            if (contacts.ContainsKey(input.ToLower()))
                contacts.Remove(input.ToLower());
            else
                Console.WriteLine("first name doesnt exist");
        }

        public void SearchContact()
        {
            Console.WriteLine("Enter city or state:");
            string city = Console.ReadLine();
            Console.WriteLine($"Details of People who live in {city} - ");
            foreach (var item in contacts)
            {
                if (item.Value.city == city || item.Value.state == city)
                    Console.WriteLine(item.Value);
            }
        }
        /// <summary>
        /// Get count of person by city or state
        /// </summary>
        /// <param name="city"></param>
        public void PersonCount()
        {
            Console.WriteLine("Enter city or state");
            string city = Console.ReadLine();
            int count = 0;
            foreach (var item in contacts)
            {
                if (item.Value.city == city || item.Value.state == city)
                    count++;
            }
            Console.WriteLine($"Number of People who lives in {city} is {count}");
        }

        public void SortedContactsByName()
        {
            foreach (KeyValuePair<string, Person> item in contacts.OrderBy(x => x.Key))
                Console.WriteLine(item.Value);
        }


        public void SortedContactsByCityStateZip()
        {
            Console.WriteLine("Choose 1: To Search contacts by City");
            Console.WriteLine("Choose 2: To Search contacts by State");
            Console.WriteLine("Choose 3: To Search contacts by Zip");
            try
            {
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        foreach (KeyValuePair<string, Person> item in contacts.OrderBy(x => x.Value.city))
                            Console.WriteLine(item.Value);
                        break;
                    case 2:
                        foreach (KeyValuePair<string, Person> item in contacts.OrderBy(x => x.Value.state))
                            Console.WriteLine(item.Value);
                        break;
                    case 3:
                        foreach (KeyValuePair<string, Person> item in contacts.OrderBy(x => x.Value.zipCode))
                            Console.WriteLine(item.Value);
                        break;
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Please choose appropriate options from above");
            }
        }

        public void AddContactsToFile()
        {
            string write = @"F:\FRP .net Git\AddressBookSystem\Address Book System\Address Book System\TextFile\FamilyContacts.txt";
            using (StreamWriter writer = File.AppendText(write))
            {
                foreach (var item in contacts)
                    writer.WriteLine(item.ToString());
                writer.Close();
            }
        }


        public void ReadContactsFromFile()
        {
            string read = @"F:\FRP .net Git\AddressBookSystem\Address Book System\Address Book System\TextFile\FamilyContacts.txt";
            string file = File.ReadAllText(read);
            Console.WriteLine(file.ToString());
        }

        public void ReadOrWrite()
        {
            Console.WriteLine("1: Add to file");
            Console.WriteLine("2: To Read from file");
            Console.WriteLine("3: To Delete file");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    AddContactsToFile();
                    break;
                case 2:
                    ReadContactsFromFile();
                    break;
                case 3:
                    File.Delete(@"F:\FRP .net Git\AddressBookSystem\Address Book System\Address Book System\TextFile\FamilyContacts.txt");
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Create csv File
        /// </summary>
        public void CreateCsvFile()
        {
            string exportFilePath = @"F:\FRP .net Git\AddressBookSystem\Address Book System\Address Book System\CsvFile\FamilyAddressBook.csv";
            //Writing
            using (StreamWriter writer = new StreamWriter(exportFilePath))
            using (CsvWriter csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                List<Person> sortedList = contactList.OrderBy(x => x.firstName).ToList();
                csvExport.WriteRecords(sortedList);
            }
            Console.WriteLine($"Created a CSV file at {exportFilePath}");
        }
        /// <summary>
        /// Read a csv File
        /// </summary>
        public void ReadCsvFile()
        {
            string importFilePath = @"F:\FRP .net Git\AddressBookSystem\Address Book System\Address Book System\CsvFile\FamilyAddressBook.csv";

            using (TextReader reader = new StreamReader(importFilePath))
            using (CsvReader csvFile = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                List<Person> records = csvFile.GetRecords<Person>().ToList();
                Console.WriteLine("List of names are -");
                foreach (var item in records)
                    Console.WriteLine(item.firstName);
            }
        }
        public void ReadWriteCSVFile()
        {
            Console.WriteLine("1: Create a CSV File");
            Console.WriteLine("2: Read a CSV File");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    CreateCsvFile();
                    break;
                case 2:
                    ReadCsvFile();
                    break;
                default:
                    break;
            }
        }

        public void JSONFileSerialization()
        {
            string path = @"F:\FRP .net Git\AddressBookSystem\Address Book System\Address Book System\JSONFile\FamilyContacts.json";
            string serializedData = JsonConvert.SerializeObject(contacts);
            using (StreamWriter writer = File.CreateText(path))
            {
                writer.Flush();
                writer.WriteLine(serializedData);
                Console.WriteLine(serializedData);
            }
        }

        public void JSONDeserialize()
        {
            string path = @"F:\FRP .net Git\AddressBookSystem\Address Book System\Address Book System\JSONFile\FamilyContacts.json";
            string deserialisedData = File.ReadAllText(path);
            var deserialised = JsonConvert.DeserializeObject<Dictionary<string, Person>>(deserialisedData);
            foreach (var item in deserialised)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }

        public void JsonFile()
        {
            Console.WriteLine("1: Serialize");
            Console.WriteLine("2: Deserealise");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    JSONFileSerialization();
                    break;
                case 2:
                    JSONDeserialize();
                    break;
            }
        }
    }
}
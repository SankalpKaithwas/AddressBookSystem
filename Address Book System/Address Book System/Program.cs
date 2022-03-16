using System;

namespace Address_Book_System
{
    public class AddressBook
    {
        public string firstName;
        public string lastName;
        public string address;
        public string city;
        public string state;
        public int zipCode;
        public int phoneNumber;
        public string email;
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            AddressBook address = new AddressBook();
            Console.WriteLine("Welcome to Address Book Program");
            Console.WriteLine("Enter your First Name: ");
            address.firstName = Console.ReadLine();
            Console.WriteLine("Enter your Last Name: ");
            address.lastName = Console.ReadLine();
            Console.WriteLine("Enter your Address: ");
            address.address = Console.ReadLine();
            Console.WriteLine("Enter your city: ");
            address.city = Console.ReadLine();
            Console.WriteLine("Enter your State: ");
            address.state = Console.ReadLine();
            Console.WriteLine("Enter your Zip: ");
            address.zipCode = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Phone Number: ");
            address.phoneNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Email: ");
            address.email = Console.ReadLine();

        }
    }
}

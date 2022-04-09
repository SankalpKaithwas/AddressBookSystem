namespace Address_Book_System
{
    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string city { get; set; }

        public Person(string firstName, string lastName, string address, string city,
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
            return "Details are - " + "\nFirstName: " + firstName +
                "\nLastName: " + lastName +
                "\nAddress: " + address +
                "\nCity: " + city + ", state: " + state +
                "\nZip: " + zipCode + " \nPhone: " + phoneNumber +
                "\nEmail: " + email;
        }
    }
}


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
    }
}


using NUnit.Framework;
using Address_Book_System;

namespace AddressBookSystemTest
{
    public class Tests
    {
        Validation validation;
        [SetUp]
        public void Setup()
        {
            validation = new Validation();
        }

        [TestCase("Sankalp")]
        [TestCase("sankalp")]
        public void FirstNameValidation(string firstName)
        {
            try
            {
                var result = validation.CheckFirstName(firstName);
            }
            catch (ValidationException ex)
            {
                Assert.AreEqual("First name is Invalid", ex.Message);
            }
        }
    }
}
using System;

namespace PhoneBook.Exceptions
{
    public class ContactNotFoundException : Exception
    {
        public ContactNotFoundException(string id) : base($"Contact \"{id}\" not found") { }
    }
}

namespace PhoneBook.Data
{
    public class Contact
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }

        public Contact(string id, string name, string phoneNumber)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}

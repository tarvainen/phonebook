using MediatR;
using PhoneBook.Data;

namespace PhoneBook.Contacts.Commands
{
    public class AddContactCommand : IRequest<Contact>
    {
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }

        public AddContactCommand(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}

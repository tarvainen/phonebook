using MediatR;
using PhoneBook.Data;

namespace PhoneBook.Contacts.Commands
{
    public class RemoveContactCommand : IRequest<Contact>
    {
        public string Id { get; private set; }

        public RemoveContactCommand(string id)
        {
            Id = id;
        }
    }
}

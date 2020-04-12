using System.Collections.Generic;
using MediatR;
using PhoneBook.Data;

namespace PhoneBook.Contacts.Queries
{
    public class GetAllContactsQuery : IRequest<List<Contact>>
    {
    }
}

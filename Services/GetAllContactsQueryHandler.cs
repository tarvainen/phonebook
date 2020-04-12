using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PhoneBook.Contacts.Queries;
using PhoneBook.Data;

namespace PhoneBook.Services
{
    public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, List<Contact>>
    {
        private readonly DataContext _context;

        public GetAllContactsQueryHandler(DataContext context)
        {
            _context = context;
        }

        public Task<List<Contact>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_context.Contacts.ToList());
        }
    }
}

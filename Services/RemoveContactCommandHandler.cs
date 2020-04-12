using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PhoneBook.Contacts.Commands;
using PhoneBook.Data;

namespace PhoneBook.Services
{
    public class RemoveContactCommandHandler : IRequestHandler<RemoveContactCommand, Contact>
    {
        private readonly DataContext _context;

        public RemoveContactCommandHandler(DataContext context)
        {
            _context = context;
        }

        public Task<Contact> Handle(RemoveContactCommand request, CancellationToken cancellationToken)
        {
            var contact = _context.Contacts.Find(request.Id);

            if (contact == null) throw new InvalidOperationException($"Contact with id {request.Id} was not found");

            _context.Remove(contact);
            _context.SaveChanges();

            return Task.FromResult(contact);
        }
    }
}

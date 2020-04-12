using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PhoneBook.Contacts.Commands;
using PhoneBook.Data;
using PhoneBook.Exceptions;

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

            if (contact == null) throw new ContactNotFoundException(request.Id);

            _context.Remove(contact);
            _context.SaveChanges();

            return Task.FromResult(contact);
        }
    }
}

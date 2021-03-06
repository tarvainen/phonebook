using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PhoneBook.Contacts.Commands;
using PhoneBook.Data;

namespace PhoneBook.Handlers
{
    public class AddContactCommandHandler : IRequestHandler<AddContactCommand, Contact>
    {
        private readonly DataContext _context;

        public AddContactCommandHandler(DataContext context)
        {
            _context = context;
        }

        public Task<Contact> Handle(AddContactCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.Add(new Contact(Guid.NewGuid().ToString(), request.Name, request.PhoneNumber)).Entity;

            _context.SaveChanges();

            return Task.FromResult(entity);
        }
    }
}

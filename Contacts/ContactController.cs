using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using PhoneBook.Contacts.Commands;
using PhoneBook.Data;
using System.Threading.Tasks;
using PhoneBook.Contacts.Dto;
using PhoneBook.Contacts.Queries;

namespace PhoneBook.Contacts
{
    public class ContactController : Controller
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/")]
        public async Task<Contact> AddContact([FromBody] ContactDto contact) =>
            await _mediator.Send(new AddContactCommand(contact.Name, contact.PhoneNumber));

        [HttpGet("/")]
        public async Task<IEnumerable<Contact>> ListContacts() =>
            await _mediator.Send(new GetAllContactsQuery());

        [HttpDelete("/{id}")]
        public async Task<Contact> RemoveContact([FromRoute] string id) =>
            await _mediator.Send(new RemoveContactCommand(id));
    }
}

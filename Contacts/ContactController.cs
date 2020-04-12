using Microsoft.AspNetCore.Mvc;
using MediatR;
using PhoneBook.Contacts.Commands;
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
        public async Task<IActionResult> AddContact([FromBody] ContactDto contact) =>
            Ok(await _mediator.Send(new AddContactCommand(contact.Name, contact.PhoneNumber)));

        [HttpGet("/")]
        public async Task<IActionResult> ListContacts() =>
            Ok(await _mediator.Send(new GetAllContactsQuery()));

        [HttpDelete("/{id}")]
        public async Task<IActionResult> RemoveContact([FromRoute] string id) =>
            Ok(await _mediator.Send(new RemoveContactCommand(id)));
    }
}

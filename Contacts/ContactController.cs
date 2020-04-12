using Microsoft.AspNetCore.Mvc;
using PhoneBook.Data;
using MediatR;
using PhoneBook.Contacts.Commands;
using System.Threading.Tasks;
using PhoneBook.Contacts.Dto;
using PhoneBook.Contacts.Queries;

namespace PhoneBook.Contacts
{
    public class ContactController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IMediator _mediator;

        public ContactController(DataContext dataContext, IMediator mediator)
        {
            _dataContext = dataContext;
            _mediator = mediator;
        }

        [HttpPost("/")]
        public async Task<IActionResult> AddContact([FromBody] ContactDto contact) =>
            Ok(await _mediator.Send(new AddContactCommand(contact.Name, contact.PhoneNumber)));

        [HttpGet("/")]
        public async Task<IActionResult> ListContacts() =>
            Ok(await _mediator.Send(new GetAllContactsQuery()));

        [HttpDelete("/{id}")]
        public IActionResult DeleteContact([FromRoute] string id)
        {
            var contact = _dataContext.Contacts.Find(id);

            if (contact == null) return new NotFoundResult();

            _dataContext.Contacts.Remove(contact);

            _dataContext.SaveChanges();

            return Ok();
        }
    }
}

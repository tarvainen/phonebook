using Microsoft.AspNetCore.Mvc;
using PhoneBook.Data;
using MediatR;
using PhoneBook.Contacts.Commands;
using System.Threading.Tasks;
using PhoneBook.Contacts.Dto;

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
            Ok(await _mediator.Send(new AddContact(contact.Name, contact.PhoneNumber)));

        [HttpGet("/")]
        public IActionResult ListContacts() => Ok(_dataContext.Contacts);

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

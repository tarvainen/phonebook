using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Data;

namespace PhoneBook.Contacts
{
    public class ContactController : Controller
    {
        private readonly DataContext _dataContext;

        public ContactController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost("/")]
        public IActionResult AddContact()
        {
            var contact = new Contact(Guid.NewGuid().ToString(), "John", "123456");

            var result = _dataContext.Contacts.Add(contact);

            _dataContext.SaveChanges();

            return Ok(result.Entity);
        }

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

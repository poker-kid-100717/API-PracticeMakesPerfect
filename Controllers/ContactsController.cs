using API.Data;
using API.Models.Domain;
using API.Models.Dtos.Contact;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public ContactsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllContacts()
        {
            var contacts = dbContext.Contacts.ToList();
            return Ok(contacts);
        }

        [HttpPost]
        public IActionResult AddContact(AddContactRequestDto request)
        {
            var domainModelContact = new Contact
            {
                Id = Guid.NewGuid(),
                Name = request?.Name,
                OrganizationName = request?.OrganizationName,
                Email = request?.Email,
                Phone = request?.Phone,
                IsInterviewSchedule = request?.IsInterviewSchedule,
            };

            dbContext.Contacts.Add(domainModelContact);
            dbContext.SaveChanges();
            return Ok(domainModelContact);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateContact(Guid id, UpdateContactRequestDto request)
        {
            var existingContact = dbContext.Contacts.FirstOrDefault(c => c.Id == id);
            if (existingContact == null)
            {
                return NotFound($"Contact with ID {id} not found.");
            }

            // Update the existing contact's properties
            existingContact.Name = request?.Name;
            existingContact.OrganizationName = request?.OrganizationName;
            existingContact.Email = request?.Email;
            existingContact.Phone = request?.Phone;
            existingContact.IsInterviewSchedule = request?.IsInterviewSchedule;

            dbContext.SaveChanges();
            return Ok(existingContact);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteContact(Guid id)
        {
            var contact = dbContext.Contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null)
            {
                return NotFound($"Contact with ID {id} not found.");
            }

            dbContext.Contacts.Remove(contact);
            dbContext.SaveChanges();
            GetAllContacts();

            return Ok($"Contact with ID {id} deleted successfully.");
        }
    }
}

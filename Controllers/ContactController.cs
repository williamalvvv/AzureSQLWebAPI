using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AzureSQLWebAPI.Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private ContactsContext contactsContext;

        public ContactController(ContactsContext context)
        {
            contactsContext = context;
        }

        //Get Method Fully Functional
        [HttpGet]
        public ActionResult<IEnumerable<Contacts>> Get()
        {
            return contactsContext.ContactsSet.ToList();
        }

        //GetByID Method Fully Functional
        [HttpGet("{id}")]
        public ActionResult<Contacts> Get(int id)
        {
            var selectedContact = (from c in contactsContext.ContactsSet
                                    where c.identifier == id.ToString()
                                    select c).FirstOrDefault();
            
            return selectedContact;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Contacts value)
        {
            Contacts newContact = value;
            contactsContext.ContactsSet.Add(newContact);
            contactsContext.SaveChanges();

            return Ok("Contact Successfully Inserted");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Contacts value)
        {
            Contacts updatedContact = value;
            var selectedElement = contactsContext.ContactsSet.Find(updatedContact.identifier);
            selectedElement.name = value.name;
            selectedElement.email = value.email;
            contactsContext.SaveChanges();
            
            return Ok("Contact Successfully Updated");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) 
        {
            var selectedContact = (from c in contactsContext.ContactsSet
                                    where c.identifier == id.ToString()
                                    select c).FirstOrDefault();
            //var deletionContact = contactsContext.ContactsSet.Find(id);
            contactsContext.ContactsSet.Remove(selectedContact);
            contactsContext.SaveChanges();
            return Ok("Contact Successfully Deleted");
        }

        ~ContactController()
        {
            contactsContext.Dispose();
        }


    }
}
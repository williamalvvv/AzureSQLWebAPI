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

        ~ContactController()
        {
            contactsContext.Dispose();
        }


    }
}
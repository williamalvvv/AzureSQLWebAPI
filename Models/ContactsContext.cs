using Microsoft.EntityFrameworkCore;

namespace AzureSQLWebAPI.Models
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Contacts> ContactsSet {get; set;}
    }
}
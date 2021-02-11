using System.ComponentModel.DataAnnotations;

namespace AzureSQLWebAPI.Models
{
    public class Contacts
    {
        [Key]
        public string identifier {get; set;}
        public string name {get; set;}
        public string email {get; set;}
        public string phoneNumber {get; set;}
    }
}
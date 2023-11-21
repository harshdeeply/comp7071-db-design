using System.ComponentModel.DataAnnotations.Schema;

namespace hr_webapi.Models
{
    public class EmergencyContact: Person
    {
        public Guid EmergencyContactId { get; set; }
        public string Relationship { get; set; }
    }
}
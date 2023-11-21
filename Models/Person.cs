using System.ComponentModel.DataAnnotations.Schema;

namespace hr_webapi.Models
{
    public class Person
    {
        public Guid PersonId { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public Address? CurrentAddress { get; set; }
    }
}
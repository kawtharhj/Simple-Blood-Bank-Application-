using System.ComponentModel.DataAnnotations;

namespace BloodBank.Models
{
    public class Donor
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? BloodGroup { get; set; }

        [Required]
        public string? Phone { get; set; }

        public string? Contact { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        
    }
}

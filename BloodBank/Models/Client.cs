using Microsoft.Build.Framework;

namespace BloodBank.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Message { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? Subject { get; set; }
    }
}

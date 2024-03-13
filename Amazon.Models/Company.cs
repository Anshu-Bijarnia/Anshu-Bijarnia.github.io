using System.ComponentModel.DataAnnotations;

namespace Amazon.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Display(Name = "Street Address")]
        public String? StreetAddress { get; set; }
        public String? City { get; set; }
        public String? State { get; set; }
        [Display(Name = "Postal Code")]
        public String? PostalCode { get; set; }
        [Phone]
        [Display(Name = "Phone number")]
        public string? PhoneNumber { get; set; }
    }
}

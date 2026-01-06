using System.ComponentModel.DataAnnotations;

namespace BookCafeAutomation.Customers
{
    public class CreateUpdateCustomerDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [EmailAddress] 
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
    }
}
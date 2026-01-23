using System.ComponentModel.DataAnnotations;

namespace BookCafeAutomation.Customers
{
    public class CreateUpdateCustomerDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(128)]
        public string Surname { get; set; } // Email yerine Surname eklendi

        [Required]
        [StringLength(11)]
        public string PhoneNumber { get; set; }

   
    }
}
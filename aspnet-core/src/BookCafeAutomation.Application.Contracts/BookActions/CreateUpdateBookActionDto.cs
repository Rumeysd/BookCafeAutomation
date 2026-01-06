using System;
using System.ComponentModel.DataAnnotations;

namespace BookCafeAutomation.BookActions
{
    public class CreateUpdateBookActionDto
    {
        [Required]
        public Guid BookId { get; set; }

        [Required]
        public Guid CustomerId { get; set; }

        public DateTime ActionDate { get; set; } = DateTime.Now;

        [Required]
        public string ActionType { get; set; } // Enum varsa onu kullanabilirsin
    }
}
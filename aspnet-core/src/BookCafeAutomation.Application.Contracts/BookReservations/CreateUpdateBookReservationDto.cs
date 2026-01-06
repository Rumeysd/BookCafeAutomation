using System;
using System.ComponentModel.DataAnnotations;

namespace BookCafeAutomation.BookReservations
{
    public class CreateUpdateBookReservationDto
    {
        [Required]
        public Guid BookId { get; set; }

        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }
    }
}
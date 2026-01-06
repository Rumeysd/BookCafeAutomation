using System;
using Volo.Abp.Application.Dtos;

namespace BookCafeAutomation.BookReservations
{
    public class BookReservationDto : EntityDto<Guid>
    {
        public Guid BookId { get; set; }
        public string BookName { get; set; }

        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }

        public DateTime ReservationDate { get; set; }
        public DateTime? ExpirationDate { get; set; } // Ne zamana kadar geçerli?
        public bool IsActive { get; set; }
    }
}
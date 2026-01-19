using BookCafeAutomation.Books;
using BookCafeAutomation.Customers;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace BookCafeAutomation.BookReservations
{
    // DÜZELTME 1: ABP'den miras aldık (ID ve Audit özellikleri geldi)
    public class BookReservation : FullAuditedAggregateRoot<Guid>
    {
        public Guid BookId { get; set; }
        public virtual Book Book { get; set; }

        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }


        public ReservationStatus Status { get; set; }

       
        public DateTime? ReservationExpirationTime { get; set; }

        protected BookReservation()
        {
        }

        public BookReservation(Guid id, Guid bookId, Guid customerId)
            : base(id)
        {
            BookId = bookId;
            CustomerId = customerId;
            Status = ReservationStatus.InQueue; 
        }
    }
}
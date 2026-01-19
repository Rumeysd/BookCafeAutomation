using System;
using Volo.Abp.Domain.Entities.Auditing;
using BookCafeAutomation.Books;      
using BookCafeAutomation.Customers;  

namespace BookCafeAutomation.BookNotes
{
    public class BookNote : FullAuditedAggregateRoot<Guid>
    {
        public Guid BookId { get; set; }
     
        public virtual Book Book { get; set; }

        public Guid CustomerId { get; set; }
     
        public virtual Customer Customer { get; set; }

        public string Note { get; set; }
        public bool IsPublic { get; set; }

        protected BookNote() { }

        public BookNote(Guid id, Guid bookId, Guid customerId, string note, bool isPublic = false)
            : base(id)
        {
           
            BookId = bookId;
            CustomerId = customerId;
            Note = note;
            IsPublic = isPublic;
        }
    }
}
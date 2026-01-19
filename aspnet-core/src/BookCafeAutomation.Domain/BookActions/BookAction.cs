using System;
using Volo.Abp.Domain.Entities.Auditing;
using BookCafeAutomation.Books;    
using BookCafeAutomation.Customers;

namespace BookCafeAutomation.BookActions
{
    public class BookAction : FullAuditedAggregateRoot<Guid>
    {
     
        public Guid BookId { get; set; }
        
        public virtual Book Book { get; set; }

     
        public Guid CustomerId { get; set; }
       
        public virtual Customer Customer { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int LastPageNumber { get; set; }

        protected BookAction()
        {
        }

        public BookAction(Guid id, Guid bookId, Guid customerId)
            : base(id)
        {
            BookId = bookId;
            CustomerId = customerId;
            StartTime = DateTime.Now;
            EndTime = null;
            LastPageNumber = 0;
        }

  
        public void FinishReading(int lastPage)
        {
            EndTime = DateTime.Now;
            LastPageNumber = lastPage;
        }
    }
}
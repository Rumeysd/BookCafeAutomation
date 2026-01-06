using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace DENEME.BookActions
{
    public class BookAction : FullAuditedAggregateRoot<Guid>
    {
        public Guid BookId { get; set; }

        public Guid CustomerId { get; set; }

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
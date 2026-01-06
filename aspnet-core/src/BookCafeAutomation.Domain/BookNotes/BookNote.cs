using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace BookCafeAutomation.BookNotes
{
    public class BookNote :  FullAuditedAggregateRoot<Guid>
    {
        public Guid BookId { get; set; }

        public Guid CustomerId { get; set; }

        public string Note {  get; set; }

        public bool IsPublic { get; set; }

        protected BookNote() { }

        public BookNote ( Guid id ,Guid bookId, Guid customerId, string note , bool isPublic = false)
            : base (id)
        {
            bookId = BookId;
            customerId = CustomerId;
            note = Note;
            isPublic = IsPublic;

        }

    }
}

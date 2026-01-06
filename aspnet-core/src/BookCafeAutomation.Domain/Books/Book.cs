using System;
using Volo.Abp.Domain.Entities.Auditing;
namespace BookCafeAutomation.Books
{
    public class Book : FullAuditedAggregateRoot<Guid>
    {
     

        public string Name { get; set; }

        public Guid CategoryId { get; set; }

        public Guid AuthorId { get; set; }

        public int PageCount { get; set; }

        public string QrCode { get; set; }

        public BookStatus Status { get; set; }
  

        protected Book(Guid guid)
        {
        }

        public Book(Guid id, string name, Guid authorId, Guid categoryId, int pageCount, string qrCode)
            : base(id)
        {
            Name = name;
            AuthorId = authorId;
            CategoryId = categoryId;
            PageCount = pageCount;
            QrCode = qrCode;
            Status = BookStatus.Available; 
        }

    
    }
}
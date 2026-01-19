using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; 
using Volo.Abp.Domain.Entities.Auditing;
using BookCafeAutomation.Authors; 
using BookCafeAutomation.Categories;

namespace BookCafeAutomation.Books
{
    public class Book : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public int PageCount { get; set; }
        public string QrCode { get; set; }
        public BookStatus Status { get; set; }



        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public Guid AuthorId { get; set; }
        public virtual Author Author { get; set; }


        public ICollection<BookImage> Images { get; set; }


   
        protected Book()
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
            Images = new Collection<BookImage>();
        }
    }
}
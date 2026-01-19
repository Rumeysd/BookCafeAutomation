using System;
using System.Collections.Generic;
using System.Text;

namespace BookCafeAutomation.Books
{
    public class BookDto
    {
        public string Name { get; set; }

        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }

        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }  

        public int PageCount { get; set; }

        public string QrCode { get; set; }

        public BookStatus Status { get; set; }

        public List<BookImageDto> Images { get; set; }

    }
}

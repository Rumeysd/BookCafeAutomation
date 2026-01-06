using System;
using Volo.Abp.Application.Dtos;

namespace BookCafeAutomation.BookActions
{
    public class BookActionDto : EntityDto<Guid>
    {
        public Guid BookId { get; set; }
        public string BookName { get; set; } 

        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }

        public DateTime ActionDate { get; set; }
        public string ActionType { get; set; } 
    }
}
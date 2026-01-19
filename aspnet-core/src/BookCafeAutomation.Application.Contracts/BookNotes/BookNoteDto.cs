using System;
using Volo.Abp.Application.Dtos;

namespace BookCafeAutomation.BookNotes
{
    public class BookNoteDto : AuditedEntityDto<Guid>
    {
        public Guid BookId { get; set; }
        public string Note { get; set; }
        public bool IsPublic { get; set; }
        public string BookName { get; set; }
    }
}
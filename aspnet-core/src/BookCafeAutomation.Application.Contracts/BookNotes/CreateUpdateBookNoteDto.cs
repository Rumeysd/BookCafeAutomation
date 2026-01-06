using System;
using System.ComponentModel.DataAnnotations;

namespace BookCafeAutomation.BookNotes
{
    public class CreateUpdateBookNoteDto
    {
        [Required]
        public Guid BookId { get; set; }

        [Required]
        [StringLength(500)]
        public string Note { get; set; }

        public bool IsPublic { get; set; } = true;
    }
}
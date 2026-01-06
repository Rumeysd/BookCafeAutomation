using System;
using System.ComponentModel.DataAnnotations; // [Required] için gerekli

namespace BookCafeAutomation.Books
{
    public class CreateUpdateBookDto
    {
        [Required(ErrorMessage = "Kitap adı zorunludur.")]
        [StringLength(128, ErrorMessage = "Kitap adı 128 karakterden uzun olamaz.")]
        public string Name { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        [Range(1, 10000, ErrorMessage = "Sayfa sayısı 0 olamaz.")]
        public int PageCount { get; set; }

        [Required]
        public string QrCode { get; set; }

        public BookStatus Status { get; set; } = BookStatus.Available;

    }
}
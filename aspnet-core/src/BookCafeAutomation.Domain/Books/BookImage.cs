using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace BookCafeAutomation.Books;

public class BookImage : FullAuditedEntity<Guid>
{
    public Guid BookId { get; set; }

    public string BlobName { get; set; } 
    public string FileName { get; set; } 
    public string MimeType { get; set; } 
    public long FileSize { get; set; }   

  
    public Book Book { get; set; } 
}
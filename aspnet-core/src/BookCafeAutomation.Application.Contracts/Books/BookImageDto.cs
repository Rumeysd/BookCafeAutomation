using System;

namespace BookCafeAutomation.Books;

public class BookImageDto
{
    public string BlobName { get; set; }
    public string FileName { get; set; }
    public string MimeType { get; set; }
    public long FileSize { get; set; }
}
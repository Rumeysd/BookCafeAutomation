namespace BookCafeAutomation.Books
{
    public enum BookStatus
    {
        Available,      // 0 - Rafında, müsait.
        Reading,        // 1 - Şu an masada biri okuyor.
        Reserved,       // 2 - Sırada bekleyen biri için ayrıldı (15 dk kuralı).
        Maintenance,    // 3 - Bakımda veya kayıp (Listeden silmeden pasife almak için).
        Lost            // 4 - Kayıp 
    }
}
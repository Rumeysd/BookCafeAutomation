namespace BookCafeAutomation.BookReservations
{
    public enum ReservationStatus
    {
        Waiting,            // 0 - Sırada bekliyor (Kitap başkasında)
        NotificationSent,   // 1 - Kitap boşa çıktı, müşteriye "Gel al" dedik (Sayaç başladı)
        Completed,          // 2 - Müşteri geldi ve kitabı teslim aldı
        Canceled,           // 3 - Müşteri vazgeçti
        Expired             // 4 - 15 dakika doldu, müşteri gelmedi
    }
}
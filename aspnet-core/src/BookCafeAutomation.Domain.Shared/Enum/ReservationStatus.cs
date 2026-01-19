namespace BookCafeAutomation.BookReservations
{
    public enum ReservationStatus
    {
        // 0: Henüz sıra gelmedi, kitap başkasında
        InQueue = 0,         // Eski adı: Waiting (Sırada)

        // 1: Kitap boşa çıktı, kullanıcıya "Gel al" dedik, süre işliyor
        ReadyForPickup = 1,  // Eski adı: NotificationSent (Teslime Hazır)

        // 2: Müşteri geldi ve kitabı aldı (Mutlu Son)
        Completed = 2,

        // 3: Müşteri "Ben istemiyorum" dedi
        Canceled = 3,

        // 4: 15 dk doldu, müşteri gelmedi (Sistem iptal etti)
        Expired = 4
    }
}
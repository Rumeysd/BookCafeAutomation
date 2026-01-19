import { ReservationStatus } from '@proxy/book-reservations'; // Proxy'den gelecek

// UI için yardımcı liste
export const reservationStatusOptions = [
  { 
    value: ReservationStatus.InQueue, 
    key: '::Enum:ReservationStatus.InQueue', 
    class: 'badge bg-secondary' // Gri: Sırada
  },
  { 
    value: ReservationStatus.ReadyForPickup, 
    key: '::Enum:ReservationStatus.ReadyForPickup', 
    class: 'badge bg-warning text-dark animate-pulse' // Sarı: Dikkat çeksin, gel al!
  },
  { 
    value: ReservationStatus.Completed, 
    key: '::Enum:ReservationStatus.Completed', 
    class: 'badge bg-success' // Yeşil: Tamam
  },
  { 
    value: ReservationStatus.Canceled, 
    key: '::Enum:ReservationStatus.Canceled', 
    class: 'badge bg-danger' // Kırmızı: İptal
  },
  { 
    value: ReservationStatus.Expired, 
    key: '::Enum:ReservationStatus.Expired', 
    class: 'badge bg-dark' // Siyah: Süresi doldu
  },
];
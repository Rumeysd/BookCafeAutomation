import type { EntityDto } from '@abp/ng.core';
import type { ReservationStatus } from './reservation-status.enum';

export interface BookReservationDto extends EntityDto<string> {
  bookId?: string;
  bookName?: string;
  customerId?: string;
  customerName?: string;
  reservationDate?: string;
  expirationDate?: string | null;
  isActive?: boolean;
  status?: ReservationStatus;
}

export interface CreateUpdateBookReservationDto {
  bookId: string;
  customerId: string;
  reservationDate: string;
  status?: ReservationStatus;
}

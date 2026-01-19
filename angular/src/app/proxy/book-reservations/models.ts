import type { EntityDto } from '@abp/ng.core';

export interface BookReservationDto extends EntityDto<string> {
  bookId?: string;
  bookName?: string;
  customerId?: string;
  customerName?: string;
  reservationDate?: string;
  expirationDate?: string | null;
  isActive?: boolean;
}

export interface CreateUpdateBookReservationDto {
  bookId: string;
  customerId: string;
  reservationDate: string;
}

import { mapEnumToOptions } from '@abp/ng.core';

export enum ReservationStatus {
  InQueue = 0,
  ReadyForPickup = 1,
  Completed = 2,
  Canceled = 3,
  Expired = 4,
}

export const reservationStatusOptions = mapEnumToOptions(ReservationStatus);

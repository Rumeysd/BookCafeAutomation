import { mapEnumToOptions } from '@abp/ng.core';

export enum BookStatus {
  Available = 0,
  Reading = 1,
  Reserved = 2,
  Maintenance = 3,
  Lost = 4,
}

export const bookStatusOptions = mapEnumToOptions(BookStatus);

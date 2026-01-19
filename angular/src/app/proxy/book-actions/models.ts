import type { EntityDto } from '@abp/ng.core';

export interface BookActionDto extends EntityDto<string> {
  bookId?: string;
  bookName?: string;
  customerId?: string;
  customerName?: string;
  actionDate?: string;
  actionType?: string;
}

export interface CreateUpdateBookActionDto {
  bookId: string;
  customerId: string;
  actionDate?: string;
  actionType: string;
}

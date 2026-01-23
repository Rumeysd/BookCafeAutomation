import type { EntityDto } from '@abp/ng.core';

export interface CreateUpdateCustomerDto {
  name: string;
  surname: string;
  phoneNumber: string;
}

export interface CustomerDto extends EntityDto<string> {
  name?: string;
  surname?: string;
  phoneNumber?: string;
  score?: number;
}

import type { AuditedEntityDto } from '@abp/ng.core';

export interface CreateUpdateCustomerDto {
  name: string;
  email: string;
  phoneNumber?: string;
}

export interface CustomerDto extends AuditedEntityDto<string> {
  name?: string;
  email?: string;
  phoneNumber?: string;
}

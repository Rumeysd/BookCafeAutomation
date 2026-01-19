import type { EntityDto } from '@abp/ng.core';

export interface AuthorDto extends EntityDto<string> {
  name?: string;
  shortBio?: string;
}

export interface CreateUpdateAuthorDto {
  name: string;
  shortBio?: string;
}

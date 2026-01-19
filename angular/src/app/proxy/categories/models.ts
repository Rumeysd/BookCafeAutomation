import type { EntityDto } from '@abp/ng.core';

export interface CategoryDto extends EntityDto<string> {
  name?: string;
}

export interface CreateUpdateCategoryDto {
  name: string;
}

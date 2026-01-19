import type { EntityDto } from '@abp/ng.core';
import type { BookStatus } from './book-status.enum';

export interface BookDto extends EntityDto<string> {
  name?: string;
  categoryId?: string;
  categoryName?: string;
  authorId?: string;
  authorName?: string;
  pageCount?: number;
  qrCode?: string;
  status?: BookStatus;
  images?: BookImageDto[];
}

export interface BookImageDto {
  blobName?: string;
  fileName?: string;
  mimeType?: string;
  fileSize?: number;
}

export interface CreateUpdateBookDto {
  name: string;
  categoryId: string;
  authorId: string;
  pageCount: number;
  qrCode: string;
  status?: BookStatus;
  images?: BookImageDto[];
}

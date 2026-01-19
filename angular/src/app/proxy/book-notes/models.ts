import type { AuditedEntityDto } from '@abp/ng.core';

export interface BookNoteDto extends AuditedEntityDto<string> {
  bookId?: string;
  note?: string;
  isPublic?: boolean;
  bookName?: string;
}

export interface CreateUpdateBookNoteDto {
  bookId: string;
  note: string;
  isPublic?: boolean;
}

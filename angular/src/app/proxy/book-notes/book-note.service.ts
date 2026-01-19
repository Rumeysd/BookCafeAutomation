import type { BookNoteDto, CreateUpdateBookNoteDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable, inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class BookNoteService {
  private restService = inject(RestService);
  apiName = 'Default';
  

  create = (input: CreateUpdateBookNoteDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, BookNoteDto>({
      method: 'POST',
      url: '/api/app/book-note',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/book-note/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, BookNoteDto>({
      method: 'GET',
      url: `/api/app/book-note/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<BookNoteDto>>({
      method: 'GET',
      url: '/api/app/book-note',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateUpdateBookNoteDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, BookNoteDto>({
      method: 'PUT',
      url: `/api/app/book-note/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });
}
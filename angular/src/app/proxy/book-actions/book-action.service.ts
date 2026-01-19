import type { BookActionDto, CreateUpdateBookActionDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable, inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class BookActionService {
  private restService = inject(RestService);
  apiName = 'Default';
  

  create = (input: CreateUpdateBookActionDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, BookActionDto>({
      method: 'POST',
      url: '/api/app/book-action',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/book-action/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, BookActionDto>({
      method: 'GET',
      url: `/api/app/book-action/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<BookActionDto>>({
      method: 'GET',
      url: '/api/app/book-action',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateUpdateBookActionDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, BookActionDto>({
      method: 'PUT',
      url: `/api/app/book-action/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });
}
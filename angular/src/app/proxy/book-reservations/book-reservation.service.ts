import type { BookReservationDto, CreateUpdateBookReservationDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable, inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class BookReservationService {
  private restService = inject(RestService);
  apiName = 'Default';
  

  create = (input: CreateUpdateBookReservationDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, BookReservationDto>({
      method: 'POST',
      url: '/api/app/book-reservation',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/book-reservation/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, BookReservationDto>({
      method: 'GET',
      url: `/api/app/book-reservation/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<BookReservationDto>>({
      method: 'GET',
      url: '/api/app/book-reservation',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateUpdateBookReservationDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, BookReservationDto>({
      method: 'PUT',
      url: `/api/app/book-reservation/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });
}
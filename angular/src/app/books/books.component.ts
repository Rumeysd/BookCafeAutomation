import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookService, BookDto } from '@proxy/books'; 
import { PagedResultDto } from '@abp/ng.core';
import { CoreModule } from '@abp/ng.core';
import { CreateBookComponent } from './create-book/create-book.component'; 
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';

// 👇 DÜZELTİLEN IMPORT: Klasör yoluna dikkat et
import { BookStatus, bookStatusOptions } from './../book-reservations/enum/book-status.enum'; 

@Component({
  selector: 'app-books',
  standalone: true,
  imports: [CommonModule, CreateBookComponent, CoreModule], 
  templateUrl: './books.component.html',
  styleUrl: './books.component.scss'
})
export class BooksComponent implements OnInit {
  
  @ViewChild('createBookModal') createBookModal: CreateBookComponent;

  bookList: PagedResultDto<BookDto> = { items: [], totalCount: 0 };
  
  // HTML tarafında kullanmak için değişkenlere atıyoruz
  BookStatus = BookStatus; 
  statusOptions = bookStatusOptions;

  constructor(
    private bookService: BookService,
    private confirmation: ConfirmationService
  ) {}

  ngOnInit(): void {
    this.refreshList();
  }

  refreshList() {
    this.bookService.getList({ maxResultCount: 10, skipCount: 0 }).subscribe(response => {
      this.bookList = response;
    });
  }

  openCreateModal() {
    this.createBookModal.openModal();
  }

  deleteBook(book: BookDto) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure', {
      messageLocalizationParams: [book.name] 
    }).subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.bookService.delete(book.id).subscribe(() => {
            this.refreshList();
        });
      }
    });
  }
  
  getStatusClass(status: number): string {
    const found = this.statusOptions.find(x => x.value === status);
    return found ? found.class : 'badge bg-secondary';
  }

  getStatusLabel(status: number): string {
    const found = this.statusOptions.find(x => x.value === status);
    return found ? found.key : '::Unknown';
  }
}
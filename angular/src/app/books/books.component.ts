import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookService, BookDto } from '@proxy/books'; 
import { PagedResultDto, CoreModule } from '@abp/ng.core'; 
import { CreateBookComponent } from './create-book/create-book.component'; 
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { bookStatusOptions } from './../book-reservations/enum/book-status.enum'; 

@Component({
  selector: 'app-books',
  standalone: true,
  imports: [CommonModule, CreateBookComponent, CoreModule], 
  templateUrl: './books.component.html',
  styleUrl: './books.component.scss'
})
export class BooksComponent implements OnInit {
  // Alt bileşene (CreateBookComponent) erişim sağlıyoruz
  @ViewChild('createBookModal') createBookModal: CreateBookComponent;

  bookList: PagedResultDto<BookDto> = { items: [], totalCount: 0 };
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

  // Butona basıldığında çalışan fonksiyon
  createBook() {
    if (this.createBookModal) {
      this.createBookModal.openModal(); // Alt bileşendeki modal açma fonksiyonunu çağırır
    }
  }

  deleteBook(book: BookDto) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure', {
      messageLocalizationParams: [book.name] 
    }).subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.bookService.delete((book as any).id).subscribe(() => this.refreshList());
      }
    });
  }

  // Durumun rengini döndürür (badge bg-success vb.)
  getStatusClass(status: number): string {
    const found = this.statusOptions.find(x => x.value === status);
    return found ? found.class : 'badge bg-secondary';
  }

  // Localization dosyasındaki "Enum:Status.Available" gibi anahtarları döndürür
  getStatusLabel(status: number): string {
    const found = this.statusOptions.find(x => x.value === status);
    // Eğer enum değerin 0 ise ve 'Available' metnine karşılık geliyorsa:
    // Bu fonksiyon "Enum:Status.Available" döndürmeli
    return found ? found.key : '::Unknown';
  }
}
import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookService, BookDto } from '@proxy/books'; 
import { PagedResultDto, CoreModule } from '@abp/ng.core'; 
import { CreateBookComponent } from './create-book/create-book.component'; 
import { ConfirmationService, Confirmation, ThemeSharedModule } from '@abp/ng.theme.shared'; // ThemeSharedModule eklendi
import { bookStatusOptions } from './../book-reservations/enum/book-status.enum'; 

@Component({
  selector: 'app-books',
  standalone: true,
  // ThemeSharedModule eklenerek abp-modal hatası çözüldü
  imports: [CommonModule, CreateBookComponent, CoreModule, ThemeSharedModule], 
  templateUrl: './books.component.html',
  styleUrl: './books.component.scss'
})
export class BooksComponent implements OnInit {
  @ViewChild('createBookModal') createBookModal: CreateBookComponent;

  bookList: PagedResultDto<BookDto> = { items: [], totalCount: 0 };
  statusOptions = bookStatusOptions;

  // Detay Modalı İçin Gerekli Değişkenler
  isDetailsModalOpen = false; // Hata 2339 çözümü
  selectedBook: BookDto | null = null; 

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
    
    // // Her kitap için resim çekme denemesi yap
    // this.bookList.items.forEach(book => {
    //   if (book.images && book.images.length > 0) {
    //     this.bookService.getBookImage(book.images[0].blobName).subscribe({
    //       next: (base64) => (book as any).imageUrl = base64,
    //       error: () => (book as any).imageUrl = null // Hata olursa ikon gösterilsin
    //     });
    //   }
    // });
  });
}

  createBook() {
    if (this.createBookModal) {
      this.createBookModal.openModal();
    }
  }

  // Detay Modalını Açan Fonksiyon
  openDetails(book: BookDto) {
    this.selectedBook = book;
    this.isDetailsModalOpen = true; // Modalı görünür yapar
  }

  deleteBook(book: BookDto) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure', {
      messageLocalizationParams: [book.name] 
    }).subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.bookService.delete(book.id).subscribe(() => this.refreshList());
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
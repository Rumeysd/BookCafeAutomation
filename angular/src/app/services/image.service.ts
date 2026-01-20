import { Injectable } from '@angular/core';
import { BookService } from '@proxy/books';

@Injectable({ providedIn: 'root' })
export class ImageService {
  constructor(private bookService: BookService) {}

  // Kitabın ilk resmini getirir
  getBookImageUrl(book: any): Promise<string> {
    if (!book.images || book.images.length === 0) {
      return Promise.resolve('assets/images/default-book.png'); // Resim yoksa varsayılan görsel
    }
  //  return this.bookService.getBookImage(book.images[0].blobName).toPromise();
  }

}
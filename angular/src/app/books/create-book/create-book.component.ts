import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ThemeSharedModule, ToasterService } from '@abp/ng.theme.shared';
import { BookService, CreateUpdateBookDto } from '@proxy/books'; // DTO'yu import et
import { AuthorService, AuthorDto } from '@proxy/authors';
import { CategoryService, CategoryDto } from '@proxy/categories';
import { finalize } from 'rxjs/operators'; // 👈 İşlem bitişini yakalamak için RxJS operatörü

@Component({
  selector: 'app-create-book',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, ThemeSharedModule],
  templateUrl: './create-book.component.html',
})
export class CreateBookComponent implements OnInit {

  @Output() onSave = new EventEmitter<void>();

  form: FormGroup;
  isModalOpen = false;
  isBusy = false; // 👈 Sayfa yükleniyor/kaydediliyor durumu

  // Dropdown verileri
  authors: AuthorDto[] = [];
  categories: CategoryDto[] = [];

  constructor(
    private fb: FormBuilder,
    private bookService: BookService,
    private authorService: AuthorService,
    private categoryService: CategoryService,
    private toaster: ToasterService
  ) {}

  ngOnInit(): void {
    // Component doğduğunda sadece dropdown verilerini hazırla
    this.loadDropdownData();
  }

  // 🔄 Verileri paralel ve dinamik çekme
  loadDropdownData() {
    // RxJS forkJoin kullanılabilirdi ama basitlik için ayrı ayrı çekiyoruz
    this.authorService.getList({ maxResultCount: 100 }).subscribe(res => this.authors = res.items);
    this.categoryService.getList({ maxResultCount: 100 }).subscribe(res => this.categories = res.items);
  }

  openModal() {
    this.buildForm();
    this.isModalOpen = true;
  }

  buildForm() {
    this.form = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(2)]],
      authorId: [null, Validators.required],
      categoryId: [null, Validators.required],
      pageCount: [null, [Validators.required, Validators.min(1)]],
      qrCode: [''], // Opsiyonel
      status: [0] // Varsayılan: Müsait
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    this.isBusy = true; // ⏳ Yükleniyor dönmeye başlasın

    const input: CreateUpdateBookDto = this.form.value;

    this.bookService.create(input)
      .pipe(finalize(() => this.isBusy = false)) // 👈 Hata alsa bile busy'i kapat
      .subscribe({
        next: () => {
          this.toaster.success('::SavedSuccessfully'); // 🔔 Başarılı
          this.isModalOpen = false;
          this.onSave.emit();
        },
        error: (err) => {
          // ABP hataları otomatik gösterir ama özel işlem gerekirse buraya yazılır
          this.toaster.error('::ErrorOccurred'); 
        }
      });
  }
}
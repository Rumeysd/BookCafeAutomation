import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ThemeSharedModule, ToasterService } from '@abp/ng.theme.shared';
import { CoreModule } from '@abp/ng.core'; 
import { BookService } from '@proxy/books';
import { AuthorService, AuthorDto } from '@proxy/authors';
import { CategoryService, CategoryDto } from '@proxy/categories';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-create-book',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, ThemeSharedModule, CoreModule],
  templateUrl: './create-book.component.html',
})
export class CreateBookComponent implements OnInit {
  @Output() onSave = new EventEmitter<void>();

  form: FormGroup;
  isModalOpen = false; 
  isBusy = false;

  authors: AuthorDto[] = [];
  categories: CategoryDto[] = [];
  
  previewUrl: string | null = null;
  selectedImageDto: any = null;

  constructor(
    private fb: FormBuilder,
    private bookService: BookService,
    private authorService: AuthorService,
    private categoryService: CategoryService,
    private toaster: ToasterService
  ) {}

  ngOnInit(): void {
    this.loadDropdownData();
  }

  loadDropdownData() {
    this.authorService.getList({ maxResultCount: 100 }).subscribe(res => (this.authors = res.items));
    this.categoryService.getList({ maxResultCount: 100 }).subscribe(res => (this.categories = res.items));
  }

  openModal() {
    this.buildForm(); // Her açılışta formu sıfırla
    this.previewUrl = null;
    this.selectedImageDto = null;
    this.isModalOpen = true; 
  }

  buildForm() {
    this.form = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(2)]],
      authorId: [null, Validators.required],
      categoryId: [null, Validators.required],
      pageCount: [null, [Validators.required, Validators.min(1)]],
      qrCode: [''],
      status: [0], 
    });
  }

  onFileSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = () => (this.previewUrl = reader.result as string);
      reader.readAsDataURL(file);

      // Backend'deki BookImageDto yapısıyla birebir eşleşme
      this.selectedImageDto = {
        fileName: file.name,
        mimeType: file.type,
        fileSize: file.size,
        blobName: file.name 
      };
    }
  }

  save() {
    // Çift istek gönderimini engellemek için isBusy kontrolü
    if (this.form.invalid || this.isBusy) return;
    this.isBusy = true;

    const formValues = this.form.value;

    // Backend'in beklediği temiz DTO yapısı
    const input = {
      name: formValues.name,
      authorId: formValues.authorId,
      categoryId: formValues.categoryId,
      pageCount: Number(formValues.pageCount),
      qrCode: formValues.qrCode || '',
      status: Number(formValues.status) || 0,
      images: this.selectedImageDto 
        ? [
            {
              blobName: this.selectedImageDto.blobName,
              fileName: this.selectedImageDto.fileName,
              mimeType: this.selectedImageDto.mimeType,
              fileSize: Number(this.selectedImageDto.fileSize),
            },
          ]
        : [],
    };

    console.log('API-ye gönderilen veri paketi:', input);

    // Tek bir create çağrısı
    this.bookService.create(input)
      .pipe(finalize(() => (this.isBusy = false)))
      .subscribe({
        next: () => {
          // tr.json'daki SavedSuccessfully anahtarını tetikler
          this.toaster.success('SavedSuccessfully'); 
          this.isModalOpen = false;
          this.onSave.emit();
        },
        error: (err) => {
          console.error("Kaydetme Hatası Detayı:", err);
          const errorMessage = err.error?.error?.message || 'Kaydedilirken sunucu tarafında bir hata oluştu!';
          this.toaster.error(errorMessage);
        }
      });
  }
}
using AutoMapper;
using BookCafeAutomation.Authors;     // 👈 Bu namespace'leri eklemeyi unutma
using BookCafeAutomation.Categories;
using BookCafeAutomation.Books;

namespace BookCafeAutomation;

public class BookCafeAutomationApplicationAutoMapperProfile : Profile
{
    public BookCafeAutomationApplicationAutoMapperProfile()
    {
        /* Mevcut kodların... */

        // --- YAZAR (AUTHOR) HARİTALARI ---
        CreateMap<Author, AuthorDto>();
        CreateMap<CreateUpdateAuthorDto, Author>();

        // --- KATEGORİ (CATEGORY) HARİTALARI ---
        CreateMap<Category, CategoryDto>();
        CreateMap<CreateUpdateCategoryDto, Category>();

        // --- KİTAP (BOOK) HARİTALARI (Zaten vardır ama kontrol et) ---
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();

        // --- HAREKET (BOOK ACTION) ---
        // Eğer Action servisi de varsa onun da map'i lazım
        // CreateMap<BookAction, BookActionDto>();
        // CreateMap<CreateUpdateBookActionDto, BookAction>();
    }
}
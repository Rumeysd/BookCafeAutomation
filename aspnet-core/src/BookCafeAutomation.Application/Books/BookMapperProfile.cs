using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BookCafeAutomation.Books;

public class BookMapperProfile : Profile
{
    public BookMapperProfile()
    {
        // 1. Kitap Entity -> Kitap DTO
        // "BookCafeAutomation.Books.Book" diyerek Domain'dekini kastettiğimizi söylüyoruz.
        CreateMap<BookCafeAutomation.Books.Book, BookCafeAutomation.Books.BookDto>()
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

        // 2. Kitap Oluşturma DTO -> Kitap Entity
        CreateMap<BookCafeAutomation.Books.CreateUpdateBookDto, BookCafeAutomation.Books.Book>();

        // 3. Resim Entity -> Resim DTO
        CreateMap<BookCafeAutomation.Books.BookImage, BookCafeAutomation.Books.BookImageDto>();
    }
}
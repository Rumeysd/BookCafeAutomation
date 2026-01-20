using AutoMapper;
using Volo.Abp.AutoMapper;

namespace BookCafeAutomation.Books;

public class BookMapperProfile : Profile
{
    public BookMapperProfile()
    {
        // 1. Kitap Listeleme
        CreateMap<Book, BookDto>()
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

        // 2. Kitap Kayıt/Güncelleme
        CreateMap<CreateUpdateBookDto, Book>()
            .IgnoreFullAuditedObjectProperties()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images));

        // 3. Resim Kayıt (DTO -> Entity)
        CreateMap<BookImageDto, BookImage>()
            .IgnoreFullAuditedObjectProperties()
            .Ignore(x => x.Id)
            .Ignore(x => x.BookId)
            .Ignore(x => x.Book);

        // 4. Resim Listeleme (Entity -> DTO) - BU EKSİKTİ, EKLEDİK
        CreateMap<BookImage, BookImageDto>();
    }
}
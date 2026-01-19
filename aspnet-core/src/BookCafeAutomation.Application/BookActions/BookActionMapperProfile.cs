using AutoMapper;
using BookCafeAutomation.BookActions;

namespace BookCafeAutomation.BookActions;

public class BookActionMapperProfile : Profile
{
    public BookActionMapperProfile()
    {
        CreateMap<BookAction, BookActionDto>()
             .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.Book.Name))
             .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name));

        CreateMap<CreateUpdateBookActionDto, BookAction>();
    }
}
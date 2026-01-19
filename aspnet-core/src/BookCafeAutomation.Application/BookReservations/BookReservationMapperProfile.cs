using AutoMapper;
using BookCafeAutomation.BookReservations;

namespace BookCafeAutomation.BookReservations;

public class BookReservationMapperProfile : Profile
{
    public BookReservationMapperProfile()
    {
        CreateMap<BookReservation, BookReservationDto>()
             .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.Book.Name))
             .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name)); 

        CreateMap<CreateUpdateBookReservationDto, BookReservation>();
    }
}
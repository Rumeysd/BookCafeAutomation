using AutoMapper;
using BookCafeAutomation.BookNotes;

namespace BookCafeAutomation.BookNotes;

public class BookNoteMapperProfile : Profile
{
    public BookNoteMapperProfile()
    {
        // Notu çekerken Kitap Adını da gösterelim
        CreateMap<BookNote, BookNoteDto>()
            .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.Book.Name));

        CreateMap<CreateUpdateBookNoteDto, BookNote>();
    }
}
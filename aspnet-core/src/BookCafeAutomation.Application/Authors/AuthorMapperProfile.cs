using AutoMapper;
using BookCafeAutomation.Authors;

namespace BookCafeAutomation.Authors;

public class AuthorMapperProfile : Profile
{
    public AuthorMapperProfile()
    {
        CreateMap<Author, AuthorDto>();
        CreateMap<CreateUpdateAuthorDto, Author>();
    }
}
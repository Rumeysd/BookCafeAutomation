using AutoMapper;
using BookCafeAutomation.Categories;

namespace BookCafeAutomation.Categories;

public class CategoryMapperProfile : Profile
{
    public CategoryMapperProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CreateUpdateCategoryDto, Category>();
    }
}
using AutoMapper;
using BookCafeAutomation.Customers;

namespace BookCafeAutomation.Customers;

public class CustomerMapperProfile : Profile
{
    public CustomerMapperProfile()
    {
    
        CreateMap<Customer, CustomerDto>();

        
        CreateMap<CreateUpdateCustomerDto, Customer>();
    }
}
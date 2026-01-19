using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookCafeAutomation.Customers;

public interface ICustomerAppService : ICrudAppService<
    CustomerDto,
    Guid,
    PagedAndSortedResultRequestDto,
    CreateUpdateCustomerDto>
{
}
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookCafeAutomation.Customers;


public interface ICustomerAppService : ICrudAppService<
    CustomerDto,
    Guid,
    PagedAndSortedResultRequestDto,
    CreateUpdateCustomerDto>
{
    Task<string> GetCurrentUserNameAsync();
    Task<bool> RegisterAsync(string name, string surname, string phoneNumber);
}
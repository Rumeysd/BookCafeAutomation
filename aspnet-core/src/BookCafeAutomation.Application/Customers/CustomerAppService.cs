using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity; 
using Volo.Abp.Users;
using Microsoft.AspNetCore.Authorization;

namespace BookCafeAutomation.Customers;

public class CustomerAppService : CrudAppService<
    Customer,
    CustomerDto,
    Guid,
    PagedAndSortedResultRequestDto,
    CreateUpdateCustomerDto>, ICustomerAppService
{
    
    private readonly IdentityUserManager _userManager;
    public CustomerAppService(
        IRepository<Customer, Guid> repository,
        IdentityUserManager userManager) 
        : base(repository)
    {
        _userManager = userManager;
    }
    [Authorize]
    public async Task<string> GetCurrentUserNameAsync()
    {
      
        var user = await _userManager.GetByIdAsync(CurrentUser.GetId());

        return user.Name;
    }
}
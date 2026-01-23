// ApplicationService yerine CrudAppService'den türetmelisin
using BookCafeAutomation.Customers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Users;

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

    [AllowAnonymous]
    public async Task<string> GetCurrentUserNameAsync()
    {
        var userId = CurrentUser.Id;

        if (userId == null) return "Misafir"; // Token gitmese bile Angular hata almaz

        // user nesnesi null dönebilir (kullanıcı silinmiş olabilir vb.)
        var user = await _userManager.FindByIdAsync(userId.Value.ToString());

        // Hem user null mı hem Name boş mu kontrolü yapalım
        return !string.IsNullOrEmpty(user?.Name) ? user.Name : "Kullanıcı";
    }

    public async Task<bool> RegisterAsync(string name, string surname, string phoneNumber)
    {
        var existingUser = await _userManager.FindByNameAsync(phoneNumber);
        if (existingUser != null)
        {
            throw new UserFriendlyException("Bu telefon numarası zaten sistemde kayıtlı.");
        }

        var user = new Volo.Abp.Identity.IdentityUser(
            Guid.NewGuid(),
            userName: phoneNumber,
            email: phoneNumber + "@bookcafe.com"
        );

        user.Name = name;
        user.Surname = surname;
        user.SetPhoneNumber(phoneNumber, true);

        var result = await _userManager.CreateAsync(user, phoneNumber);

        if (!result.Succeeded)
        {
            throw new UserFriendlyException("Kayıt oluşturulurken bir hata oluştu.");
        }

        return true;
    }
}
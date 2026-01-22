using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;

public class BookCafeDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    // 1. ADIM: Değişkeni burada tanımlamalısın
    private readonly IdentityUserManager _userManager;

    // 2. ADIM: Constructor içinde enjekte etmelisin
    public BookCafeDataSeedContributor(IdentityUserManager userManager)
    {
        _userManager = userManager;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        var phoneNumber = "05555555555";

        // 3. ADIM: Artık _userManager burada tanınacaktır
        if (await _userManager.FindByNameAsync(phoneNumber) == null)
        {
            // Kullanıcı oluşturma kodların buraya gelecek...
            var user = new IdentityUser(Guid.NewGuid(), phoneNumber, "rumeysa@bookcafe.com");
            user.Name = "Rum";
            user.Surname = "Demirhan";

            await _userManager.CreateAsync(user, phoneNumber);
        }
    }
}
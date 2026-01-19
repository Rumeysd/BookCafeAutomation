using BookCafeAutomation.Authors;
using BookCafeAutomation.Authors;
using BookCafeAutomation.BookActions;
using BookCafeAutomation.BookNotes;
using BookCafeAutomation.BookReservations;
using BookCafeAutomation.Books;
using BookCafeAutomation.Books;
using BookCafeAutomation.Categories;
using BookCafeAutomation.Categories;
using BookCafeAutomation.Customers;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;


namespace BookCafeAutomation.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class BookCafeAutomationDbContext :
    AbpDbContext<BookCafeAutomationDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext



{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<BookAction> BookActions { get; set; }
    public DbSet<BookNote> Notes { get; set; }
    public DbSet<BookReservation> Reservations { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<BookImage> BookImages { get; set; }

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }
    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public BookCafeAutomationDbContext(DbContextOptions<BookCafeAutomationDbContext> options)
        : base(options)
    {


    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */
        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();



        // 1. KİTAP (BOOK) KONFİGÜRASYONU
        builder.Entity<Book>(b =>
        {
            // Tablo adı: AppBooks (Standart ABP öneki ile)
            b.ToTable(BookCafeAutomationConsts.DbTablePrefix + "Books", BookCafeAutomationConsts.DbSchema);
            b.ConfigureByConvention();

            // İLİŞKİLER
            // Bir kitabın Yazarı vardır (AuthorId ile bağlanır)
            b.HasOne(x => x.Author)
                .WithMany()
                .HasForeignKey(x => x.AuthorId)
                .IsRequired();

            // Bir kitabın Kategorisi vardır (CategoryId ile bağlanır)
            b.HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId)
                .IsRequired();

            // 🔥 KRİTİK: Bir kitabın ÇOK resmi vardır (Images)
            b.HasMany(x => x.Images)
                .WithOne()
                .HasForeignKey(x => x.BookId)
                .IsRequired(); // Resim sahipsiz olamaz
        });

        // 2. KİTAP RESMİ (BOOK IMAGE) KONFİGÜRASYONU
        builder.Entity<BookImage>(b =>
        {
            b.ToTable(BookCafeAutomationConsts.DbTablePrefix + "BookImages", BookCafeAutomationConsts.DbSchema);
            b.ConfigureByConvention();

            // Metadata alanlarının özellikleri (isteğe bağlı, zorunluluklar)
            b.Property(x => x.FileName).IsRequired().HasMaxLength(255);
            b.Property(x => x.BlobName).IsRequired().HasMaxLength(128);
            b.Property(x => x.MimeType).HasMaxLength(64);
        });

        // 3. YAZAR (AUTHOR)
        builder.Entity<Author>(b =>
        {
            b.ToTable(BookCafeAutomationConsts.DbTablePrefix + "Authors", BookCafeAutomationConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Name).IsRequired().HasMaxLength(128);
        });

        // 4. KATEGORİ (CATEGORY)
        builder.Entity<Category>(b =>
        {
            b.ToTable(BookCafeAutomationConsts.DbTablePrefix + "Categories", BookCafeAutomationConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Name).IsRequired().HasMaxLength(128);
        });

        // 5. MÜŞTERİ (CUSTOMER)
        builder.Entity<Customer>(b =>
        {
            b.ToTable(BookCafeAutomationConsts.DbTablePrefix + "Customers", BookCafeAutomationConsts.DbSchema);
            b.ConfigureByConvention();
        });

        // 6. DİĞER TABLOLAR (Standart isimlendirme için)
        builder.Entity<BookAction>(b =>
        {
            b.ToTable(BookCafeAutomationConsts.DbTablePrefix + "BookActions", BookCafeAutomationConsts.DbSchema);
            b.ConfigureByConvention();
        });

        builder.Entity<BookNote>(b =>
        {
            b.ToTable(BookCafeAutomationConsts.DbTablePrefix + "BookNotes", BookCafeAutomationConsts.DbSchema);
            b.ConfigureByConvention();
        });

        builder.Entity<BookReservation>(b =>
        {
            b.ToTable(BookCafeAutomationConsts.DbTablePrefix + "BookReservations", BookCafeAutomationConsts.DbSchema);
            b.ConfigureByConvention();
        });
    }
}

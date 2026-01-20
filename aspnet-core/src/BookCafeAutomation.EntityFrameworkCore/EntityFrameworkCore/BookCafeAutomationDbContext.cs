using BookCafeAutomation.Authors;
using BookCafeAutomation.BookActions;
using BookCafeAutomation.BookNotes;
using BookCafeAutomation.BookReservations;
using BookCafeAutomation.Books;
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

    #region Identity & Tenant Management Entities
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }
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

        /* ABP Modül Konfigürasyonları */
        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        // --- 1. KİTAP (BOOK) KONFİGÜRASYONU ---
        builder.Entity<Book>(b =>
        {
            b.ToTable(BookCafeAutomationConsts.DbTablePrefix + "Books", BookCafeAutomationConsts.DbSchema);
            b.ConfigureByConvention();

            b.HasOne(x => x.Author).WithMany().HasForeignKey(x => x.AuthorId).IsRequired();
            b.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId).IsRequired();

            // 🔥 KRİTİK DÜZELTME: BookId1 oluşmasını engellemek için navigasyon özelliğini (x.Book) bağladık
            b.HasMany(x => x.Images)
                .WithOne(x => x.Book)
                .HasForeignKey(x => x.BookId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        });

        // --- 2. KİTAP RESMİ (BOOK IMAGE) KONFİGÜRASYONU ---
        builder.Entity<BookImage>(b =>
        {
            b.ToTable(BookCafeAutomationConsts.DbTablePrefix + "BookImages", BookCafeAutomationConsts.DbSchema);
            b.ConfigureByConvention();

            b.Property(x => x.FileName).IsRequired().HasMaxLength(255);
            b.Property(x => x.BlobName).IsRequired().HasMaxLength(128);
            b.Property(x => x.MimeType).HasMaxLength(64);
        });

        // --- 3. YAZAR (AUTHOR) ---
        builder.Entity<Author>(b =>
        {
            b.ToTable(BookCafeAutomationConsts.DbTablePrefix + "Authors", BookCafeAutomationConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Name).IsRequired().HasMaxLength(128);
        });

        // --- 4. KATEGORİ (CATEGORY) ---
        builder.Entity<Category>(b =>
        {
            b.ToTable(BookCafeAutomationConsts.DbTablePrefix + "Categories", BookCafeAutomationConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Name).IsRequired().HasMaxLength(128);
        });

        // --- 5. REZERVASYON & AKSİYONLAR ---
        builder.Entity<BookReservation>(b =>
        {
            b.ToTable(BookCafeAutomationConsts.DbTablePrefix + "BookReservations", BookCafeAutomationConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasOne(x => x.Book).WithMany().HasForeignKey(x => x.BookId).IsRequired();
            b.HasOne(x => x.Customer).WithMany().HasForeignKey(x => x.CustomerId).IsRequired();
        });

        builder.Entity<BookAction>(b =>
        {
            b.ToTable(BookCafeAutomationConsts.DbTablePrefix + "BookActions", BookCafeAutomationConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasOne(x => x.Book).WithMany().HasForeignKey(x => x.BookId).IsRequired();
            b.HasOne(x => x.Customer).WithMany().HasForeignKey(x => x.CustomerId).IsRequired();
        });

        builder.Entity<Customer>(b =>
        {
            b.ToTable(BookCafeAutomationConsts.DbTablePrefix + "Customers", BookCafeAutomationConsts.DbSchema);
            b.ConfigureByConvention();
        });

        builder.Entity<BookNote>(b =>
        {
            b.ToTable(BookCafeAutomationConsts.DbTablePrefix + "BookNotes", BookCafeAutomationConsts.DbSchema);
            b.ConfigureByConvention();
        });
    }
}
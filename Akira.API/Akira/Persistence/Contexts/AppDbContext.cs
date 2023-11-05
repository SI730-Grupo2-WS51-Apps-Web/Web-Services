using Microsoft.EntityFrameworkCore;
using Akira.API.Akira.Domain.Models;
using Akira.API.Shared.Extensions;
namespace Akira.API.Akira.Persistence.Contexts;
public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Account>().ToTable("Accounts");
        modelBuilder.Entity<Account>().HasKey(p => p.Id);
        modelBuilder.Entity<Account>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Account>().Property(p => p.Email).IsRequired().HasMaxLength(30);
        modelBuilder.Entity<Account>().Property(p => p.Password).IsRequired().HasMaxLength(30);
        modelBuilder.Entity<Account>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
        modelBuilder.Entity<Account>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
        modelBuilder.Entity<Account>().Property(p => p.Phone).IsRequired();
        modelBuilder.Entity<Account>().Property(p => p.Genre).IsRequired();
        // Relationships
        modelBuilder.Entity<Account>()
            .HasOne(a => a.Department)
            .WithMany()
            .HasForeignKey(a => a.DepartmentId);
        modelBuilder.Entity<Account>()
            .HasOne(a => a.Province)
            .WithMany()
            .HasForeignKey(a => a.ProvinceId);
        modelBuilder.Entity<Account>()
            .HasOne(a => a.District)
            .WithMany()
            .HasForeignKey(a => a.DistrictId);
        modelBuilder.Entity<Account>()
            .HasOne(a => a.Wallet)
            .WithMany()
            .HasForeignKey(a => a.WalletId);
        modelBuilder.Entity<Account>()
            .HasOne(a => a.Card)
            .WithOne()
            .HasForeignKey<Card>(c => c.AccountId)
            .OnDelete(DeleteBehavior.Cascade);

        
        modelBuilder.Entity<Card>().ToTable("Cards");
        modelBuilder.Entity<Card>().HasKey(p => p.Id);
        modelBuilder.Entity<Card>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Card>().Property(p => p.CardNumber).IsRequired().HasMaxLength(20);
        modelBuilder.Entity<Card>().Property(p => p.CardMonthExpiration).IsRequired().HasMaxLength(2);
        modelBuilder.Entity<Card>().Property(p => p.CardYearExpiration).IsRequired().HasMaxLength(2);
        modelBuilder.Entity<Card>().Property(p => p.CardOwner).IsRequired().HasMaxLength(50);
        modelBuilder.Entity<Card>().Property(p => p.CardCVV).IsRequired().HasMaxLength(3);
        modelBuilder.Entity<Card>()
            .HasOne(c => c.Account)
            .WithOne()
            .HasForeignKey<Card>(c => c.AccountId);
        
        
        modelBuilder.Entity<Alliance>().ToTable("Alliances");
        modelBuilder.Entity<Alliance>().HasKey(p => p.Id);
        modelBuilder.Entity<Alliance>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Alliance>().Property(p => p.Url).IsRequired().HasMaxLength(100);
        
        
        modelBuilder.Entity<Category>().ToTable("Category");
        modelBuilder.Entity<Category>().HasKey(p => p.Id);
        modelBuilder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        modelBuilder.Entity<Category>().Property(p => p.Title).HasMaxLength(100);
        modelBuilder.Entity<Category>().Property(p => p.Subtitle).HasMaxLength(255);
        modelBuilder.Entity<Category>()
            .HasOne(c => c.Product)
            .WithOne(p=>p.Category)
            .HasForeignKey<Category>(c => c.ProductId);
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Subcategories)
            .WithOne(s => s.Category)
            .HasForeignKey(s => s.CategoryId);
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);
        
        
        modelBuilder.Entity<Subcategory>().ToTable("Subcategory");
        modelBuilder.Entity<Subcategory>().HasKey(s => s.Id);
        modelBuilder.Entity<Subcategory>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Subcategory>().Property(s => s.Name).IsRequired().HasMaxLength(30);
        modelBuilder.Entity<Subcategory>().Property(s => s.Title).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Subcategory>().Property(p => p.Subtitle).HasMaxLength(255);
        modelBuilder.Entity<Subcategory>()
            .HasMany(s => s.Franchises)
            .WithOne(f => f.Subcategory)
            .HasForeignKey(f => f.SubcategoryId);
        modelBuilder.Entity<Subcategory>()
            .HasOne(s => s.Category)
            .WithMany(c => c.Subcategories)
            .HasForeignKey(s => s.CategoryId);
        modelBuilder.Entity<Subcategory>()
            .HasOne(s => s.Product)
            .WithOne(p=>p.Subcategory)
            .HasForeignKey<Subcategory>(p => p.ProductId);
        
        
        modelBuilder.Entity<Franchise>().ToTable("Franchise");
        modelBuilder.Entity<Franchise>().HasKey(f => f.Id);
        modelBuilder.Entity<Franchise>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Franchise>().Property(f => f.Name).IsRequired().HasMaxLength(30);
        modelBuilder.Entity<Franchise>()
            .HasMany(f => f.Products)
            .WithOne(p => p.Franchise)
            .HasForeignKey(p => p.FranchiseId);
        
        
        modelBuilder.Entity<Wallet>().ToTable("Wallets");
        modelBuilder.Entity<Wallet>().HasKey(p => p.Id);
        modelBuilder.Entity<Wallet>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Wallet>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        
        
        
        // Apply Snake Case Naming Convention
        modelBuilder.UseSnakeCaseNamingConvention();
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Account> Accounts { get; set; }
}
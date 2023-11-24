using Microsoft.EntityFrameworkCore;
using Akira.API.Shared.Extensions;
using Akira.API.Akira.Domain.Models;

namespace Akira.API.Shared.Persistence.Contexts;

public class AppDbContext :DbContext
{

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Alliance> Alliances { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Franchise> Franchises { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderStatus> OrderStatus { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<ProductPerOrder> ProductPerOrders { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<Subcategory> Subcategories { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public AppDbContext(DbContextOptions options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //Tablas que guardan datos cuyos valores no son modificados por los usuarios
        
        builder.Entity<Alliance>().ToTable("Alliances");
        builder.Entity<Alliance>().HasKey(a => a.Id);
        builder.Entity<Alliance>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Alliance>().Property(a => a.Url).IsRequired().HasMaxLength(200);
        
        builder.Entity<Image>().ToTable("Images");
        builder.Entity<Image>().HasKey(a => a.Id);
        builder.Entity<Image>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Image>().Property(a => a.Url).IsRequired().HasMaxLength(200);
        
        builder.Entity<Wallet>().ToTable("Wallets");
        builder.Entity<Wallet>().HasKey(w => w.Id);
        builder.Entity<Wallet>().Property(w => w.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Wallet>().Property(w => w.Max).IsRequired();
        builder.Entity<Wallet>().Property(w => w.Name).IsRequired().HasMaxLength(50);
        
        builder.Entity<Category>().ToTable("Categories");
        builder.Entity<Category>().HasKey(c => c.Id);
        builder.Entity<Category>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Category>().Property(c => c.Title).IsRequired().HasMaxLength(100);
        builder.Entity<Category>().Property(c => c.Subtitle).IsRequired().HasMaxLength(250);
        //Subcategorias
        builder.Entity<Category>()
            .HasMany(c => c.Subcategories)
            .WithOne(s => s.Category)
            .HasForeignKey(s => s.CategoryId)
            .IsRequired();
        //Productos
        builder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId)
            .IsRequired();
        //Producto insignia
        builder.Entity<Category>()
            .HasOne(c => c.Product)
            .WithOne()
            .HasForeignKey<Category>(c => c.ProductId);
        
        builder.Entity<Subcategory>().ToTable("Subcategories");
        builder.Entity<Subcategory>().HasKey(s => s.Id);
        builder.Entity<Subcategory>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Subcategory>().Property(s => s.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Subcategory>().Property(s => s.Title).IsRequired().HasMaxLength(100);
        builder.Entity<Subcategory>().Property(s => s.Subtitle).IsRequired().HasMaxLength(250);
        builder.Entity<Subcategory>().Property(s => s.CategoryId).IsRequired();
        //Franquicias
        builder.Entity<Subcategory>()
            .HasMany(s => s.Franchises)
            .WithOne(f => f.Subcategory)
            .HasForeignKey(f => f.SubcategoryId)
            .IsRequired();
        //Productos
        builder.Entity<Subcategory>()
            .HasMany(s => s.Products)
            .WithOne(p => p.Subcategory)
            .HasForeignKey(p => p.SubcategoryId)
            .IsRequired();
        //Producto Estrella
        builder.Entity<Subcategory>()
            .HasOne(s => s.Product)
            .WithOne()
            .HasForeignKey<Subcategory>(s => s.ProductId);
        
        builder.Entity<Franchise>().ToTable("Franchises");
        builder.Entity<Franchise>().HasKey(f => f.Id);
        builder.Entity<Franchise>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Franchise>().Property(f => f.Name).IsRequired().HasMaxLength(50);
        //Productos
        builder.Entity<Franchise>()
            .HasMany(f => f.Products)
            .WithOne(p => p.Franchise)
            .HasForeignKey(p => p.FranchiseId)
            .IsRequired();
        
        builder.Entity<Product>().ToTable("Products");
        builder.Entity<Product>().HasKey(p => p.Id);
        builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Product>().Property(p => p.Price).IsRequired().HasMaxLength(250);
        // Relación con Category
        builder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .IsRequired();
        // Relación con Subcategory
        builder.Entity<Product>()
            .HasOne(p => p.Subcategory)
            .WithMany(s => s.Products)
            .HasForeignKey(p => p.SubcategoryId)
            .IsRequired();
        // Relación con Franchise
        builder.Entity<Product>()
            .HasOne(p => p.Franchise)
            .WithMany(f => f.Products)
            .HasForeignKey(p => p.FranchiseId)
            .IsRequired();
        
        //Tablas controladas por los usuarios:
        
        builder.Entity<Account>().ToTable("Accounts");
        builder.Entity<Account>().HasKey(a => a.Id);
        builder.Entity<Account>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Account>().Property(a => a.Email).IsRequired().HasMaxLength(50);
        builder.Entity<Account>().Property(a => a.Password).IsRequired().HasMaxLength(50);
        builder.Entity<Account>().Property(a => a.FirstName).IsRequired().HasMaxLength(50);
        builder.Entity<Account>().Property(a => a.LastName).IsRequired().HasMaxLength(50);
        builder.Entity<Account>().Property(a => a.Phone).IsRequired().HasMaxLength(9);
        builder.Entity<Account>().Property(a => a.Genre).IsRequired();
        builder.Entity<Account>().Property(a => a.Address).IsRequired().HasMaxLength(50);
        //Relacion de una tarjeta a un usuario
        builder.Entity<Account>()
            .HasOne(a => a.Card)
            .WithOne(c => c.Account)
            .HasForeignKey<Card>(c => c.AccountId)
            .OnDelete(DeleteBehavior.Cascade);
        //Relacion al departamento, provincia y distrito de la direccion del usuario
        builder.Entity<Account>()
            .HasOne(a => a.Department)
            .WithOne()
            .HasForeignKey<Account>(a => a.DepartmentId);
        builder.Entity<Account>()
            .HasOne(a => a.District)
            .WithOne()
            .HasForeignKey<Account>(a => a.DistrictId);
        builder.Entity<Account>()
            .HasOne(a => a.Province)
            .WithOne()
            .HasForeignKey<Account>(a => a.ProvinceId);
        //Relacion al tipo de billetera digital que el usuario tiene asociada
        builder.Entity<Account>()
            .HasOne(a => a.Wallet)
            .WithOne()
            .HasForeignKey<Account>(a => a.WalletId);
        //Relacion al tipo de pago
        builder.Entity<Account>()
            .HasOne(a => a.PaymentMethod)
            .WithOne()
            .HasForeignKey<Account>(a => a.SelectedPaymentMethod);
        //Imagen de perfil del usuario
        builder.Entity<Account>()
            .HasOne(a => a.ImageName)
            .WithOne()
            .HasForeignKey<Account>(a => a.ImageId);
        //Relacion con el carrito
        builder.Entity<Account>()
            .HasOne(a => a.Cart)
            .WithOne()
            .HasForeignKey<Order>(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        //Datos de las ordenes
        builder.Entity<Account>()
            .HasMany(a => a.OrdersData)
            .WithOne(o => o.Account)
            .HasForeignKey(o => o.UserId);
        builder.Entity<Account>().Ignore(a => a.Orders);
        
        builder.Entity<Card>().ToTable("UserCreditCards");
        builder.Entity<Card>().HasKey(c => c.Id);
        builder.Entity<Card>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Card>().Property(c => c.CardNumber).IsRequired().HasMaxLength(16);
        builder.Entity<Card>().Property(c => c.CardOwner).IsRequired().HasMaxLength(50);
        builder.Entity<Card>().Property(c => c.CardMonthExpiration).IsRequired().HasMaxLength(2);
        builder.Entity<Card>().Property(c => c.CardYearExpiration).IsRequired().HasMaxLength(2);
        builder.Entity<Card>().Property(c => c.CardCVV).IsRequired().HasMaxLength(3);
        builder.Entity<Card>().Property(c => c.AccountId).IsRequired();
        
        
        builder.Entity<ProductPerOrder>().ToTable("ProductsPerOrder");
        builder.Entity<ProductPerOrder>().HasKey(ppo => new { ppo.ProductId, ppo.OrderId });
        // Relación con Product
        builder.Entity<ProductPerOrder>()
            .HasOne(ppo => ppo.Product)
            .WithMany()
            .HasForeignKey(ppo => ppo.ProductId)
            .IsRequired();
        // Relación con Order
        builder.Entity<ProductPerOrder>()
            .HasOne(ppo => ppo.Order)
            .WithMany(o => o.ProductPerOrders)
            .HasForeignKey(ppo => ppo.OrderId)
            .IsRequired();
        
        
        builder.Entity<Order>().ToTable("Orders");
        builder.Entity<Order>().HasKey(o => o.Id);
        // Relación con Account (User)
        builder.Entity<Order>()
            .HasOne(o => o.Account)
            .WithMany()
            .HasForeignKey(o => o.UserId)
            .IsRequired();
        // Relación con District
        builder.Entity<Order>()
            .HasOne(o => o.District)
            .WithMany()
            .HasForeignKey(o => o.DistrictId);
        // Relación con Province
        builder.Entity<Order>()
            .HasOne(o => o.Province)
            .WithMany()
            .HasForeignKey(o => o.ProvinceId);
        // Relación con Department
        builder.Entity<Order>()
            .HasOne(o => o.Department)
            .WithMany()
            .HasForeignKey(o => o.DepartmentId);
        // Relación con PaymentMethod
        builder.Entity<Order>()
            .HasOne(o => o.PaymentMethod)
            .WithMany()
            .HasForeignKey(o => o.SelectedMethod)
            .IsRequired();
        // Relación con OrderStatus
        builder.Entity<Order>()
            .HasOne(o => o.Status)
            .WithMany()
            .HasForeignKey(o => o.StatusId)
            .IsRequired();
        // Relación con ProductPerOrder
        builder.Entity<Order>()
            .HasMany(o => o.ProductPerOrders)
            .WithOne(ppo => ppo.Order)
            .HasForeignKey(ppo => ppo.OrderId)
            .IsRequired();
        
        // Apply Snake Case Naming Convention
        builder.UseSnakeCaseNamingConvention();
    }
}
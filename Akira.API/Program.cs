using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services;
using Akira.API.Akira.Services;
using Akira.API.Akira.Domain.Repositories;
using Akira.API.Akira.Mapping;
using Akira.API.Akira.Persistence.Repositories;
using Akira.API.Shared.Persistence.Contexts;
using Akira.API.Shared.Persistence.Repositories;
using si730pc2u202110062.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

// Add lowercase routes
builder.Services.AddRouting(options => options.LowercaseUrls = true);




/////////////////////////////////////////////////////////////////////
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IImageService, ImageService>();
/////////////////////////////////////////////////////////////////////
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
/////////////////////////////////////////////////////////////////////
builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<ICardService, CardService>();
/////////////////////////////////////////////////////////////////////
builder.Services.AddScoped<IAllianceRepository, AllianceRepository>();
builder.Services.AddScoped<IAllianceService, AllianceService>();
/////////////////////////////////////////////////////////////////////
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
/////////////////////////////////////////////////////////////////////
builder.Services.AddScoped<IDepartmentRepository, DepartmentsRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
/////////////////////////////////////////////////////////////////////
builder.Services.AddScoped<IDistrictRepository, DistrictsRepository>();
builder.Services.AddScoped<IDistrictService, DistrictService>();
/////////////////////////////////////////////////////////////////////
builder.Services.AddScoped<IFranchiseRepository, FranchiseRepository>();
builder.Services.AddScoped<IFranchiseService, FranchiseService>();
/////////////////////////////////////////////////////////////////////
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IImageService, ImageService>();
/////////////////////////////////////////////////////////////////////
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
/////////////////////////////////////////////////////////////////////
builder.Services.AddScoped<IProvinceRepository, ProvincesRepository>();
builder.Services.AddScoped<IProvinceService, ProvinceService>();
/////////////////////////////////////////////////////////////////////
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
/////////////////////////////////////////////////////////////////////




builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile), 
    typeof(ResourceToModelProfile));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
using AutoMapper;
using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Resources;
namespace Akira.API.Akira.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Account, AccountResource>();
        CreateMap<Alliance, AllianceResource>();
        CreateMap<Category, CategoryResource>();
        CreateMap<Department, DepartmentResource>();
        CreateMap<District, DistrictResource>();
        CreateMap<Franchise, FranchiseResource>();
        CreateMap<Order, OrderResource>();
        CreateMap<OrderStatus, OrderStatusResource>();
        CreateMap<PaymentMethod, PaymentMethodResource>();
        CreateMap<Product, ProductResource>();
        CreateMap<ProductImage, ProductImageResource>();
        CreateMap<ProductPerOrder, ProductPerOrderResource>();
        CreateMap<Province, ProvinceResource>();
        CreateMap<Subcategory, SubcategoryResource>();
        CreateMap<Wallet, WalletResource>();
        CreateMap<Card, CardResource>();
    }
}

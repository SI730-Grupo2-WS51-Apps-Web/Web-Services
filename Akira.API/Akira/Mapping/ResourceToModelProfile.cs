using AutoMapper;
using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Resources;
namespace Akira.API.Akira.Mapping;

public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<AccountResource, Account>();
        CreateMap<AllianceResource, Alliance>();
        CreateMap<CategoryResource, Category>();
        CreateMap<DepartmentResource, Department>();
        CreateMap<DistrictResource, District>();
        CreateMap<FranchiseResource, Franchise>();
        CreateMap<OrderResource, Order>();
        CreateMap<OrderStatusResource, OrderStatus>();
        CreateMap<PaymentMethodResource, PaymentMethod>();
        CreateMap<ProductResource, Product>();
        CreateMap<ProductImageResource, ProductImage>();
        CreateMap<ProductPerOrderResource, ProductPerOrder>();
        CreateMap<ProvinceResource, Province>();
        CreateMap<SubcategoryResource, Subcategory>();
        CreateMap<WalletResource, Wallet>();
        CreateMap<CardResource, Card>();
    }
}
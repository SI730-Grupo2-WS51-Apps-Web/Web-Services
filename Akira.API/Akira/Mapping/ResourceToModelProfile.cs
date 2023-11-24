using AutoMapper;
using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Resources;
namespace Akira.API.Akira.Mapping;

public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<AccountResource, Account>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Personal.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Personal.LastName))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Personal.Phone))
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Personal.Genre))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Login.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Login.Password))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Shipping.Address))
            .ForMember(dest => dest.DistrictId, opt => opt.MapFrom(src => src.Shipping.DistrictId))
            .ForMember(dest => dest.ProvinceId, opt => opt.MapFrom(src => src.Shipping.ProvinceId))
            .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.Shipping.DepartmentId))
            .ForMember(dest => dest.CartId, opt => opt.MapFrom(src => src.Shop.CartId))
            .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Shop.Orders));
        CreateMap<AllianceResource, Alliance>();
        CreateMap<CategoryResource, Category>();
        CreateMap<DepartmentResource, Department>();
        CreateMap<DistrictResource, District>();
        CreateMap<FranchiseResource, Franchise>();
        CreateMap<ImageResource, Image>();
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
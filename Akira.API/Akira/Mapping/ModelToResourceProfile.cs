using AutoMapper;
using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Responses;
namespace Akira.API.Akira.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Account, AccountResponse>()
            .ForMember(dest => dest.Personal, opt => opt.MapFrom(src => new Personal
            {
                FirstName = src.FirstName,
                LastName = src.LastName,
                Phone = src.Phone,
                Genre = src.Genre
            }))
            .ForMember(dest => dest.Login, opt => opt.MapFrom(src => new Login
            {
                Email = src.Email,
                Password = src.Password
            }))
            .ForMember(dest => dest.Shipping, opt => opt.MapFrom(src => new Shipping
            {
                Address = src.Address,
                DistrictId = src.DistrictId,
                District = src.District,
                ProvinceId = src.ProvinceId,
                Province = src.Province,
                DepartmentId = src.DepartmentId,
                Department = src.Department
            }))
            .ForMember(dest => dest.Shop, opt => opt.MapFrom(src => new Shop
            {
                CartId = src.CartId,
                Cart = src.Cart,
                Orders = src.Orders,
                OrdersData = src.OrdersData
            }));
        CreateMap<Alliance, AllianceResponse>();
        CreateMap<Category, CategoryResponse>();
        CreateMap<Department, DepartmentResponse>();
        CreateMap<District, DistrictResponse>();
        CreateMap<Franchise, FranchiseResponse>();
        CreateMap<Image, ImageResponse>();
        CreateMap<Order, OrderResponse>();
        CreateMap<OrderStatus, OrderStatusResponse>();
        CreateMap<PaymentMethod, PaymentMethodResponse>();
        CreateMap<Product, ProductResponse>();
        CreateMap<ProductImage, ProductImageResponse>();
        CreateMap<ProductPerOrder, ProductPerOrderResponse>();
        CreateMap<Province, ProvinceResponse>();
        CreateMap<Subcategory, SubcategoryResponse>();
        CreateMap<Wallet, WalletResponse>();
        CreateMap<Card, CardResponse>();
    }
}

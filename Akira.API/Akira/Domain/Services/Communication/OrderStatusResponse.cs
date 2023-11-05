using Akira.API.Akira.Domain.Models;
using Akira.API.Shared.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services.Communication;

public class OrderStatusResponse: BaseResponse<OrderStatus>
{
    public OrderStatusResponse(string message) : base(message)
    {
     
    }
    
    public OrderStatusResponse(OrderStatus resource) : base(resource)
    {
     
    }
}

using Akira.API.Akira.Domain.Models;
using Akira.API.Shared.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services.Communication;

public class OrderResponse: BaseResponse<Order>
{
    public OrderResponse(string message) : base(message)
    {
     
    }
    
    public OrderResponse(Order resource) : base(resource)
    {
     
    }
}

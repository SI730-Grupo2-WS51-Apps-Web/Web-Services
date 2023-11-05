using Akira.API.Akira.Domain.Models;
using Akira.API.Shared.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services.Communication;

public class ProductPerOrderResponse: BaseResponse<ProductPerOrder>
{
    public ProductPerOrderResponse(string message) : base(message)
    {
     
    }
    
    public ProductPerOrderResponse(ProductPerOrder resource) : base(resource)
    {
     
    }
}

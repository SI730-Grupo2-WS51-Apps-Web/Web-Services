using Akira.API.Akira.Domain.Models;
using Akira.API.Shared.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services.Communication;

public class ProductResponse: BaseResponse<Product>
{
    public ProductResponse(string message) : base(message)
    {
     
    }
    
    public ProductResponse(Product resource) : base(resource)
    {
     
    }
}

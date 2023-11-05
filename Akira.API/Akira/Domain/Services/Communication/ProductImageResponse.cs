using Akira.API.Akira.Domain.Models;
using Akira.API.Shared.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services.Communication;

public class ProductImageResponse: BaseResponse<ProductImage>
{
    public ProductImageResponse(string message) : base(message)
    {
     
    }
    
    public ProductImageResponse(ProductImage resource) : base(resource)
    {
     
    }
}

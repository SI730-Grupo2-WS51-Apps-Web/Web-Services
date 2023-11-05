using Akira.API.Akira.Domain.Models;
using Akira.API.Shared.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services.Communication;

public class SubcategoryResponse: BaseResponse<Subcategory>
{
    public SubcategoryResponse(string message) : base(message)
    {
     
    }
    
    public SubcategoryResponse(Subcategory resource) : base(resource)
    {
     
    }
}

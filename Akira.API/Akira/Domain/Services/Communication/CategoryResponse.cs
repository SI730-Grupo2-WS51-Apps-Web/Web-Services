using Akira.API.Akira.Domain.Models;
using Akira.API.Shared.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services.Communication;

public class CategoryResponse: BaseResponse<Category>
{
    public CategoryResponse(string message) : base(message)
    {
     
    }
    
    public CategoryResponse(Category resource) : base(resource)
    {
     
    }
}

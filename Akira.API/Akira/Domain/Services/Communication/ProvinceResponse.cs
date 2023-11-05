using Akira.API.Akira.Domain.Models;
using Akira.API.Shared.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services.Communication;

public class ProvinceResponse: BaseResponse<Province>
{
    public ProvinceResponse(string message) : base(message)
    {
     
    }
    
    public ProvinceResponse(Province resource) : base(resource)
    {
     
    }
}

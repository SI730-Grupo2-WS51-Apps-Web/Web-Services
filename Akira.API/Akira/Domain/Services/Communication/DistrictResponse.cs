using Akira.API.Akira.Domain.Models;
using Akira.API.Shared.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services.Communication;

public class DistrictResponse: BaseResponse<District>
{
    public DistrictResponse(string message) : base(message)
    {
     
    }
    
    public DistrictResponse(District resource) : base(resource)
    {
     
    }
}

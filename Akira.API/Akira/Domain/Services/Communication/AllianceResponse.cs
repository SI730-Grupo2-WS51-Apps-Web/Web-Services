using Akira.API.Akira.Domain.Models;
using Akira.API.Shared.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services.Communication;

public class AllianceResponse: BaseResponse<Alliance>
{
    public AllianceResponse(string message) : base(message)
    {
        
    }
    
    public AllianceResponse(Alliance resource) : base(resource)
    {
        
    }
}

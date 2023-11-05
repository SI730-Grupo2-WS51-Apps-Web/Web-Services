using Akira.API.Akira.Domain.Models;
using Akira.API.Shared.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services.Communication;

public class FranchiseResponse: BaseResponse<Franchise>
{
    public FranchiseResponse(string message) : base(message)
    {
     
    }
    
    public FranchiseResponse(Franchise resource) : base(resource)
    {
     
    }
}

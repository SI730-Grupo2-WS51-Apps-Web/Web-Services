using Akira.API.Akira.Domain.Models;
using Akira.API.Shared.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services.Communication;

public class WalletResponse: BaseResponse<Wallet>
{
    public WalletResponse(string message) : base(message)
    {
     
    }
    
    public WalletResponse(Wallet resource) : base(resource)
    {
     
    }
}

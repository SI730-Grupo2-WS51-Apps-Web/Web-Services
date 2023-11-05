using Akira.API.Akira.Domain.Models;
using Akira.API.Shared.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services.Communication;

public class AccountResponse: BaseResponse<Account>
{
    public AccountResponse(string message) : base(message)
    {
     
    }
    
    public AccountResponse(Account resource) : base(resource)
    {
     
    }
}

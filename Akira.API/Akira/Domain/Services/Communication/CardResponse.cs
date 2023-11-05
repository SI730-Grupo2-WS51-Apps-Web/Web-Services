using Akira.API.Akira.Domain.Models;
using Akira.API.Shared.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services.Communication;

public class CardResponse: BaseResponse<Card>
{
    public CardResponse(string message) : base(message)
    {
        
    }
    
    public CardResponse(Card resource) : base(resource)
    {
        
    }
}

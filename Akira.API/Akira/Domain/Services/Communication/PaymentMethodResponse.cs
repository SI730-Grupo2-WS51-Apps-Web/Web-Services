using Akira.API.Akira.Domain.Models;
using Akira.API.Shared.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services.Communication;

public class PaymentMethodResponse: BaseResponse<PaymentMethod>
{
    public PaymentMethodResponse(string message) : base(message)
    {
     
    }
    
    public PaymentMethodResponse(PaymentMethod resource) : base(resource)
    {
     
    }
}

using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services.Communication;

namespace Akira.API.Akira.Domain.Services;

public interface IPaymentMethodService
{
    Task<IEnumerable<PaymentMethod>> ListAsync();
    Task<PaymentMethod> GetPaymentMethodByIdAsync(int id);

    Task<PaymentMethodResponse> SaveAsync(PaymentMethod paymentmethod);
    Task<PaymentMethodResponse> UpdateAsync(int id, PaymentMethod paymentmethod);
    Task<PaymentMethodResponse> DeleteAsync(int id);
}


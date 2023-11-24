using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Domain.Repositories;

public interface IPaymentMethodRepository
{
    Task<IEnumerable<PaymentMethod>> ListAsync();
    Task AddAsync(PaymentMethod paymentMethod);
    Task<PaymentMethod> FindByIdAsync(int id);
}
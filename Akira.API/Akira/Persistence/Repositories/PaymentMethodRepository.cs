using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Repositories;
using Akira.API.Akira.Domain.Services;
using Akira.API.Shared.Persistence.Contexts;
using Akira.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Akira.API.Akira.Persistence.Repositories;

public class PaymentMethodRepository: BaseRepository, IPaymentMethodRepository
{
    public PaymentMethodRepository(AppDbContext context) : base(context) {}
    public async Task<IEnumerable<PaymentMethod>> ListAsync()
    {
        return await _context.PaymentMethods.ToListAsync();
    }

    public async Task AddAsync(PaymentMethod paymentMethod)
    {
        await _context.PaymentMethods.AddAsync(paymentMethod);
    }

    public async Task<PaymentMethod> FindByIdAsync(int id)
    {
        return await _context.PaymentMethods.FindAsync(id);
    }
}
using Microsoft.EntityFrameworkCore;
using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Repositories;
using Akira.API.Akira.Domain.Services;
using Akira.API.Akira.Domain.Services.Communication;

namespace Akira.API.Akira.Services;

/// <remarks>
/// This class was developed by Marcelo Scerpella
/// </remarks>
/// <summary>
/// This is the implementation of the interface IEventService, which contains the
/// methods that will be used to perform actions in the API. In this case, the
/// only method that is implemented is how to create a Event
/// </summary>
public partial class FranchiseService: IFranchiseService
{
    private readonly IFranchiseRepository _franchiseRepository;
    private readonly IUnitOfWork _unitOfWork;
    /// <summary>
    /// Constructor of the class. It requests for an event repository, and the unit of work implementation
    /// </summary>
    /// <param name="franchiseRepository">Repository of the events to work with in the future</param>
    /// <param name="unitOfWork">Default unit of work implementation to work with in the future</param>
    public FranchiseService(IFranchiseRepository franchiseRepository, IUnitOfWork unitOfWork)
    {
        _franchiseRepository = franchiseRepository;
        _unitOfWork = unitOfWork;
    } 
    public async Task<IEnumerable<Franchise>> ListAsync()
    {
        var franchises = await _franchiseRepository.ListAsync();
        return franchises;
    }

    public Task<FranchiseResponse> SaveAsync(Franchise franchise)
    {
        throw new NotImplementedException();
    }
    
    public async  Task<Franchise> GetFranchiseByIdAsync(int id)
    {
        var franchise = await _franchiseRepository.FindByIdAsync(id);
        return franchise;
    }
}
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
public class DistrictService: IDistrictService
{
    private readonly IDistrictRepository _districtRepository;
    private readonly IUnitOfWork _unitOfWork;
    /// <summary>
    /// Constructor of the class. It requests for an event repository, and the unit of work implementation
    /// </summary>
    /// <param name="districtRepository">Repository of the events to work with in the future</param>
    /// <param name="unitOfWork">Default unit of work implementation to work with in the future</param>
    public DistrictService(IDistrictRepository districtRepository, IUnitOfWork unitOfWork)
    {
        _districtRepository = districtRepository;
        _unitOfWork = unitOfWork;
    } 
    public async Task<IEnumerable<District>> ListAsync()
    {
        var districts = await _districtRepository.ListAsync();
        return districts;
    }

    public Task<DistrictResponse> SaveAsync(District district)
    {
        throw new NotImplementedException();
    }
    
    public async  Task<District> GetDistrictByIdAsync(int id)
    {
        var district = await _districtRepository.FindByIdAsync(id);
        return district;
    }
}
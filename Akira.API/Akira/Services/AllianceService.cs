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
public class AllianceService: IAllianceService
{
    private readonly IAllianceRepository _allianceRepository;
    private readonly IUnitOfWork _unitOfWork;
    /// <summary>
    /// Constructor of the class. It requests for an event repository, and the unit of work implementation
    /// </summary>
    /// <param name="allianceRepository">Repository of the events to work with in the future</param>
    /// <param name="unitOfWork">Default unit of work implementation to work with in the future</param>
    public AllianceService(IAllianceRepository allianceRepository, IUnitOfWork unitOfWork)
    {
        _allianceRepository = allianceRepository;
        _unitOfWork = unitOfWork;
    } 
    public async Task<IEnumerable<Alliance>> ListAsync()
    {
        var alliances = await _allianceRepository.ListAsync();
        return alliances;
    }

    public async  Task<Alliance> GetAllianceByIdAsync(int id)
    {
        var alliance = await _allianceRepository.FindByIdAsync(id);
        return alliance;
    }
}
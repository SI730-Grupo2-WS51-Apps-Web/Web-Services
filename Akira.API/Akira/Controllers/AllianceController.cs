using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services;
using Akira.API.Akira.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
namespace Akira.API.Akira.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class AllianceController: ControllerBase
{
    
    private readonly IAllianceService _allianceService;
    private readonly IMapper _mapper;
    public AllianceController(IAllianceService allianceService, IMapper mapper)
    {
        _allianceService = allianceService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<AllianceResource>> GetAllAsync()
    {
        var alliances = await _allianceService.ListAsync();
        //Convierte alliance en AllianceResponse
        var resources = _mapper.Map<IEnumerable<Alliance>, IEnumerable<AllianceResource>>(alliances);
        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<AllianceResource>> GetAllianceById(int id)
    {
        var alliance = await _allianceService.GetAllianceByIdAsync(id);
        
        if (alliance is null)
        {
            return NotFound();
        }

        var allianceResource = _mapper.Map<Alliance, AllianceResource>(alliance);
        
        return allianceResource;
    }
    
  
    
    
    
}
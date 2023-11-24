using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services;
using Akira.API.Akira.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Akira.API.Akira.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class DistrictController: ControllerBase
{
    private readonly IDistrictService _districtService;
    private readonly IMapper _mapper;

    public DistrictController(IDistrictService districtService, IMapper mapper)
    {
        _districtService = districtService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<DistrictResource>> GetAllAsync()
    {
        var districts = await _districtService.ListAsync();
    
        var resources = _mapper.Map<IEnumerable<District>, IEnumerable<DistrictResource>>(districts);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DistrictResource resource) 
    {
        var district = _mapper.Map<DistrictResource, District>(resource);

        var response = await _districtService.SaveAsync(district);

        if (!response.Success)
            return BadRequest(response);
      
        return Ok(response);
    }
}
using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services;
using Akira.API.Akira.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Akira.API.Akira.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ProvinceController: ControllerBase
{
    private readonly IProvinceService _provinceService;
    private readonly IMapper _mapper;

    public ProvinceController(IProvinceService provinceService, IMapper mapper)
    {
        _provinceService = provinceService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ProvinceResource>> GetAllAsync()
    {
        var provinces = await _provinceService.ListAsync();
    
        var resources = _mapper.Map<IEnumerable<Province>, IEnumerable<ProvinceResource>>(provinces);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProvinceResource resource) 
    {
        var province = _mapper.Map<ProvinceResource, Province>(resource);

        var response = await _provinceService.SaveAsync(province);

        if (!response.Success)
            return BadRequest(response);
      
        return Ok(response);
    }
}
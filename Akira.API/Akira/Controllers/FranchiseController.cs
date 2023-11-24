using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services;
using Akira.API.Akira.Domain.Services.Communication;
using Akira.API.Akira.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Akira.API.Akira.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class FranchiseController: ControllerBase
{
    private readonly IFranchiseService _franchiseService;
    private readonly IMapper _mapper;

    public FranchiseController(IFranchiseService franchiseService, IMapper mapper)  
    {
        _franchiseService = franchiseService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<FranchiseResponse>> GetAllAsync()
    {
        var categories = await _franchiseService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Franchise>, IEnumerable<FranchiseResponse>>(categories);
        return resources; 
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FranchiseResponse>> GetById(int id) 
    {
        var categories = await _franchiseService.ListAsync();

        var matchingFranchise = categories.FirstOrDefault(p => p.Id == id);

        if(matchingFranchise == null)
            return NotFound();

        var resource = _mapper.Map<Franchise, FranchiseResponse>(matchingFranchise);

        return resource;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]FranchiseResource resource) 
    {
        var product = _mapper.Map<FranchiseResource, Franchise>(resource);
        var response = await _franchiseService.SaveAsync(product);

        if (!response.Success)
            return BadRequest(response);
      
        return Ok(response);
    }

}
using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services;
using Akira.API.Akira.Domain.Services.Communication;
using Akira.API.Akira.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Akira.API.Akira.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class SubcategoryController: ControllerBase
{
    private readonly ISubcategoryService _subcategoryService;
    private readonly IMapper _mapper;

    public SubcategoryController(ISubcategoryService subcategoryService, IMapper mapper)  
    {
        _subcategoryService = subcategoryService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<SubcategoryResponse>> GetAllAsync()
    {
        var categories = await _subcategoryService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Subcategory>, IEnumerable<SubcategoryResponse>>(categories);
        return resources; 
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SubcategoryResponse>> GetById(int id) 
    {
        var categories = await _subcategoryService.ListAsync();

        var matchingSubcategory = categories.FirstOrDefault(p => p.Id == id);

        if(matchingSubcategory == null)
            return NotFound();

        var resource = _mapper.Map<Subcategory, SubcategoryResponse>(matchingSubcategory);

        return resource;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]SubcategoryResource resource) 
    {
        var product = _mapper.Map<SubcategoryResource, Subcategory>(resource);
        var response = await _subcategoryService.SaveAsync(product);

        if (!response.Success)
            return BadRequest(response);
      
        return Ok(response);
    }

}
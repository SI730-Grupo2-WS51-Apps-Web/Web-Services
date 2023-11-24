using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services;
using Akira.API.Akira.Domain.Services.Communication;
using Akira.API.Akira.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Akira.API.Akira.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class CategoryController: ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryService categoryService, IMapper mapper)  
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<CategoryResponse>> GetAllAsync()
    {
        var categories = await _categoryService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResponse>>(categories);
        return resources; 
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryResponse>> GetById(int id) 
    {
        var categories = await _categoryService.ListAsync();

        var matchingCategory = categories.FirstOrDefault(p => p.Id == id);

        if(matchingCategory == null)
            return NotFound();

        var resource = _mapper.Map<Category, CategoryResponse>(matchingCategory);

        return resource;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CategoryResource resource) 
    {
        var product = _mapper.Map<CategoryResource, Category>(resource);
        var response = await _categoryService.SaveAsync(product);

        if (!response.Success)
            return BadRequest(response);
      
        return Ok(response);
    }

}
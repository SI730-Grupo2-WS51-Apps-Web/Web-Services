using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services;
using Akira.API.Akira.Resources;
using Akira.API.Akira.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Akira.API.Akira.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class DepartmentController: ControllerBase
{
    private readonly IDepartmentService _departmentService;
    private readonly IMapper _mapper;

    public DepartmentController(IDepartmentService departmentService, IMapper mapper)
    {
        _departmentService = departmentService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<DepartmentResponse>> GetAllAsync()
    {
        var departments = await _departmentService.ListAsync();
    
        var resources = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentResponse>>(departments);

        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<DepartmentResponse>> GetAllianceById(int id)
    {
        var department = await _departmentService.GetDepartmentByIdAsync(id);
        
        if (department is null)
        {
            return NotFound();
        }

        var departmentResponse = _mapper.Map<Department, DepartmentResponse>(department);
        
        return departmentResponse;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DepartmentResource resource) 
    {
        var department = _mapper.Map<DepartmentResource, Department>(resource);

        var response = await _departmentService.SaveAsync(department);

        if (!response.Success)
            return BadRequest(response);
      
        return Ok(response);
    }
}
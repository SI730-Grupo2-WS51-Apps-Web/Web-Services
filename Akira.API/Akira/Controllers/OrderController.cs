using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services;
using Akira.API.Akira.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Akira.API.Akira.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class OrderController: ControllerBase
{
    
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;
    public OrderController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<OrderResource>> GetAllAsync()
    {
        var orders = await _orderService.ListAsync();
        //Convierte order en OrderResource
        var resources = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderResource>>(orders);
        return resources;
    }
    
    
}
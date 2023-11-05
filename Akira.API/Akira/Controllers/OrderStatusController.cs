using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services;
using Akira.API.Akira.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Akira.API.Akira.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class OrderStatusController: ControllerBase
{
    private readonly IOrderStatusService _orderStatusService;
    private readonly IMapper _mapper;
    public OrderStatusController(IOrderStatusService orderStatusService, IMapper mapper)
    {
        _orderStatusService = orderStatusService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<OrderStatusResource>> GetAllAsync()
    {
        var orderstatus = await _orderStatusService.ListAsync();
        //Convierte account en AccountResource
        var resources = _mapper.Map<IEnumerable<OrderStatus>, IEnumerable<OrderStatusResource>>(orderstatus);
        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<OrderStatusResource>> GetAccountById(int id)
    {
        var orderStatus = await _orderStatusService.GetOrderStatusByIdAsync(id);
        
        if (orderStatus is null)
        {
            return NotFound();
        }

        var orderstatusResource = _mapper.Map<OrderStatus, OrderStatusResource>(orderStatus);
        return orderstatusResource;
    }
    
    
    
}
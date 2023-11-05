using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services;
using Akira.API.Akira.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Akira.API.Akira.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class PaymentMethodController: ControllerBase
{
    private readonly IPaymentMethodService _paymentMethodService;
    private readonly IMapper _mapper;
    public PaymentMethodController(IPaymentMethodService paymentMethodService, IMapper mapper)
    {
        _paymentMethodService = paymentMethodService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<PaymentMethodResource>> GetAllAsync()
    {
        var paymentmethod = await _paymentMethodService.ListAsync();
        //Convierte account en AccountResource
        var resources = _mapper.Map<IEnumerable<PaymentMethod>, IEnumerable<PaymentMethodResource>>(paymentmethod);
        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<PaymentMethodResource>> GetPaymentMethodById(int id)
    {
        var paymentMethod = await _paymentMethodService.GetPaymentMethodByIdAsync(id);
        
        if (paymentMethod is null)
        {
            return NotFound();
        }

        var paymentmethodsResource = _mapper.Map<PaymentMethod, PaymentMethodResource>(paymentMethod);
        return paymentmethodsResource;
    }
    
    
}
using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services;
using Akira.API.Akira.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Akira.API.Akira.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class WalletController: ControllerBase
{
    private readonly IWalletService _walletService;
    private readonly IMapper _mapper;

    public WalletController(IWalletService walletService, IMapper mapper)
    {
        _walletService = walletService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<WalletResource>> GetAllAsync()
    {
        var wallets = await _walletService.ListAsync();
    
        var resources = _mapper.Map<IEnumerable<Wallet>, IEnumerable<WalletResource>>(wallets);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]WalletResource resource) 
    {
        var wallet = _mapper.Map<WalletResource, Wallet>(resource);

        var response = await _walletService.SaveAsync(wallet);

        if (!response.Success)
            return BadRequest(response);
      
        return Ok(response);
    }
}
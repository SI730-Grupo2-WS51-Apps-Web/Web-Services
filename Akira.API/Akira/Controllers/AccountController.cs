using AutoMapper;
using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services;
using Akira.API.Akira.Resources;
using Microsoft.AspNetCore.Mvc;
namespace Akira.API.Akira.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class AccountController: ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly IMapper _mapper;
    public AccountController(IAccountService accountService, IMapper mapper)
    {
        _accountService = accountService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<AccountResource>> GetAllAsync()
    {
        var accounts = await _accountService.ListAsync();
        //Convierte account en AccountResource
        var resources = _mapper.Map<IEnumerable<Account>, IEnumerable<AccountResource>>(accounts);
        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<AccountResource>> GetAccountById(int id)
    {
        var account = await _accountService.GetAccountByIdAsync(id);
        
        if (account is null)
        {
            return NotFound();
        }

        var accountResource = _mapper.Map<Account, AccountResource>(account);
        return accountResource;
    }
    
    [HttpGet("Login")]
    public async Task<ActionResult<AccountResource>> LoginAccount([FromQuery] string email, [FromQuery] string password)
    {
        var account = await _accountService.GetAccountByCredentialsAsync(email, password);
        if (account is null)
        {
            return NotFound();
        }
        var accountResource = _mapper.Map<Account, AccountResource>(account);
        return accountResource;
    }
    
    [HttpGet("Email")]
    public async Task<ActionResult<AccountResource>> GetAccountByEmail([FromQuery] string email)
    {
        var account = await _accountService.GetAccountByEmailAsync(email);
    
        if (account is null)
        {
            return NotFound();
        }

        var accountResource = _mapper.Map<Account, AccountResource>(account);

        return accountResource;
    }
    
    [HttpGet("getSorted")]
    public async Task<ActionResult<IEnumerable<AccountResource>>> GetUsers(
        [FromQuery(Name = "_sort")] string sortBy,
        [FromQuery(Name = "_order")] string sortOrder)
    {
        // Verifica si los parámetros _sort y _order son válidos
        if (sortBy != "id" || (sortOrder != "asc" && sortOrder != "desc"))
        {
            return BadRequest("Parámetros de orden no válidos.");
        }

        var order = (sortOrder == "asc");

        // Realiza la consulta y ordena los resultados por ID en orden ascendente o descendente
        var accounts = await _accountService.GetUsersSortedAsync(sortBy, order);

        var accountResources = _mapper.Map<IEnumerable<Account>, IEnumerable<AccountResource>>(accounts);

        return Ok(accountResources);
    }
    
    [HttpPost("users")]
    public async Task<ActionResult<AccountResource>> CreateUser([FromBody] AccountResource accountCreateRequest)
    {
        // Validar y crear una nueva cuenta
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var account = _mapper.Map<AccountResource, Account>(accountCreateRequest);

        var result = await _accountService.SaveAsync(account);

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        var accountResource = _mapper.Map<Account, AccountResource>(result.Resource);

        return CreatedAtAction(nameof(GetAccountById), new { id = accountResource.Id }, accountResource);
    }
}
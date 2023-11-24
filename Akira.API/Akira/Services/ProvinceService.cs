﻿using Microsoft.EntityFrameworkCore;
using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Repositories;
using Akira.API.Akira.Domain.Services;
using Akira.API.Akira.Domain.Services.Communication;

namespace Akira.API.Akira.Services;

/// <remarks>
/// This class was developed by Marcelo Scerpella
/// </remarks>
/// <summary>
/// This is the implementation of the interface IEventService, which contains the
/// methods that will be used to perform actions in the API. In this case, the
/// only method that is implemented is how to create a Event
/// </summary>
public class ProvinceService: IProvinceService
{
    private readonly IProvinceRepository _provinceRepository;
    private readonly IUnitOfWork _unitOfWork;
    /// <summary>
    /// Constructor of the class. It requests for an event repository, and the unit of work implementation
    /// </summary>
    /// <param name="provinceRepository">Repository of the events to work with in the future</param>
    /// <param name="unitOfWork">Default unit of work implementation to work with in the future</param>
    public ProvinceService(IProvinceRepository provinceRepository, IUnitOfWork unitOfWork)
    {
        _provinceRepository = provinceRepository;
        _unitOfWork = unitOfWork;
    } 
    public async Task<IEnumerable<Province>> ListAsync()
    {
        var provinces = await _provinceRepository.ListAsync();
        return provinces;
    }

    public Task<ProvinceResponse> SaveAsync(Province province)
    {
        throw new NotImplementedException();
    }
    
    public async  Task<Province> GetProvinceByIdAsync(int id)
    {
        var province = await _provinceRepository.FindByIdAsync(id);
        return province;
    }
}
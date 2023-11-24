using Microsoft.EntityFrameworkCore;
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
public class CategoryService: ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    /// <summary>
    /// Constructor of the class. It requests for an event repository, and the unit of work implementation
    /// </summary>
    /// <param name="categoryRepository">Repository of the events to work with in the future</param>
    /// <param name="unitOfWork">Default unit of work implementation to work with in the future</param>
    public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    } 
    public async Task<IEnumerable<Category>> ListAsync()
    {
        var categorys = await _categoryRepository.ListAsync();
        return categorys;
    }

    public Task<CategoryResponse> SaveAsync(Category category)
    {
        throw new NotImplementedException();
    }
    
    public async  Task<Category> GetCategoryByIdAsync(int id)
    {
        var category = await _categoryRepository.FindByIdAsync(id);
        return category;
    }
}
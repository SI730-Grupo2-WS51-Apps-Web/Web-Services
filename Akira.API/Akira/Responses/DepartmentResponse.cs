using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Responses;

public class DepartmentResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    
    public IList<Province> Provinces = new List<Province>();
}
namespace Akira.API.Akira.Domain.Models;

public class Department
{
    public string Id { get; set; }
    public string Name { get; set; }
    
    public IList<Province> Provinces = new List<Province>();
}
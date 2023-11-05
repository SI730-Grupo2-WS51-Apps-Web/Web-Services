namespace Akira.API.Akira.Domain.Models;

public class Province
{
    public string Id { get; set; }
    public string Name { get; set; }
    
    public IList<District> Districts = new List<District>();
    
    public int DepartmentId { get; set; }
    public Department? Department { get; set; }
}
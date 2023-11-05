namespace Akira.API.Akira.Domain.Models;

public class District
{
    public string Id { get; set; }
    public string Name { get; set; }

    public int ProvinceId { get; set; }
    public Province? Province { get; set; }
}
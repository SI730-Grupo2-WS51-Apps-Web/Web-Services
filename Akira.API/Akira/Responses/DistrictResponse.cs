using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Responses;

public class DistrictResponse
{
    public string Id { get; set; }
    public string Name { get; set; }

    public int ProvinceId { get; set; }
    public Province? Province { get; set; }
}
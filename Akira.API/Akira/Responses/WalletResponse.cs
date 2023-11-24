using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Responses;

public class WalletResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Max { get; set; }
}
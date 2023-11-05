using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Resources;

public class WalletResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Max { get; set; }
}
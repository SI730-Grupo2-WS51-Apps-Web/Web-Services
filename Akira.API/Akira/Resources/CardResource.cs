using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Resources;
public class CardResource
{
    public int Id { get; set; }
    public string CardNumber { get; set; }
    public string CardOwner { get; set; }
    public string CardMonthExpiration { get; set; }
    public string CardYearExpiration { get; set; }
    public string CardCVV { get; set; }
    public int AccountId { get; set; }
    public Account? Account { get; set; }
}
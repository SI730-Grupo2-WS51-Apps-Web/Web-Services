using System.Text.Json.Serialization;

namespace Akira.API.Akira.Domain.Models;

public class Card
{
    public int Id { get; set; }
    public string CardNumber { get; set; }
    public string CardOwner { get; set; }
    public string CardMonthExpiration { get; set; }
    public string CardYearExpiration { get; set; }
    public string CardCVV { get; set; }
    public int AccountId { get; set; }
    [JsonIgnore]
    public Account? Account { get; set; }
}
using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Responses;

public class SubcategoryResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Title { get; set; }
    public string? Subtitle { get; set; }
    
    //Relaciones
    public int? ProductId { get; set; }
    public Product? Product { get; set; }
    
    //Relacion con tu padre toxico
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    
    //Lista de franquicias
    public IList<Franchise>? Franchises { get; set; } = new List<Franchise>();
    
    //Lista de productos
    public IList<Product>? Products { get; set; } = new List<Product>();
}
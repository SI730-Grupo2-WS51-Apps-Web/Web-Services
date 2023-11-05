namespace Akira.API.Akira.Domain.Models;
using Akira.Domain.Models;
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Title { get; set; }
    public string? Subtitle { get; set; }
    
    //Main product
    public int? ProductId { get; set; }
    public Product? Product { get; set; }
    
    //Lista de subcategorias
    public IList<Subcategory> Subcategories { get; set; } = new List<Subcategory>();
    
    //Lista de productos
    public IList<Product> Products { get; set; } = new List<Product>();
}
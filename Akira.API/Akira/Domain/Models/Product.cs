using System.Text.Json.Serialization;

namespace Akira.API.Akira.Domain.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public int Stock { get; set; }
    
    //Imagenes:
    public IList<ProductImage>? Images { get; set; } = new List<ProductImage>();
    
    //Categoria:
    public int? CategoryId { get; set; }
    [JsonIgnore]
    public Category? Category { get; set; }
    
    //Subcategoria:
    public int? SubcategoryId { get; set; }
    [JsonIgnore]
    public Subcategory? Subcategory { get; set; }
    
    //Franquicia:
    public int? FranchiseId { get; set; }
    [JsonIgnore]
    public Franchise? Franchise { get; set; }
}
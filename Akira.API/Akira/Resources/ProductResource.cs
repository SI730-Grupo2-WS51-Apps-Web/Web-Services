using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Resources;

public class ProductResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public int Stock { get; set; }
    
    //Categoria:
    public int? CategoryId { get; set; }
    
    //Subcategoria:
    public int? SubcategoryId { get; set; }
    
    //Franquicia:
    public int? FranchiseId { get; set; }
}
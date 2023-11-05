using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Resources;

public class FranchiseResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    //Relación con el padre toxico
    public int? SubcategoryId { get; set; }
    public Subcategory? Subcategory { get; set; }
    
    //Lista de productos
    public IList<Product>? Products { get; set; } = new List<Product>();
}
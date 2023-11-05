using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Resources;

public class ProductPerOrderResource
{
    [Key]
    [Column(Order=0)]
    public int ProductId {get;set;}
    public Product? Product {get;set;}
    
    [Key]
    [Column(Order=0)]
    public int OrderId {get;set;}
    public Order? Order {get;set;}
    
    public int Amount {get;set;}
    public float UnitPrice {get;set;}
}
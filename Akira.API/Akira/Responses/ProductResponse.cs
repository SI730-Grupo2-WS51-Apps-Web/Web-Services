﻿using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Responses;

public class ProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public int Stock { get; set; }
    
    //Imagenes:
    public IList<ProductImage>? Images { get; set; } = new List<ProductImage>();
    
    //Categoria:
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    
    //Subcategoria:
    public int? SubcategoryId { get; set; }
    public Subcategory? Subcategory { get; set; }
    
    //Franquicia:
    public int? FranchiseId { get; set; }
    public Franchise? Franchise { get; set; }
}
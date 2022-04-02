using System;
using System.ComponentModel.DataAnnotations;

namespace StoreProjectApp.Models;

public class Product
{
    public string Id { get; set; }

    [Display(Name = "Article Number")]
    public string ArticleNumber { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}

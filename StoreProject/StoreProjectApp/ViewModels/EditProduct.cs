namespace StoreProjectApp.ViewModels;

public class EditProduct
{
    public string? Id { get; set; } = null;
    public string ArticleNumber { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}

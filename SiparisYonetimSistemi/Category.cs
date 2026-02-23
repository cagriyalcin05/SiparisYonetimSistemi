using System.Collections.Generic;

public class Category
{
    public string CategoryName { get; set; } = string.Empty;
    public List<Product> Products { get; set; } = new List<Product>();
}
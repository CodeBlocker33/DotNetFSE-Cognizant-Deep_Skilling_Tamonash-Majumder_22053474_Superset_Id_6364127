using System;
using System.Linq;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }

    public Product(int id, string name, string category)
    {
        ProductId = id;
        ProductName = name;
        Category = category;
    }
}

public class ECommerceSearch
{
    public static Product LinearSearch(Product[] products, string name)
    {
        foreach (var product in products)
        {
            if (product.ProductName.Equals(name, StringComparison.OrdinalIgnoreCase))
                return product;
        }
        return null;
    }

    public static Product BinarySearch(Product[] products, string name)
    {
        int left = 0;
        int right = products.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            int compare = string.Compare(products[mid].ProductName, name, StringComparison.OrdinalIgnoreCase);

            if (compare == 0)
                return products[mid];
            else if (compare < 0)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return null;
    }
}

class Program
{
    static void Main()
    {
        Product[] products = new Product[]
        {
            new Product(1, "Laptop", "Electronics"),
            new Product(2, "Shoes", "Fashion"),
            new Product(3, "Smartphone", "Electronics"),
            new Product(4, "Book", "Education")
        };

        var foundLinear = ECommerceSearch.LinearSearch(products, "Shoes");
        Console.WriteLine(foundLinear != null ? $"Linear: Found {foundLinear.ProductName}" : "Linear: Not Found");

        var sorted = products.OrderBy(p => p.ProductName).ToArray();
        var foundBinary = ECommerceSearch.BinarySearch(sorted, "Shoes");
        Console.WriteLine(foundBinary != null ? $"Binary: Found {foundBinary.ProductName}" : "Binary: Not Found");
    }
}

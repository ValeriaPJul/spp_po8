using System;
using System.Collections.Generic;

public abstract class Product
{
    public string Name { get; protected set; }
    public decimal Price { get; protected set; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}

public class ChocolateBar : Product
{
    public ChocolateBar(string name, decimal price) : base(name, price)
    {
    }
}

public class Chips : Product
{
    public Chips(string name, decimal price) : base(name, price)
    {
    }
}

public class PackagedJuice : Product
{
    public PackagedJuice(string name, decimal price) : base(name, price)
    {
    }
}

public abstract class ProductFactory
{
    public abstract Product CreateProduct(string name, decimal price);
}

public class ChocolateBarFactory : ProductFactory
{
    public override Product CreateProduct(string name, decimal price)
    {
        return new ChocolateBar(name, price);
    }
}

public class ChipsFactory : ProductFactory
{
    public override Product CreateProduct(string name, decimal price)
    {
        return new Chips(name, price);
    }
}

public class PackagedJuiceFactory : ProductFactory
{
    public override Product CreateProduct(string name, decimal price)
    {
        return new PackagedJuice(name, price);
    }
}

public class VendingMachine
{
    private List<Product> products = new List<Product>();

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal CalculateTotal()
    {
        decimal total = 0;
        foreach (var product in products)
        {
            total += product.Price;
        }
        return total;
    }
}

class Program
{
    static void Main(string[] args)
    {
        VendingMachine vendingMachine = new VendingMachine();
        ProductFactory chocolateBarFactory = new ChocolateBarFactory();
        ProductFactory chipsFactory = new ChipsFactory();
        ProductFactory packagedJuiceFactory = new PackagedJuiceFactory();

        Product chocolateBar = chocolateBarFactory.CreateProduct("Milk Chocolate", 1.99m);
        Product chips = chipsFactory.CreateProduct("Potato Chips", 2.99m);
        Product packagedJuice = packagedJuiceFactory.CreateProduct("Orange Juice", 3.99m);

        vendingMachine.AddProduct(chocolateBar);
        vendingMachine.AddProduct(chips);
        vendingMachine.AddProduct(packagedJuice);
        Console.WriteLine("Total: $" + vendingMachine.CalculateTotal());
    }
}

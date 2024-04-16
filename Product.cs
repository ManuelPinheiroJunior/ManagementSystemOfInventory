class Product
{
    public string Name { get; }
    public double Price { get; }
    public int Quantity { get; set; }

    public Product(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"{Name} - ${Price:F2} - Quantity: {Quantity}";
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagementSystem
{
    class Inventory
    {
        private List<Product> products;

        public Inventory()
        {
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public bool RemoveProduct(string name)
        {
            Product product = products.FirstOrDefault(p => p.Name == name);
            if (product != null)
            {
                products.Remove(product);
                return true;
            }
            return false;
        }

        public bool UpdateQuantity(string name, int newQuantity)
        {
            Product product = products.FirstOrDefault(p => p.Name == name);
            if (product != null)
            {
                product.Quantity = newQuantity;
                return true;
            }
            return false;
        }

        public void AddProductFromInput()
        {
            Console.WriteLine("Enter product name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter product price:");
            double price = ReadDoubleInput("Invalid price. Please enter again:");

            Console.WriteLine("Enter product stock quantity:");
            int quantity = ReadIntInput("Invalid quantity. Please enter again:");

            Product product = new Product(name, price, quantity);
            AddProduct(product);

            Console.WriteLine("Product added successfully.");
        }

        public void RemoveProductByName()
        {
            Console.WriteLine("Enter the name of the product you want to remove:");
            string name = Console.ReadLine();

            if (RemoveProduct(name))
            {
                Console.WriteLine("Product removed successfully.");
            }
            else
            {
                Console.WriteLine("Product not found in inventory.");
            }
        }

        public void UpdateProductQuantity()
        {
            Console.WriteLine("Enter the name of the product you want to update:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the new stock quantity of the product:");
            int quantity = ReadIntInput("Invalid quantity. Please enter again:");

            if (UpdateQuantity(name, quantity))
            {
                Console.WriteLine("Quantity updated successfully.");
            }
            else
            {
                Console.WriteLine("Product not found in inventory.");
            }
        }

        public void ListAllProducts()
        {
            Console.WriteLine("Products in inventory:");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }

        public void SearchProductByName()
        {
            Console.WriteLine("Enter the substring to search for in product names:");
            string substring = Console.ReadLine();

            var foundProducts = products.Where(p => p.Name.Contains(substring)).ToList();
            if (foundProducts.Any())
            {
                Console.WriteLine("Products found:");
                foreach (var product in foundProducts)
                {
                    Console.WriteLine(product);
                }
            }
            else
            {
                Console.WriteLine("No product found with the provided substring.");
            }
        }

        public void GenerateReportBelowLimit()
        {
            Console.WriteLine("Enter the quantity limit for the report:");
            int limit = ReadIntInput("Invalid limit. Please enter again:");

            var productsBelowLimit = products.Where(p => p.Quantity < limit).ToList();
            if (productsBelowLimit.Any())
            {
                Console.WriteLine($"Products with quantity below {limit}:");
                foreach (var product in productsBelowLimit)
                {
                    Console.WriteLine(product);
                }
            }
            else
            {
                Console.WriteLine("No products with quantity below the provided limit.");
            }
        }

        public void ListProductsOrderedByQuantity()
        {
            Console.WriteLine("Products ordered by stock quantity:");
            foreach (var product in products.OrderBy(p => p.Quantity))
            {
                Console.WriteLine(product);
            }
        }

        private double ReadDoubleInput(string errorMessage)
        {
            double value;
            while (!double.TryParse(Console.ReadLine(), out value) || value < 0)
            {
                Console.WriteLine(errorMessage);
            }
            return value;
        }

        private int ReadIntInput(string errorMessage)
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value) || value < 0)
            {
                Console.WriteLine(errorMessage);
            }
            return value;
        }
    }
}

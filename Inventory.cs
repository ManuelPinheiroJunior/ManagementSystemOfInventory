using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagementSystem
{
    class Inventory
    {
        private readonly List<Product> products = new List<Product>();
        private readonly IInputOutputService ioService;

        public Inventory(IInputOutputService inputOutputService)
        {
            this.ioService = inputOutputService;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public bool RemoveProduct(string name)
        {
            var product = products.FirstOrDefault(p => p.Name == name);
            if (product != null)
            {
                products.Remove(product);
                return true;
            }
            return false;
        }

        public bool UpdateProductQuantity(string name, int newQuantity)
        {
            var product = products.FirstOrDefault(p => p.Name == name);
            if (product != null)
            {
                product.Quantity = newQuantity;
                return true;
            }
            return false;
        }

        public void ProcessProductAddition()
        {
            string name = ioService.ReadLine("Enter product name:");
            double price = ioService.ReadDouble("Enter product price:", "Invalid price. Please enter again:");
            int quantity = ioService.ReadInt("Enter product stock quantity:", "Invalid quantity. Please enter again:");

            AddProduct(new Product(name, price, quantity));
            ioService.WriteLine("Product added successfully.");
        }

        public void ProcessProductRemoval()
        {
            string name = ioService.ReadLine("Enter the name of the product you want to remove:");
            if (RemoveProduct(name))
            {
                ioService.WriteLine("Product removed successfully.");
            }
            else
            {
                ioService.WriteLine("Product not found in inventory.");
            }
        }

        public void UpdateProductStock()
        {
            string name = ioService.ReadLine("Enter the name of the product you want to update:");
            int quantity = ioService.ReadInt("Enter the new stock quantity of the product:", "Invalid quantity. Please enter again:");

            if (UpdateProductQuantity(name, quantity))
            {
                ioService.WriteLine("Quantity updated successfully.");
            }
            else
            {
                ioService.WriteLine("Product not found in inventory.");
            }
        }

        public void ListAllProducts()
        {
            ioService.WriteLine("Products in inventory:");
            foreach (var product in products)
            {
                ioService.WriteLine(product.ToString());
            }
        }

        public void SearchProducts()
        {
            string substring = ioService.ReadLine("Enter the substring to search for in product names:");
            var foundProducts = products.Where(p => p.Name.Contains(substring)).ToList();
            if (foundProducts.Any())
            {
                ioService.WriteLine("Products found:");
                foreach (var product in foundProducts)
                {
                    ioService.WriteLine(product.ToString());
                }
            }
            else
            {
                ioService.WriteLine("No product found with the provided substring.");
            }
        }

        public void GenerateReportBelowQuantity()
        {
            int limit = ioService.ReadInt("Enter the quantity limit for the report:", "Invalid limit. Please enter again:");
            var productsBelowLimit = products.Where(p => p.Quantity < limit).ToList();
            if (productsBelowLimit.Any())
            {
                ioService.WriteLine($"Products with quantity below {limit}:");
                foreach (var product in productsBelowLimit)
                {
                    ioService.WriteLine(product.ToString());
                }
            }
            else
            {
                ioService.WriteLine("No products with quantity below the provided limit.");
            }
        }

        public void ListProductsByQuantity()
        {
            ioService.WriteLine("Products ordered by stock quantity:");
            foreach (var product in products.OrderBy(p => p.Quantity))
            {
                ioService.WriteLine(product.ToString());
            }
        }
    }

    interface IInputOutputService
    {
        void WriteLine(string message);
        string ReadLine(string prompt);
        double ReadDouble(string prompt, string errorMessage);
        int ReadInt(string prompt, string errorMessage);
    }

    // Implement IInputOutputService to manage Console I/O operations.
    // Example implementations and additional services can be created as needed.
}

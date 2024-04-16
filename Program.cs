using System;

namespace InventoryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();

            bool continueRunning = true;
            while (continueRunning)
            {
                ShowMenu();

                int option;
                if (int.TryParse(Console.ReadLine(), out option))
                {
                    try
                    {
                        switch (option)
                        {
                            case 1:
                                inventory.AddProductFromInput();
                                break;
                            case 2:
                                inventory.RemoveProductByName();
                                break;
                            case 3:
                                inventory.UpdateProductQuantity();
                                break;
                            case 4:
                                inventory.ListAllProducts();
                                break;
                            case 5:
                                inventory.SearchProductByName();
                                break;
                            case 6:
                                inventory.GenerateReportBelowLimit();
                                break;
                            case 7:
                                inventory.ListProductsOrderedByQuantity();
                                break;
                            case 8:
                                continueRunning = false;
                                break;
                            default:
                                Console.WriteLine("Invalid option.");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                }

                Console.WriteLine();
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("Management System Of Inventory for clients");
            Console.WriteLine();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add product");
            Console.WriteLine("2. Remove product");
            Console.WriteLine("3. Update product quantity");
            Console.WriteLine("4. List all products");
            Console.WriteLine("5. Search for product by name");
            Console.WriteLine("6. Generate report of products below a certain limit");
            Console.WriteLine("7. List all products ordered by stock quantity");
            Console.WriteLine("8. Exit");
        }
    }
}

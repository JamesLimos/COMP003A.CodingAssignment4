/*
 Author: James Limos
 Course: COMP-003A
 Faculty: Jonathan Cruz
 Purpose: Inventory management application with a minimum of 10 elements in the collection. 
 */
namespace COMP003A.CodingAssignment4
{
    internal class Program
    {
        static List<string> productNames = new List<string>();
        static List<int> productQuantities = new List<int>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nInventory Management System Menu");
                Console.WriteLine("1. Add a Product");
                Console.WriteLine("2. Update a Product Quantity");
                Console.WriteLine("3. View Inventory Summary");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddProduct();
                    break;
                    case 2:
                        UpdateProduct(); 
                    break;
                    case 3:
                        ViewProduct();
                    break;
                    case 4:
                        Console.WriteLine("\nGoodbye!");
                        return;
                    break;
                    default:
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        break;
                }
            }
        }
        static void AddProduct()
        {
            if (productNames.Count >= 10)
            {
                Console.WriteLine("Inventory is full. Cannot add more products.");
                return;
            }
            Console.Write("\nEnter product name: ");
            string newproductName = Console.ReadLine();
            Console.Write("Enter product quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int newproductQuantity))
            {
                Console.WriteLine("Invalid input. Please enter a valid quantity.");
                return;
            }
            productNames.Add(newproductName);
            productQuantities.Add(newproductQuantity);
            Console.WriteLine("Product added successfully.");
        }
        static void UpdateProduct()
        {
            Console.Write("Enter the product name to update quantity: ");
            string productName = Console.ReadLine();
            int index = productNames.IndexOf(productName);
            if (index != -1)
            {
                Console.Write("Enter the new quantity: ");
                if (int.TryParse(Console.ReadLine(), out int newproductQuantity))
                {
                    productQuantities[index] = newproductQuantity;
                    Console.WriteLine("Quantity updated successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid quantity.");
                }
            }
            else
            {
                Console.WriteLine("Product not found. Please try again.");
            }
        }
        static void ViewProduct()
        {
            Console.WriteLine("Inventory Summary:");
            for (int i = 0; i < productNames.Count; i++)
            {
                Console.WriteLine($"{productNames[i]}: {productQuantities[i]}");
            }
            Console.WriteLine($"Total Product: {productNames.Count}");
            int totalQuantity = productQuantities.Sum();
            Console.WriteLine($"Total Quantity: {totalQuantity}");
            double sum = 0;
            for (int i = 0; i < productQuantities.Count; i++)
            {
                sum += productQuantities[i];
            }
            double avergae = sum / productQuantities.Count;
            Console.WriteLine($"Average Quantity: {avergae:F2}");
        }
    }
}
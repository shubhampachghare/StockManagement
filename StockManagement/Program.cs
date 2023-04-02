using System;
using System.Collections.Generic;

namespace StockManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            Console.WriteLine("Welcome to Stock Management System!");

            while (true)
            {
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View Products");
                Console.WriteLine("3. Update Product Quantity");
                Console.WriteLine("4. Exit");

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AddProduct(products);
                        break;

                    case 2:
                        ViewProducts(products);
                        break;

                    case 3:
                        UpdateProductQuantity(products);
                        break;

                    case 4:
                        Console.WriteLine("\nThank you for using Stock Management System!");
                        return;

                    default:
                        Console.WriteLine("\nInvalid option! Please try again.");
                        break;
                }
            }
        }

        static void AddProduct(List<Product> products)
        {
            Console.WriteLine("\nPlease enter the product details:");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            products.Add(new Product(name, price, quantity));

            Console.WriteLine("\nProduct added successfully!");
        }

        static void ViewProducts(List<Product> products)
        {
            Console.WriteLine("\nList of products:");

            if (products.Count == 0)
            {
                Console.WriteLine("No products found!");
            }
            else
            {
                Console.WriteLine("{0,-10}{1,-20}{2,-10}", "ID", "Name", "Quantity");

                int id = 1;
                foreach (Product product in products)
                {
                    Console.WriteLine("{0,-10}{1,-20}{2,-10}", id++, product.Name, product.Quantity);
                }
            }
        }

        static void UpdateProductQuantity(List<Product> products)
        {
            Console.WriteLine("\nPlease select a product to update quantity:");

            ViewProducts(products);

            int id = Convert.ToInt32(Console.ReadLine());

            if (id < 1 || id > products.Count)
            {
                Console.WriteLine("\nInvalid product ID! Please try again.");
            }
            else
            {
                Console.Write("New Quantity: ");
                int newQuantity = Convert.ToInt32(Console.ReadLine());

                products[id - 1].Quantity = newQuantity;

                Console.WriteLine("\nProduct quantity updated successfully!");
            }
        }
    }

    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}
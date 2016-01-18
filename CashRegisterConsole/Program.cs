using System;
using CashRegister;

namespace CashRegisterConsole
{
    class Program
    {
        static void Main()
        {
            var products = new ProductDal();
            products.AddProduct(new Product("item-1", "IPhone 6", 999));
            products.AddProduct(new Product("item-2", "Surface 2 pro", 2000));
            products.AddProduct(new Product("item-3", "Stamps", 2));
            products.AddProduct(new Product("item-4", "Arduino Ono", 25));


            var shoppingCart = new ShoppingCart(products);
            var register = new Register(shoppingCart, new ConsoleDisplay());

            Console.WriteLine("add - Add product to cart");
            Console.WriteLine("total - show total");
            Console.WriteLine("exit - exit from simulatio");

            var keepRunning = true;
            while (keepRunning)
            {

                Console.Write("Command>>");
                var readLine = Console.ReadLine();

                switch (readLine)
                {
                    case "add":
                        Console.WriteLine("product id?");
                        Console.Write("Add>>");
                        var productId = Console.ReadLine();
                        register.Add(productId);
                        break;
                    case "total":
                        register.Total();
                        break;
                    case "exit":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine(">>> Wrong input :(");
                        break;
                }
            }
        }
    }
}

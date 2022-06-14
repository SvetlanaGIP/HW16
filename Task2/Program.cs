using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = String.Empty;
            using (StreamReader sr=new StreamReader("../../../Products.json"))
            {
                jsonString = sr.ReadToEnd();
            }
            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString);

            //string json = File.ReadAllText("Products.json");
            //Product[] products = JsonSerializer.Deserialize<Product[]>(json);

            Product maxProduct = products[0];
            //String productName = "";
            foreach (Product p in products)
            {
                if (p.Price > maxProduct.Price)
                {
                    maxProduct = p;
                }
                    
            }

            Console.WriteLine($"{maxProduct.ProductId}{maxProduct.Name}{maxProduct.Price}");

            Console.Write("press any key to exit");
            Console.ReadKey();
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace HW16
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter data for 5 products");
            const int n = 5;
            Product[] products = new Product[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Please enter product code:");
                String ProductIdRaw = Console.ReadLine();
                int productId = System.Convert.ToInt32(ProductIdRaw);

                Console.Write("Please enter name:");
                string name = Console.ReadLine();

                Console.Write("Please enter price:");
                String priceRaw = Console.ReadLine();
                double price = System.Convert.ToDouble(priceRaw);
                

                products[i] = new Product() { ProductId = productId, Name = name, Price = price };
            }

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(products);
            
            using (StreamWriter sw =new StreamWriter("../../../Products.json"))
            {
                sw.WriteLine(jsonString);
            }
            
        }

        
    }
}

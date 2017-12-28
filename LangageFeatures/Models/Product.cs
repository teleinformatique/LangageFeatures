using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LangageFeatures.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; } = "Watersports";
        public decimal? Price { get; set; }
        public Product Related { get; set; }
        public bool InStock { get; } = true;
        public bool NameBeginsWithS => Name?[0] == 'S';


        public static Product[] GetProducts()
        {
            Product kayak = new Product { Name = "Kayak", Price = 275M, Category = "Water Craft" };
            Product lifejacket = new Product { Name = "Lifejacket", Price = 48.95M };
            kayak.Related = lifejacket;

            return new Product[] { kayak, lifejacket, null };
        }
    }
}

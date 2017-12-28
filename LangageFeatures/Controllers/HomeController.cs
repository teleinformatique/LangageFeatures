using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LangageFeatures.Models;
using Microsoft.AspNetCore.Mvc;

namespace LangageFeatures.Controllers
{
    public class HomeController : Controller
    {
        bool FilterByPrice(Product p)
        {
            return (p?.Price ?? 0) <= 20;
        }

        public ViewResult Index()
        {
            List<string> results = new List<string>();

            foreach (Product p in Product.GetProducts())
            {
                string name = p?.Name ?? "<No name>";
                decimal? price = p?.Price ?? 0;
                string relatedName = p?.Related?.Name ?? "<None>";

                results.Add($"Name: {name}, Price: {price:C2}, related: {relatedName}");
            }

            //index initialiser
            Dictionary<string, Product> products = new Dictionary<string, Product> {
                ["Kayak"] = new Product { Name = "Kayak", Price = 275M, Category = "Water Craft" },
                ["LifeJacket"] = new Product { Name = "Lifejacket", Price = 48.95M }
            };

            //pattern matching
            object[] data = new object[] { 275M, 29.9M, "apple", 100, 0 };
            decimal total = 0;
            for (int i = 0; i < data.Length; i++)
            {
                //if (data[i] is decimal d)
                //{
                //    total += d;
                //}
                switch (data[i])
                {
                    case decimal decimalValue:
                        total += decimalValue;
                        break;

                    case int intValue when intValue > 50:
                        total += intValue;
                        break;
                }
            }

            //ExtensionMethods
            ShopingCart cart = new ShopingCart { Products = Product.GetProducts() };
            decimal cartTotal = cart.TotalPrices();
            Product[] productArray = {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifejacket", Price = 48.95M},
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product {Name = "Corner flag", Price = 34.95M}
            };
            //decimal arrayTotal = productArray.FilterByPrice(20).TotalPrices();

            Func<Product, bool> nameFilter = delegate (Product p)
            {
                return p?.Name?[0] == 'S';
            };

            decimal priceFilterTotal = productArray.Filter(p => (p?.Price ?? 0) >= 20).TotalPrices();
            decimal nameFilterTotal = productArray.Filter(p => (p?.Name[0] == 'S')).TotalPrices();

            return View(new string [] { $"priceFilterTotal: {priceFilterTotal:C2}", $"nameFilterTotal: {nameFilterTotal:C2}" });
        }
    }
}
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
                if (data[i] is decimal d)
                {
                    total += d;
                }
            }

            return View(new string [] { $"Total: {total:C2}" });
        }
    }
}
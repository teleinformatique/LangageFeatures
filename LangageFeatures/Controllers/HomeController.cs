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

                results.Add(string.Format("Name: {0}, Price: {1}, related: {2}", name, price, relatedName));
            }
            return View(results);
        }
    }
}
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
      
        public ViewResult Index() => View(Product.GetProducts().Select(p => p?.Name));
        
    }
}
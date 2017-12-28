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

        public async Task<ViewResult> Index()
        {
            long? length = await MyAsyncMethods.GetPageLength();
            return View(new string[] { $"Length: {length}" });
        }
        
    }
}
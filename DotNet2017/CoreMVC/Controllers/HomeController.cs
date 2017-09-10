using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreMVC.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;

namespace CoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var path = System.IO.Path.Combine(_hostingEnvironment.ContentRootPath, "file.json");
            string jsonPath = path.Replace("\\", "\\\\").Replace("/", "\\/");

            var json = "{\"KeyValues\":[{\"Key\": \"Test\",\"Value\": \"" + jsonPath + " file could not be located, so this holds only this test key-value.\"}]}";

            if (System.IO.File.Exists(path))
            {
                json = System.IO.File.ReadAllText(path);
            }
            var keyValues = JsonConvert.DeserializeObject<KeyValues>(json);
            return View(keyValues);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Welcome to ASP.NET Core 2.0 application test page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Yuvaraja CHENNAKRISHNAN.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

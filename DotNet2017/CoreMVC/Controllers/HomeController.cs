using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreMVC.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net;

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
            var keyValues = GetJsonKeyValuesData();
            return View(keyValues);
        }

        private KeyValues GetJsonKeyValuesData()
        {
            var path = System.IO.Path.Combine(_hostingEnvironment.ContentRootPath, "file.json");
            string jsonPath = path.Replace("\\", "\\\\").Replace("/", "\\/");

            var json = "{\"KeyValues\":[{\"Key\": \"Test\",\"Value\": \"" + jsonPath + " file could not be located, so this holds only this test key-value.\"}]}";

            if (System.IO.File.Exists(path))
            {
                json = System.IO.File.ReadAllText(path);
            }
            return JsonConvert.DeserializeObject<KeyValues>(json);
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

        public ActionResult DisplayLocalSearchResult(string searchText)
        {
            var data = GetJsonKeyValuesData();
            var result = data.keyValues.FirstOrDefault(o => o.Key.Equals(searchText, StringComparison.InvariantCultureIgnoreCase));
            if (result == null)
            {
                result = new KeyValue { Key = searchText, Value = "-none-" };
            }
            return PartialView("LocalSearchResults", result);

        }

        public ActionResult DisplayServiceSearchResult(string searchText, string serviceUrl)
        {
            string url = serviceUrl.TrimEnd('/') + "/" + searchText;
            string output = url;
            try
            {
                var client = new WebClient();

                client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.113 Safari/537.36");
                var response = client.DownloadString(url);
                dynamic jsonData = JObject.Parse(response);
                output = jsonData.value;
            }
            catch (Exception ex)
            {
                output = "not found"; //+ " error: " + ex.Message;
            }
            var result = new KeyValue { Key = searchText, Value = output };
            return PartialView("ServiceSearchResults", result);
        }
    }
}

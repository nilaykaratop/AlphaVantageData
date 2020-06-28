using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Alphava.Models;
using RestSharp;
using Newtonsoft.Json;

namespace Alphava.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            //base
            var client = new RestClient("https://www.alphavantage.co");
            //resource
            var request = new RestRequest("/query?function=TIME_SERIES_WEEKLY&symbol=IBM&apikey=3LB8NNIVP20U94NH");
            //client üzerinden requesti servise yolluyoruz
            var content = client.Execute(request).Content;
            // json'daki verileri kendi uygulamamızdaki Class’a aktarmak için
            StockData quertresult = JsonConvert.DeserializeObject<StockData>(content);
            return View(quertresult);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

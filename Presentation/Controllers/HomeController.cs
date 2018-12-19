using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using Domain.Material;
using Infrastructure;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Message"] = "てすと";
            return View();
        }

        public IActionResult Test()
        {
            var repo = new InMemoryMaterialRepository();
            var app = new MaterialApplicationService(repo);

            app.Save("12345678", "mat1", 0, null, null, 55.591f, 40.1f, 30.0f);
            app.Save("00001111", "mate2", 0, null, null, 10.1f, 59.9f, 11.2f);
            app.Save("11112222", "mate3", 1, "M040", 23.92f, null, 9.2f, 20.0f);

            Material test = app.Find("11112222");

            ViewData["Message"] = test.Type.Name;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

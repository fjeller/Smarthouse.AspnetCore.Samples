using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Berlin.Models;

namespace Berlin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Share(string id)
        {
            return View("Share", id);
        }

        public IActionResult EnterName()
        {
            return View();
        }

        public IActionResult SaveNames(EnterNameModel model)
        {
            DisplayNameModel resultModel = new DisplayNameModel()
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            return PartialView("_DisplayName", resultModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

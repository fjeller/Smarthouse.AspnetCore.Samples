using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BerlinSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace BerlinSample.Controllers
{
    public class UsersController : Controller
    {

        public IActionResult NormalForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveNames(NormalFormModel model)
        {
            // Do some saving
            DisplayNameModel newModel = new DisplayNameModel()
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            NormalFormModel result = new NormalFormModel()
            {
                NamesToDisplay = newModel
            };
            return View("NormalForm", result);

        }

    }
}

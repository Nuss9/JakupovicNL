using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JakupovicNL.Models;

namespace JakupovicNL.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EmailForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EmailForm(EmailForm form)
        {
            if(!ModelState.IsValid) {
                return Index();
            }
            form.Id = new Guid();
            return View("ThankYou", form);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

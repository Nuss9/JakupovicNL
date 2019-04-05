using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JakupovicNL.Models;
using Microsoft.AspNetCore.Http;
using PaulMiami.AspNetCore.Mvc.Recaptcha;

namespace JakupovicNL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMailer mailer;

        public HomeController(IMailer mailer)
        {
            this.mailer  = mailer;
        }

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

		[ValidateRecaptcha]
        [HttpPost]
        public async Task<IActionResult> EmailForm(EmailForm form)
        {
            if(!ModelState.IsValid) {
				// Check for invalid Recaptcha and if so, return anti robot page?
                return View("EmailForm", form);
            }

            form.Id = Guid.NewGuid();
            var response = await mailer.SendEmail(form);

            if(response.StatusCode.ToString() != "Accepted"){
                return View("Oops");
            }

            return View("ThankYou", form);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

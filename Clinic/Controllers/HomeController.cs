using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Clinic.Models;

namespace Clinic.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}

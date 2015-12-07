using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Models;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Message = "Hello World";
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(HomeViewModel viewModel)
        {
            List<double> halves = new List<double>();
            double halveItOriginal = 0;
            if (double.TryParse(viewModel.HalveItOriginal, out halveItOriginal))
            {
                Halving.HalfIt(halveItOriginal, ref halves);

                viewModel.Halves = halves;
            }
            return View(viewModel);
        }



    }
}

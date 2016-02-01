using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Models;
using Microsoft.Practices.Unity;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        private IHalving halving;

        public HomeController() 
        {
            var unityContainer = new UnityContainer();
            unityContainer.RegisterType<IHalving, Halving>();
            unityContainer.RegisterType<IDoSomethingElse, DoSomethingElse>();
            
            this.halving = unityContainer.Resolve<IHalving>();
        }

        public HomeController(IHalving halving)
        {
            this.halving = halving;
        }

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
                this.halving.HalfIt(halveItOriginal, halves);

                viewModel.Halves = halves;
            }
            return View(viewModel);
        }
    }
}

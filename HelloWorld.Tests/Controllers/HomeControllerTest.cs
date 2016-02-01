using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorld;
using HelloWorld.Controllers;
using HelloWorld.Models;
using Moq;

namespace HelloWorld.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void GetIndex()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Hello World", result.ViewBag.Message);
        }


        [TestMethod]
        public void PostIndex()
        {
            // Arrange
            var halves = new List<double>() {10, 5, 2.5};
            Mock<IHalving> mockHalving = new Mock<IHalving>();
            mockHalving.Setup(t => t.HalfIt(20, halves));

            HomeController controller = new HomeController(mockHalving.Object);
             
            HomeViewModel viewModel = new HomeViewModel()
            {
                HalveItOriginal = "20",
                Halves = null,
                WhoAmI = "Ady"
            };

            // Act
            ViewResult result = controller.Index(viewModel) as ViewResult;
            
            // Assert
            mockHalving.Verify(m => m.HalfIt(20, halves));
        }
        
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Clinic.Controllers;
using Clinic.Models;

namespace Clinic.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Stylist_ReturnsCorrect_View()
        {
            HomeController testController = new HomeController();

            ActionResult indexView = testController.Index();

            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }
    }
}


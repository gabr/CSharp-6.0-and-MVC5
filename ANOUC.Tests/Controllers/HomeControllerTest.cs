using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ANOUC;
using ANOUC.Controllers;

namespace ANOUC.Tests.Controllers
{
  [TestClass]
  public class HomeControllerTest
  {
    private HomeController _homeController;

    [TestInitialize]
    public void Startup()
    {
      _homeController = new HomeController();
    }

    [TestMethod]
    public void Index()
    {
      // Act
      ViewResult result = _homeController.Index() as ViewResult;

      // Assert
      Assert.IsNotNull(result);
    }

    [TestMethod]
    public void About()
    {
      // Act
      ViewResult result = _homeController.About() as ViewResult;

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual("Your application description page.", result.ViewBag.Message);
    }

    [TestMethod]
    public void Contact()
    {
      // Act
      ViewResult result = _homeController.Contact() as ViewResult;

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual("Your contact page.", result.ViewBag.Message);
    }
  }
}

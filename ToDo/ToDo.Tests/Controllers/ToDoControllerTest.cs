using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDo;
using ToDo.Controllers;

namespace ToDo.Tests.Controllers
{
    [TestClass]
    public class ToDoControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            ToDoController controller = new ToDoController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            ToDoController controller = new ToDoController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Edit()
        {
            // Arrange
            ToDoController controller = new ToDoController();

            // Act
            ViewResult result = controller.Edit("123") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}

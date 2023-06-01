using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sakugen.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakugen.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        private readonly HomeController _controller;
        private ViewResult _result;

        public HomeControllerTests(HomeController controller)
        {
            _controller = controller;
        }

        [TestInitialize]
        public void SetupContext()
        {
            _result = _controller.Index() as ViewResult;
        }

        [TestMethod()]
        public void IndexViewResultNotNull()
        {
            Assert.IsNotNull(_result);
        }
    }
}
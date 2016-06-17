using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MockHttpContext;
using Xunit;

namespace MockHttpContext.MVC.Tests.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexControllerReturnsQueryString()
        {
            //Setup the controller to be tested
            var controller = new MockHttpContext.MVC.Controllers.HomeController();
            
            //Setup the context
            var mockedHttpContext = new HttpContext("SomeQueryStringValue", @"contoso\bob");

            //Pass the mocked context to the controller
            controller.ControllerContext = new ControllerContext(mockedHttpContext.CurrentHttpContext(), new System.Web.Routing.RouteData(), controller);
            
            Assert.Equal("SomeQueryStringValue", controller.Request.QueryString["qsValue"]);            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MockHttpContext.Tests.Tests
{
    public class HttpContextTests
    {
        [Fact]
        public void ReturnUsernameFromIdentityPropertyTest()
        {            
            var mockedHttpContext = new HttpContext(@"contoso\bob");
            
            Assert.Equal(@"contoso\bob", mockedHttpContext.CurrentHttpContext().Request.RequestContext.HttpContext.User.Identity.Name);                      
        }

        [Fact]
        public void ReturnQueryStringValue()
        {
            var mockedHttpContext = new HttpContext("SomeQueryStringValue", @"contoso\bob");

            Assert.Equal("SomeQueryStringValue", mockedHttpContext.CurrentHttpContext().Request.QueryString["qsValue"]);
        }

        [Fact]
        public void ReturnSessionValue()
        {
            var mockedHttpContext = new HttpContext("SomeQueryStringValue", @"contoso\bob", "Admin");
            
            Assert.Equal("Admin", (string)mockedHttpContext.CurrentHttpContext().Session["UserRole"]);
        }
    }
}

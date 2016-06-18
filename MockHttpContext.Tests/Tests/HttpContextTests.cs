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
            var mockedHttpContext = new HttpContext(new UserContext(@"contoso\bob"));
            
            Assert.Equal(@"contoso\bob", mockedHttpContext.CurrentHttpContext().Request.RequestContext.HttpContext.User.Identity.Name);                      
        }

        [Fact]
        public void ReturnQueryStringValue()
        {
            var sessionNames = new SessionName("qsValue", "UserRole", "LoggedInUser");
            var mockedHttpContext = new HttpContext(new UserContext(sessionNames, @"contoso\bob", "SomeQueryStringValue", "Admin"));

            Assert.Equal("SomeQueryStringValue", mockedHttpContext.CurrentHttpContext().Request.QueryString[sessionNames.QueryString]);
        }

        [Fact]
        public void ReturnSessionValue()
        {
            var sessionNames = new SessionName("qsValue", "UserRole", "LoggedInUser");
            var mockedHttpContext = new HttpContext(new UserContext(sessionNames, @"contoso\bob", "SomeQueryStringValue", "Admin"));

            Assert.Equal("Admin", (string)mockedHttpContext.CurrentHttpContext().Session["UserRole"]);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Moq;


namespace MockHttpContext
{
    public class HttpContext
    {
        private Mock<HttpRequestBase> _mockRequest;
        private HttpSessionStateBase _mockSession;
        private Mock<HttpContextBase> _mockHttpContext;
        private UserContext _userContext;

        public HttpContext(UserContext userContext)
        {
            _userContext = userContext;
        }

        public HttpContextBase CurrentHttpContext()
        {
            var queryString = new System.Collections.Specialized.NameValueCollection { { _userContext.SessionNames.QueryString , _userContext.QueryString } };

            _mockRequest = new Mock<HttpRequestBase>();
            _mockSession = new HttpSession();
                        
            _mockRequest.SetupGet(c => c.RequestContext.HttpContext.Session).Returns(_mockSession);
            _mockHttpContext = new Mock<HttpContextBase>();
                        
            _mockHttpContext.Setup(c => c.Request).Returns(_mockRequest.Object);
            _mockHttpContext.Setup(c => c.Request.RequestContext.HttpContext.User.Identity.Name).Returns(_userContext.Username);
            _mockHttpContext.Setup(c => c.Request.QueryString).Returns(queryString);
            _mockHttpContext.Setup(c => c.Session[_userContext.SessionNames.UserRole]).Returns(_userContext.UserRole);
            _mockHttpContext.Setup(c => c.Request.RequestContext.HttpContext.Session[_userContext.SessionNames.LoggedInUser]).Returns(_userContext.Username);

            return _mockHttpContext.Object;
        }
    }
}


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
        private string _queryStringValue;
        private string _userIdentityName;
        private string _sessionUserRole;

        public HttpContext(string queryStringValue, string userIdentityName, string sessionUserRole) : this(queryStringValue, userIdentityName) 
        {                      
            _sessionUserRole = sessionUserRole;           
        }

        public HttpContext(string queryStringValue, string userIdentityName) : this(userIdentityName)
        {
            _queryStringValue = queryStringValue;
        }

        public HttpContext(string userIdentityName)
        {
            _userIdentityName = userIdentityName;
        }

        public HttpContextBase CurrentHttpContext()
        {
            var queryString = new System.Collections.Specialized.NameValueCollection { { "qsValue", _queryStringValue } };

            _mockRequest = new Mock<HttpRequestBase>();
            _mockSession = new HttpSession();
                        
            _mockRequest.SetupGet(c => c.RequestContext.HttpContext.Session).Returns(_mockSession);
            _mockHttpContext = new Mock<HttpContextBase>();
                        
            _mockHttpContext.Setup(c => c.Request).Returns(_mockRequest.Object);
            _mockHttpContext.Setup(c => c.Request.RequestContext.HttpContext.User.Identity.Name).Returns(_userIdentityName);
            _mockHttpContext.Setup(c => c.Request.QueryString).Returns(queryString);
            _mockHttpContext.Setup(c => c.Session["UserRole"]).Returns(_sessionUserRole);
            _mockHttpContext.Setup(c => c.Request.RequestContext.HttpContext.Session["LoggedInUser"]).Returns(_userIdentityName);

            return _mockHttpContext.Object;
        }
    }
}


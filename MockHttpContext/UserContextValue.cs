using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHttpContext
{
    public class UserContextValue
    {
        public UserContextValue(string identityUsername, string queryString, string userRole)
        {
            IdentityUsername = identityUsername;
            QueryString = queryString;
            UserRole = userRole;
        }

        public string IdentityUsername
        {
            private set;
            get;
        }

        public string QueryString
        {
            private set;
            get;
        }

        public string UserRole
        {
            private set;
            get;
        }
    }
}

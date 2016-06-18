using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHttpContext
{
    public class SessionName
    {   
        public SessionName(string queryString, string userRole, string loggedInUser)
        {
            QueryString = queryString;
            UserRole = userRole;
            LoggedInUser = loggedInUser;
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

        public string LoggedInUser
        {
            private set;
            get;
        }
    }
}

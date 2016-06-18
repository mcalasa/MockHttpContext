using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHttpContext
{
    public class UserContext
    {   
        public UserContext(SessionName sessionNames, string username, string queryString, string userRole)
            : this(username)
        {
            SessionNames = sessionNames;
            QueryString = queryString;
            UserRole = userRole;
        }

        public UserContext(string username)
        {
            Username = username;
            SessionNames = new SessionName(string.Empty, string.Empty, string.Empty);
        }

        public string Username
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

        public SessionName SessionNames
        {
            private set;
            get;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockHttpContext
{
    public class UserContext
    {   
        public UserContext(SessionName sessionNames, UserContextValue userContextValue)            
        {
            SessionNames = sessionNames;
            UserContextValue = userContextValue;            
        }       

        public UserContextValue UserContextValue
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

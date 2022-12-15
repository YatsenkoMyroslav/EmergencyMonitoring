using CCL.Security.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security
{
    public static class SecurityContext
    {
        private static User user = null;

        public static User GetUser() { 
            return user; 
        }

        public static void SetUser(User newUser) {
            user = newUser;
        }
    }
}

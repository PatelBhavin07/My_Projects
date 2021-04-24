using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Contacts_App
{
    class Globals
    {
        // class to make the logged in user id global everywhere on the application
        

        public static int GlobalUserId { get; private set; }

        public static void SetGlobalUserIId(int userId)
        {
            GlobalUserId = userId;
        }

    }
}

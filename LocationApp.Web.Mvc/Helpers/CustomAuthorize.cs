using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocationApp.Web.Mvc.Helpers
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authroized = base.AuthorizeCore(httpContext);
            if (!authroized)
            {
                // the user is not authenticated or the forms authentication
                // cookie has expired
                return false;
            }

            // Now check the session:
            var myvar = httpContext.Session["User"];
            if (myvar == null)
            {
                // the session has expired
                return false;
            }

            return true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Session
{
    public class UserAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["Session"] != null)
            {
                return true;
            }
            else
            {
                HttpCookie mycookie = new HttpCookie("unauthorize_error", "You do not have access to requested link.");
                httpContext.Response.SetCookie(mycookie);
                httpContext.Response.Redirect("~/Login/Login");
                return false;
            }

        }
    }
}
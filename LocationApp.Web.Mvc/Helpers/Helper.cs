using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocationApp.Web.Mvc.Helpers
{
    public class Helper
    {
        public static string GetResultMessage(bool status, string message)
        {
            if (status)
                message = "<div class='alert alert-success' role='alert'>" + message + "</div>";
            else
                message = "<div class='alert alert-danger' role='alert'>" + message + "</div>";
            return message;
        }
    }
}
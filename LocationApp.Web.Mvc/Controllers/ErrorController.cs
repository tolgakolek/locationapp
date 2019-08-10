using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocationApp.Web.Mvc.Controllers
{
    public class ErrorController : BaseController
    {
        [HttpGet]
        public ActionResult NotFound()
        {
            return View();
        }
    }
}
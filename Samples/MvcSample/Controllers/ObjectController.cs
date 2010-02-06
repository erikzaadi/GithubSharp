using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace GithubSharp.Samples.MvcSample.Controllers
{
    public class ObjectController : BaseAPIController<Core.API.Object>
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}

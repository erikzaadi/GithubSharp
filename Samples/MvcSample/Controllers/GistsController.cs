using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace GithubSharp.Samples.MvcSample.Controllers
{
    public class GistsController : BaseAPIController<Core.API.Gist>
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}

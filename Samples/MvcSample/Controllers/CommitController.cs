using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace GithubSharp.Samples.MvcSample.Controllers
{
    public class CommitController : BaseAPIController<Core.API.Commits>
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}

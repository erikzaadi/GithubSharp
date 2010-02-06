using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace GithubSharp.Samples.MvcSample.Controllers
{
    public class UserController : BaseAPIController<GithubSharp.Core.API.User>
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}

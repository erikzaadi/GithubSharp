using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace GithubSharp.Samples.MvcSample.Controllers
{
    [HandleError]
    public class BaseController : Controller
    {
        public BaseController()
        {
            WebCacher = new GithubSharp.Plugins.CacheProviders.WebCache.WebCacher();
            LogProvider = new GithubSharp.Plugins.LogProviders.SimpleLogProvider.SimpleLogProvider();
        }
        public ActionResult Index()
        {
            return View(new GithubSharp.Samples.MvcSample.Models.ViewModels.BaseViewModel { CurrentUser = CurrentUser });
        }
        public GithubSharp.Core.Models.GithubUser CurrentUser
        {
            get
            {
                var user = Session != null  ? Session["GithubUser"] : null;
                return user == null ? null : user as GithubSharp.Core.Models.GithubUser;
            }
            set
            {
                Session["GithubUser"] = value;
            }
        }
        public GithubSharp.Plugins.CacheProviders.WebCache.WebCacher WebCacher { get; set; }
        public GithubSharp.Plugins.LogProviders.SimpleLogProvider.SimpleLogProvider LogProvider { get; set; }
    }
}

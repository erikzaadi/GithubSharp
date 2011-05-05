using System;
using System.Web.Mvc;
using GithubSharp.Core.Services;
using GithubSharp.Samples.MvcSample.MvcApplication.Models.ViewModels;

namespace GithubSharp.MvcSample.MvcApplication.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ICacheProvider Cache, ILogProvider Log)
            : base(Cache, Log)
        {
        }

        public ActionResult Login(string Id)
        {
            var model = new LoginViewModel { ReturnURL = Id };
            if (Request.IsAjaxRequest())
                return PartialView("LoginControl", model);
            return View(GetBaseView(model));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Login (string user, string Apitoken, string ReturnURL)
        {
        	var userAPI = new Core.API.User (CacheProvider, LogProvider);
        	userAPI.Authenticate (new Core.Models.GithubUser { Name = user, APIToken = Apitoken });
        	try
            {
        		var privateuser = userAPI.Get ();
        		if (privateuser == null)
        			throw new Exception ("Invalid user");

                CurrentUser = new Core.Models.GithubUser { Name = user, APIToken = Apitoken };

                SetTemporaryNotification ("Login succeded");

                if (Request.IsAjaxRequest ())
        			return Json (new { success = true, Name = user });
        		if (string.IsNullOrEmpty (ReturnURL))
        			return View ("Index");
        		return Redirect (ReturnURL);
        	}
            catch (Exception error)
            {
        		if (Request.IsAjaxRequest ())
        			return Json (new { success = false, message = error.Message });
        		return View (GetBaseView (new LoginViewModel { Message = error.Message, ReturnURL = ReturnURL }));
        	}
        }
		
		public ActionResult Index ()
		{
			return View();
		}
	}
}

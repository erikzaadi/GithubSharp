using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GithubSharp.Samples.MvcSample.Controllers
{
    public class HomeController : BaseController
    {
		public ActionResult Login()
		{
			return View(GetBaseView(""));
		}
		
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Login(string user, string apitoken)
		{
			var userAPI = new GithubSharp.Core.API.User(WebCacher, LogProvider);
			userAPI.Authenticate(new GithubSharp.Core.Models.GithubUser { Name=user, APIToken = apitoken});
			try
			{
				var privateuser = userAPI.Get();
				if (privateuser != null)
				{
					CurrentUser = new GithubSharp.Core.Models.GithubUser { Name = user, APIToken = apitoken } ;
			
					if (Request.IsAjaxRequest())
						return Json(new{ success = true});
					return View("Index",GetBaseView(""));
				}
				else throw new Exception("Invalid user");
			}
			catch (Exception error)
			{
				if (Request.IsAjaxRequest())
					return Json(new{ success = false, message = error.Message});
				return View(new Models.ViewModels.BaseViewModel<string> { CurrentUser = CurrentUser, ModelParameter = error.Message});
			}

		}
    }
}

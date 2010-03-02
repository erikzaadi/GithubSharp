
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace GithubSharp.Samples.MvcSample.MvcApplication.Controllers
{
	public class BaseAPIController<ApiType> : BaseController where ApiType : Core.Base.IBaseAPI, new()
	{
		public BaseAPIController():base()
		{
			BaseAPI = new ApiType { CacheProvider = new GithubSharp.Plugins.CacheProviders.WebCache.WebCacher(), LogProvider = new GithubSharp.Plugins.LogProviders.SimpleLogProvider.SimpleLogProvider() };
		}
		
        protected ApiType BaseAPI { get; set; }
		protected override void OnActionExecuting (ActionExecutingContext filterContext)
		{
			BaseAPI.Authenticate(CurrentUser);
			base.OnActionExecuting (filterContext);
		}

		protected bool Authenticate()
		{
			var userAPI = new GithubSharp.Core.API.User { CacheProvider= WebCacher, LogProvider= LogProvider};
			userAPI.Authenticate(CurrentUser);
			try
			{
				return userAPI.Get() != null;
			}
			catch (Exception error)
			{
				if (LogProvider.HandleAndReturnIfToThrowError(error))
					throw error;
				return false;
			}
		}

	}
}

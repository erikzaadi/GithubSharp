
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace GithubSharp.Samples.MvcSample.Controllers
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
			if (BaseAPI != null)
				BaseAPI.Authenticate(CurrentUser);
			base.OnActionExecuting (filterContext);
		}

	}
}

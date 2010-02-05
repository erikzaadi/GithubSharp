using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace GithubSharp.Samples.MvcSample.Controllers
{
    [HandleError]
    public class BaseController: Controller 
    {
		public BaseController()
        {
            WebCacher = new GithubSharp.Plugins.CacheProviders.WebCache.WebCacher();
            LogProvider = new GithubSharp.Plugins.LogProviders.SimpleLogProvider.SimpleLogProvider { DebugMode = true };
        }
		
        protected GithubSharp.Core.Models.GithubUser CurrentUser
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
        protected GithubSharp.Plugins.CacheProviders.WebCache.WebCacher WebCacher { get; set; }
        protected GithubSharp.Plugins.LogProviders.SimpleLogProvider.SimpleLogProvider LogProvider { get; set; }
		protected Models.ViewModels.BaseViewModel<T> GetBaseView<T>(T ModelParam) where T : class
		{
			return new GithubSharp.Samples.MvcSample.Models.ViewModels.BaseViewModel<T> { CurrentUser = CurrentUser, ModelParameter = ModelParam };
		}
		
		
    }
}

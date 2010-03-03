
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using GithubSharp.Core.Services;

namespace GithubSharp.Samples.MvcSample.MvcApplication.Controllers
{
    public class BaseAPIController<ApiType> : BaseController where ApiType : Core.Base.IBaseAPI
    {
        public BaseAPIController(ICacheProvider cacheProvider, ILogProvider logProvider)
            : base(cacheProvider, logProvider)
        {
        }

        protected virtual ApiType BaseAPI { get; set; }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            BaseAPI.Authenticate(CurrentUser);
            base.OnActionExecuting(filterContext);
        }

        protected virtual bool Authenticate()
        {
            var userAPI = new GithubSharp.Core.API.User(CacheProvider, LogProvider);
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

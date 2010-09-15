using System;
using System.Web.Mvc;
using GithubSharp.Core.Services;

namespace GithubSharp.MvcSample.MvcApplication.Controllers
{
    public class BaseAPIController<TApiType> : BaseController where TApiType : Core.Base.IBaseAPI
    {
        public BaseAPIController(ICacheProvider Cache, ILogProvider Log)
            : base(Cache, Log)
        {
        }

        protected virtual TApiType BaseAPI { get; set; }
        protected override void OnActionExecuting(ActionExecutingContext FilterContext)
        {
            BaseAPI.Authenticate(CurrentUser);
            base.OnActionExecuting(FilterContext);
        }

        protected virtual bool Authenticate()
        {
            var userAPI = new Core.API.User(CacheProvider, LogProvider);
            userAPI.Authenticate(CurrentUser);
            try
            {
                return userAPI.Get() != null;
            }
            catch (Exception error)
            {
                if (LogProvider.HandleAndReturnIfToThrowError(error))
                    throw;
                return false;
            }
        }
    }
}

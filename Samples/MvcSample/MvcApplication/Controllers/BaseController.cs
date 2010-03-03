using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using GithubSharp.Core.Services;

namespace GithubSharp.Samples.MvcSample.MvcApplication.Controllers
{
    [HandleError]
    public class BaseController : Controller
    {
        public BaseController(ICacheProvider cacheProvider, ILogProvider logProvider)
        {
            CacheProvider = cacheProvider;
            LogProvider = logProvider;
        }

        protected GithubSharp.Core.Models.GithubUser CurrentUser
        {
            get
            {
                var user = Session != null ? Session["GithubUser"] : null;
                return user == null ? null : user as GithubSharp.Core.Models.GithubUser;
            }
            set
            {
                Session["GithubUser"] = value;
            }
        }

        protected ICacheProvider CacheProvider { get; set; }

        protected ILogProvider LogProvider { get; set; }

        protected void SetTemporaryNotification(string Notification, params object[] args)
        {
            TempData["Notification"] = string.Format(Notification, args);
        }

        protected Models.ViewModels.IBaseViewModel GetIBaseView(string Notification)
        {
            return GetBaseView<string>(null, Notification);
        }

        protected Models.ViewModels.BaseViewModel<T> GetBaseView<T>(T ModelParam) where T : class
        {
            return GetBaseView<T>(ModelParam, null);
        }

        protected Models.ViewModels.BaseViewModel<T> GetBaseView<T>(T ModelParam, string Notification) where T : class
        {
            return new GithubSharp.Samples.MvcSample.MvcApplication.Models.ViewModels.BaseViewModel<T>
            {
                CurrentUser = CurrentUser,
                ModelParameter = ModelParam,
                Notification = Notification ?? (TempData.ContainsKey("Notification") ? TempData["Notification"].ToString() : string.Empty)
            };
        }

        protected override ViewResult View(IView view, object model)
        {
            if (model == null)
                model = GetBaseView("");
            return base.View(view, model);
        }

        protected override ViewResult View(string viewName, string masterName, object model)
        {
            if (model == null)
                model = GetBaseView("");
            return base.View(viewName, masterName, model);
        }


     
    }
}

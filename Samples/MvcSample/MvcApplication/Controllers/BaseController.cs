using System.Web.Mvc;
using GithubSharp.Core.Services;
using GithubSharp.MvcSample.MvcApplication.Models.ViewModels;

namespace GithubSharp.MvcSample.MvcApplication.Controllers
{
    [HandleError]
    public class BaseController : Controller
    {
        public BaseController(ICacheProvider Cache, ILogProvider Log)
        {
            CacheProvider = Cache;
            LogProvider = Log;
        }

        protected Core.Models.GithubUser CurrentUser
        {
            get
            {
                var user = Session != null ? Session["GithubUser"] : null;
                return user == null ? null : user as Core.Models.GithubUser;
            }
            set
            {
                Session["GithubUser"] = value;
            }
        }

        protected ICacheProvider CacheProvider { get; set; }

        protected ILogProvider LogProvider { get; set; }

        protected void SetTemporaryNotification(string Notification, params object[] Args)
        {
            TempData["Notification"] = string.Format(Notification, Args);
        }

        protected IBaseViewModel GetIBaseView(string Notification)
        {
            return GetBaseView<string>(null, Notification);
        }

        protected BaseViewModel<T> GetBaseView<T>(T ModelParam) where T : class
        {
            return GetBaseView(ModelParam, null);
        }

        protected BaseViewModel<T> GetBaseView<T>(T ModelParam, string Notification) where T : class
        {
            return new BaseViewModel<T>
            {
                CurrentUser = CurrentUser,
                ModelParameter = ModelParam,
                Notification = Notification ?? (TempData.ContainsKey("Notification") ? TempData["Notification"].ToString() : string.Empty)
            };
        }

        protected override ViewResult View(IView ViewName, object Model)
        {
            if (Model == null)
                Model = GetBaseView("");
            return base.View(ViewName, Model);
        }

        protected override ViewResult View(string ViewName, string MasterName, object Model)
        {
            if (Model == null)
                Model = GetBaseView("");
            return base.View(ViewName, MasterName, Model);
        }


     
    }
}

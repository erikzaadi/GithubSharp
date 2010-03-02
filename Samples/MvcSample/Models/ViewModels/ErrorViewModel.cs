
using System;
using System.Collections.Generic;

namespace GithubSharp.Samples.MvcSample.Models.ViewModels
{
    public class ErrorViewModel : System.Web.Mvc.HandleErrorInfo, IBaseViewModel
    {
        #region IBaseViewModel implementation
        public GithubSharp.Core.Models.GithubUser CurrentUser
        {
            get
            {
                var user = System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Session != null ? System.Web.HttpContext.Current.Session["GithubUser"] : null;
                return user == null ? null : user as GithubSharp.Core.Models.GithubUser;
            }
            set
            {
                System.Web.HttpContext.Current.Session["GithubUser"] = value;
            }
        }

        public string Notification { get; set; }

        #endregion
        public ErrorViewModel(Exception exception, string controller, string action) : base(exception, controller, action)
        {
            ReleaseScripts = new List<IncludeItem>();
            ReleaseStyleSheets = new List<IncludeItem>();
            DebugScripts = new List<IncludeItem>();
            DebugStyleSheets = new List<IncludeItem>();
            DocumentReadies = new List<string>();
        }


        public System.Collections.Generic.List<IncludeItem> ReleaseScripts
        {
            get;set;
        }

        public System.Collections.Generic.List<IncludeItem> ReleaseStyleSheets
        {
            get;
            set;
        }

        public System.Collections.Generic.List<IncludeItem> DebugScripts
        {
            get;
            set;
        }

        public System.Collections.Generic.List<IncludeItem> DebugStyleSheets
        {
            get;
            set;
        }


        public List<string> DocumentReadies
        {
            get;
            set;
        }
    }
}

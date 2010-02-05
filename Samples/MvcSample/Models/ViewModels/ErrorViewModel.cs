
using System;

namespace GithubSharp.Samples.MvcSample.Models.ViewModels
{
	public class ErrorViewModel : System.Web.Mvc.HandleErrorInfo, IBaseViewModel 
	{
		#region IBaseViewModel implementation
		public GithubSharp.Core.Models.GithubUser CurrentUser {
		 	get
            {
                var user = System.Web.HttpContext.Current != null &&  System.Web.HttpContext.Current.Session != null  ? System.Web.HttpContext.Current.Session["GithubUser"] : null;
                return user == null ? null : user as GithubSharp.Core.Models.GithubUser;
            }
            set
            {
                System.Web.HttpContext.Current.Session["GithubUser"] = value;
            }
		}
		
		#endregion
		public ErrorViewModel(Exception exception, string controller, string action):base(exception, controller, action){}
	}
}

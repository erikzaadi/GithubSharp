using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GithubSharp.Samples.MvcSample.Models.ViewModels
{
    public class BaseViewModel<T> : IBaseViewModel where T : class
    {
        public GithubSharp.Core.Models.GithubUser CurrentUser { get; set; }
        public T ModelParameter { get; set; }
        public string Notification { get; set; }
    }
	
	public interface IBaseViewModel
	{
		GithubSharp.Core.Models.GithubUser CurrentUser { get; set; }
        string Notification { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GithubSharp.Samples.MvcSample.MvcApplication.Models.ViewModels
{
    public class BaseViewModel<T> : IBaseViewModel where T : class
    {
        public BaseViewModel()
        {
            ReleaseScripts = new List<IncludeItem>();
            ReleaseStyleSheets = new List<IncludeItem>();
            DebugScripts = new List<IncludeItem>();
            DebugStyleSheets = new List<IncludeItem>();
            DocumentReadies = new List<string>();
        }
        public GithubSharp.Core.Models.GithubUser CurrentUser { get; set; }
        public T ModelParameter { get; set; }
        public string Notification { get; set; }
        public List<IncludeItem> ReleaseScripts { get; set; }
        public List<IncludeItem> ReleaseStyleSheets { get; set; }
        public List<IncludeItem> DebugScripts { get; set; }
        public List<IncludeItem> DebugStyleSheets { get; set; }
        public List<string> DocumentReadies { get; set; }
    }
	
	public interface IBaseViewModel
	{
		GithubSharp.Core.Models.GithubUser CurrentUser { get; set; }
        string Notification { get; set; }        
        List<IncludeItem> ReleaseScripts { get; set; }
        List<IncludeItem> ReleaseStyleSheets { get; set; }
        List<IncludeItem> DebugScripts { get; set; }
        List<IncludeItem> DebugStyleSheets { get; set; }
        List<string> DocumentReadies { get; set; }
    }

    public class IncludeItem
    {
        public string Source { get; set; }
        public string CDN { get; set; }
    }
}

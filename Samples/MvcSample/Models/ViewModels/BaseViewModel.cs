using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GithubSharp.Samples.MvcSample.Models.ViewModels
{
    public class BaseViewModel
    {
        public GithubSharp.Core.Models.GithubUser CurrentUser { get; set; }
    }
}

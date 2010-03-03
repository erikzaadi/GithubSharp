using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using GithubSharp.Core.Services;

namespace GithubSharp.Samples.MvcSample.MvcApplication.Controllers
{
    public class IssuesController : BaseAPIController<Core.API.Issues>
    {
        public IssuesController(ICacheProvider cacheProvider, ILogProvider logProvider)
            : base(cacheProvider, logProvider)
        {
            BaseAPI = new GithubSharp.Core.API.Issues(cacheProvider, logProvider);
        }
    }
}

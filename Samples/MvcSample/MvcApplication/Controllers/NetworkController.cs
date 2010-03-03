using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using GithubSharp.Core.Services;

namespace GithubSharp.Samples.MvcSample.MvcApplication.Controllers
{
    public class NetworkController : BaseAPIController<Core.API.Network>
    {
        public NetworkController(ICacheProvider cacheProvider, ILogProvider logProvider)
            : base(cacheProvider, logProvider)
        {
            BaseAPI = new GithubSharp.Core.API.Network(cacheProvider, logProvider);
        }
    }
}

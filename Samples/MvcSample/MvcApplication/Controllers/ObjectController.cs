using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using GithubSharp.Core.Services;

namespace GithubSharp.Samples.MvcSample.MvcApplication.Controllers
{
    public class ObjectController : BaseAPIController<Core.API.Object>
    {
        public ObjectController(ICacheProvider cacheProvider, ILogProvider logProvider)
            : base(cacheProvider, logProvider)
        {
            BaseAPI = new GithubSharp.Core.API.Object(cacheProvider, logProvider);
        }
    }
}

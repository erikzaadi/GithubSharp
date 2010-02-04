using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace GithubSharp.Samples.MvcSample.Controllers
{
    public class RepositoryController : BaseController
    {
        public GithubSharp.Core.API.Repository Repository { get; set; }
        public RepositoryController()
            : base()
        {
            Repository = new GithubSharp.Core.API.Repository(WebCacher, LogProvider);
            Repository.Authenticate(CurrentUser);
        }

        public ActionResult Search(string id)
        {
            var repos = Repository.Search(id);
            return View("Index", repos);
        }

        public ActionResult Get(string RepositoryName, string Username)
        {
            var repo = Repository.Get(Username, RepositoryName);
            return View(repo);
        }

        public ActionResult List(string id)
        {
            var repos = Repository.List(id);

            return View(repos);
        }
    }
}

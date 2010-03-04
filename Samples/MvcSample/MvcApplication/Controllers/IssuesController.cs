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



        public ActionResult Search(string id, string Username, string RepositoryName, string State)
        {
            var state = State == "open" ? GithubSharp.Core.Models.IssueState.open : Core.Models.IssueState.closed;

            var issues = BaseAPI.Search(RepositoryName, Username, state, id);

            return View("List", GetBaseView(issues));
        }

        public ActionResult List(string Username, string RepositoryName, string State)
        {
            var state = State == "open" ? GithubSharp.Core.Models.IssueState.open : Core.Models.IssueState.closed;

            var issues = BaseAPI.List(RepositoryName, Username, state);

            return View("List", GetBaseView(issues));
        }

        public ActionResult View(string Username, string RepositoryName, int id)
        {
            var issue = BaseAPI.View(RepositoryName, Username, id);

            return View(GetBaseView(issue));
        }

        public ActionResult Labels(string Username, string RepositoryName)
        {
            var labels = BaseAPI.Labels(RepositoryName, Username);

            return View(GetBaseView(labels));
        }

        public ActionResult Comments(string Username, string RepositoryName, int id)
        {
            var comments = BaseAPI.Comments(RepositoryName, Username, id);

            return View(GetBaseView(comments));
        }
    }
}

using System.Collections.Generic;
using System.Web.Mvc;
using GithubSharp.Core.API;
using GithubSharp.Core.Models;
using GithubSharp.Core.Services;

namespace GithubSharp.MvcSample.MvcApplication.Controllers
{
    public sealed class IssuesController : BaseAPIController<Issues>
    {
        public IssuesController(ICacheProvider Cache, ILogProvider Log)
            : base(Cache, Log)
        {
            BaseAPI = new Issues(Cache, Log);
        }

        public ActionResult Search(string Id, string Username, string RepositoryName, string State)
        {
            IssueState state = State == "open" ? IssueState.Open : IssueState.Closed;
            IEnumerable<Issue> issues = BaseAPI.Search(RepositoryName, Username, state, Id);

            return View("List", GetBaseView(issues));
        }

        public ActionResult List(string Username, string RepositoryName, string State)
        {
            IssueState state = State == "open" ? IssueState.Open : IssueState.Closed;
            IEnumerable<Issue> issues = BaseAPI.List(RepositoryName, Username, state);

            return View("List", GetBaseView(issues));
        }

        public ActionResult View(string Username, string RepositoryName, int Id)
        {
            Issue issue = BaseAPI.View(RepositoryName, Username, Id);

            return View(GetBaseView(issue));
        }

        public ActionResult Labels(string Username, string RepositoryName)
        {
            string[] labels = BaseAPI.Labels(RepositoryName, Username);

            return View(GetBaseView(labels));
        }

        public ActionResult Comments(string Username, string RepositoryName, int Id)
        {
            IEnumerable<Comment> comments = BaseAPI.Comments(RepositoryName, Username, Id);

            return View(GetBaseView(comments));
        }
    }
}
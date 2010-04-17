using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using GithubSharp.Core.Services;

namespace GithubSharp.Samples.MvcSample.MvcApplication.Controllers
{
    public class CommitController : BaseAPIController<Core.API.Commits>
    {
        public CommitController(ICacheProvider cacheProvider, ILogProvider logProvider)
            : base(cacheProvider, logProvider)
        {
            BaseAPI = new GithubSharp.Core.API.Commits(cacheProvider, logProvider);
        }

        public ActionResult CommitsForBranch(
            string Username,
            string RepositoryName,
            string BranchName)
        {
            var commits = BaseAPI.CommitsForBranch(
                Username,
                RepositoryName,
                BranchName);

            return View("Commits", GetBaseView(commits));
        }

        public ActionResult CommitsForFile(
            string Username,
            string RepositoryName,
            string BranchName,
            string FilePath)
        {
            var commits = BaseAPI.CommitsForFile(
                Username,
                RepositoryName,
                BranchName,
                FilePath);

            return View("Commits", GetBaseView(commits));
        }

        public ActionResult CommitForSingleFile(
            string Username,
            string RepositoryName,
            string Sha)
        {
            var commit = BaseAPI.CommitForSingleFile(
                Username,
                RepositoryName,
                Sha);

            return View("Commit", GetBaseView(commit));
        }
    }
}

using System.Web.Mvc;
using GithubSharp.Core.Services;

namespace GithubSharp.MvcSample.MvcApplication.Controllers
{
    public sealed class CommitController : BaseAPIController<Core.API.Commits>
    {
        public CommitController(ICacheProvider Cache, ILogProvider Log)
            : base(Cache, Log)
        {
            BaseAPI = new Core.API.Commits(Cache, Log);
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace GithubSharp.Samples.MVC.Controllers
{
	[HandleError()]
	public class HomeController : Controller
	{
		private GithubSharp.Core.Github _Github;
		public HomeController()
		{
			_Github = new GithubSharp.Core.Github(new GithubSharp.Plugins.CacheProviders.WebCache.WebCacher(), "");
		}
		
		public ActionResult Index()
		{
			return View("Index");
		}
		
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult SetUser(string id)
		{
			_Github.Username = id;
			var repos = _Github.GetRepositories();
			if (repos==null || repos.Count == 0)
			{
				object model = "Invalid user";
				return View("Index", model);
			}
			Session["username"] = id;
			//if (Request.UrlReferrer.ToString().ToLower().EndsWith("index"))
				return RedirectToAction("List");
			//else
				//return Redirect(Request.UrlReferrer.ToString());
		}
		
		public ActionResult List()
		{
			if (!_CheckUser())
			{
				object modelError = "Please login with a valid Github User";
				return View("Index", modelError);
			}
			var model = _Github.GetRepositories();
			return View (model);
		}
		
		public ActionResult Repository(string id)
		{
			if (!_CheckUser())
			{
				object modelError = "Please login with a valid Github User";
				return View("Index", modelError);
			}
			var repo = _Github.GetRepository(id);
			
			return View(repo);
		}
		
		public ActionResult RepositoryFile(string id, string file)
		{
			if (!_CheckUser())
			{
				object modelError = "Please login with a valid Github User";
				return View("Index", modelError);
			}
			var repo = _Github.GetFileContent(id, file);
			
			return Content(repo ?? string.Format("'{0}' was not found for the project '{1}'..", file, id));
		}
		
		public ActionResult Commits(string id)
		{
			if (!_CheckUser())
			{
				object modelError = "Please login with a valid Github User";
				return View("Index", modelError);
			}
			
			var commits = _Github.GetCommits(id);
			
			return View(commits);
		}
		
		public ActionResult Tree(string sha, string id)
		{
			if (!_CheckUser())
			{
				object modelError = "Please login with a valid Github User";
				return View("Index", modelError);
			}
			if (string.IsNullOrEmpty(sha))
			{
				var commits = _Github.GetCommits(id);
				var latest = commits.FirstOrDefault();
				sha = latest.Tree;
			}
			
			var tree = _Github.GetTree(id, sha);
			
			return View(tree);
		}
		
		public ActionResult Blob(string sha, string id)
		{
			if (!_CheckUser())
			{
				object modelError = "Please login with a valid Github User";
				return View("Index", modelError);
			}
			
			var bytes = _Github.GetBlobBinaryContent(id, sha);
			
			return new FileContentResult(bytes, "unknown/unknown");
		}
		
		private bool _CheckUser()
		{
			if (!string.IsNullOrEmpty(_Github.Username))
				return true;
			if (Session["username"] != null)
			{
				_Github.Username = Session["username"].ToString();
				return true;
			}
			return false;
		}
	}
}

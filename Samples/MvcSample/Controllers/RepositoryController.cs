using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace GithubSharp.Samples.MvcSample.Controllers
{
    public class RepositoryController : BaseAPIController<GithubSharp.Core.API.Repository>
    {
		public ActionResult Index()
		{
			return View("Search",GetBaseView<IEnumerable<GithubSharp.Core.Models.RepositoryFromSearch>>(new List<GithubSharp.Core.Models.RepositoryFromSearch>()));
		}
		
        public ActionResult Search(string id)
        {
            var repos = BaseAPI.Search(id);
            return View(GetBaseView(repos));
        }

        public ActionResult Get(string RepositoryName, string Username)
        {
            var repo = BaseAPI.Get(Username, RepositoryName);
            return View(GetBaseView(repo));
        }

        public ActionResult List(string id)
        {
            var repos = BaseAPI.List(id);

            return View(GetBaseView(repos));
        }
		
		public ActionResult Fork(string RepositoryName , string Username)
		{
			if (!Authenticate())
				return View("Login", 
				            GetBaseView(new Models.ViewModels.LoginViewModel 
				                        {
											Message= "You need to authenticate before being able to fork a project", 
											ReturnURL = Url.Action("Fork","Repository", new {RepositoryName = RepositoryName , Username = Username})
										}));
			var repo = BaseAPI.Fork(Username, RepositoryName);
			
			return View("Get", GetBaseView(repo));
		}
		
		public ActionResult Watch(string RepositoryName , string Username)
		{
			if (!Authenticate())
				return View("Login", GetBaseView("You need to authenticate before being able to watch a project"));
			var repo = BaseAPI.Watch(Username, RepositoryName);
			
			return View("Get", GetBaseView(repo));
		}
		
		public ActionResult Unwatch(string RepositoryName , string Username)
		{
			if (!Authenticate())
				return View("Login", GetBaseView("You need to authenticate before being able to unwatch a project"));
			var repo = BaseAPI.Unwatch(Username, RepositoryName);
			
			return View("Get", GetBaseView(repo));
		}
		
		public ActionResult Create()
		{
			if (!Authenticate())
				return View("Login", GetBaseView("You need to authenticate before being able to create a project"));
		
			return View(GetBaseView(""));
		}
		
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Create(string RepositoryName, string Description, string HomePage, bool Public)
		{
			if (!Authenticate())
				return View("Login", GetBaseView("You need to authenticate before being able to create a project"));
		
			var repo = BaseAPI.Create(RepositoryName, Description, HomePage, Public);
			
			return View("Get", GetBaseView(repo));
		}
    }
}

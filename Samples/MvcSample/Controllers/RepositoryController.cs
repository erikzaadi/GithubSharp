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
    }
}

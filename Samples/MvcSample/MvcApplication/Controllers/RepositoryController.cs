using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using GithubSharp.Core.Services;

namespace GithubSharp.Samples.MvcSample.MvcApplication.Controllers
{
    public class RepositoryController : BaseAPIController<Core.API.Repository>
    {
        public RepositoryController(ICacheProvider cacheProvider, ILogProvider logProvider)
            : base(cacheProvider, logProvider)
        {
            BaseAPI = new GithubSharp.Core.API.Repository(cacheProvider, logProvider);
        }

        public ActionResult Index()
        {
            return View("Search", GetBaseView<IEnumerable<GithubSharp.Core.Models.RepositoryFromSearch>>(new List<GithubSharp.Core.Models.RepositoryFromSearch>()));
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

        public ActionResult Fork(string RepositoryName, string Username)
        {
            if (!Authenticate())
                return View("Login",
                            GetBaseView(new Models.ViewModels.LoginViewModel
                                        {
                                            Message = "You need to authenticate before being able to fork a project",
                                            ReturnURL = Url.Action("Fork", "Repository", new { RepositoryName = RepositoryName, Username = Username })
                                        }));
            var repo = BaseAPI.Fork(Username, RepositoryName);

            return View("Get", GetBaseView(repo));
        }

        public ActionResult Watch(string RepositoryName, string Username)
        {
            if (!Authenticate())
                return View("Login", GetBaseView("You need to authenticate before being able to watch a project"));
            var repo = BaseAPI.Watch(Username, RepositoryName);

            return View("Get", GetBaseView(repo));
        }

        public ActionResult Unwatch(string RepositoryName, string Username)
        {
            if (!Authenticate())
                return View("Login", GetBaseView("You need to authenticate before being able to unwatch a project"));
            var repo = BaseAPI.Unwatch(Username, RepositoryName);

            return View("Get", GetBaseView(repo));
        }

        public ActionResult Create()
        {
            if (!Authenticate())
                return View("Login", GetBaseView(new Models.ViewModels.LoginViewModel
                {
                    Message = "You need to authenticate before being able to create a project",
                    ReturnURL = Url.Action("Create", "Repository")
                }));

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(string RepositoryName, string Description, string HomePage, bool Public)
        {
            if (!Authenticate())
                return View("Login", GetBaseView(new Models.ViewModels.LoginViewModel
                {
                    Message = "You need to authenticate before being able to create a project",
                    ReturnURL = Url.Action("Create", "Repository")
                }));

            var repo = BaseAPI.Create(RepositoryName, Description, HomePage, Public);

            return RedirectToAction("Get", new { RepositoryName = repo.name, Username = repo.owner });
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Delete(string RepositoryName)
        {
            if (!Authenticate())
                return View("Login", GetBaseView(new Models.ViewModels.LoginViewModel
                {
                    Message = "You need to authenticate before being able to delete a project",
                    ReturnURL = Url.Action("Delete", "Repository", new { RepositoryName = RepositoryName })
                }));

            return View(GetBaseView(RepositoryName));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(string RepositoryName, bool Delete)
        {
            if (!Authenticate())
                return View("Login", GetBaseView(new Models.ViewModels.LoginViewModel
                {
                    Message = "You need to authenticate before being able to create a project",
                    ReturnURL = Url.Action("Delete", "Repository", new { RepositoryName = RepositoryName })
                }));

            if (!Delete)
            {
                SetTemporaryNotification("Repository '{0}' was not deleted", RepositoryName);

                return RedirectToAction("Index");
            }
            var success = BaseAPI.Delete(RepositoryName);

            SetTemporaryNotification("Repository '{0}' was {1}deleted", RepositoryName, success ? string.Empty : "not ");

            return RedirectToAction("Index");
        }

        public ActionResult PublicKeys(string RepositoryName)
        {
            if (!Authenticate())
                return View("Login", GetBaseView(new Models.ViewModels.LoginViewModel
                {
                    Message = "You need to authenticate before being able to view public keys for a project",
                    ReturnURL = Url.Action("PublicKeys", "Repository", new { RepositoryName = RepositoryName })
                }));

            var keys = BaseAPI.PublicKeys(RepositoryName);

            return View(GetBaseView(keys));
        }

      
    }
}

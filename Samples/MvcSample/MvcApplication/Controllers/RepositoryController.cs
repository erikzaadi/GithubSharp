using System.Collections.Generic;
using System.Web.Mvc;
using GithubSharp.Core.Models;
using GithubSharp.Core.Services;
using GithubSharp.Samples.MvcSample.MvcApplication.Models.ViewModels;
using Repository = GithubSharp.Core.API.Repository;

namespace GithubSharp.MvcSample.MvcApplication.Controllers
{
    public sealed class RepositoryController : BaseAPIController<Repository>
    {
        public RepositoryController(ICacheProvider Cache, ILogProvider Log)
            : base(Cache, Log)
        {
            BaseAPI = new Repository(Cache, Log);
        }

        public ActionResult Index()
        {
            return View("Search", GetBaseView<IEnumerable<RepositoryFromSearch>>(new List<RepositoryFromSearch>()));
        }

        public ActionResult Search(string Id)
        {
            IEnumerable<RepositoryFromSearch> repos = BaseAPI.Search(Id);
            return View(GetBaseView(repos));
        }

        public ActionResult Get(string RepositoryName, string Username)
        {
            Core.Models.Repository repo = BaseAPI.Get(Username, RepositoryName);
            return View(GetBaseView(repo));
        }

        public ActionResult List(string Id)
        {
            IEnumerable<Core.Models.Repository> repos = BaseAPI.List(Id);

            return View(GetBaseView(repos));
        }

        public ActionResult Fork(string RepositoryName, string Username)
        {
            if (!Authenticate())
                return View("Login",
                            GetBaseView(new LoginViewModel
                                            {
                                                Message = "You need to authenticate before being able to fork a project",
                                                ReturnURL =
                                                    Url.Action("Fork", "Repository", new {RepositoryName, Username})
                                            }));
            Core.Models.Repository repo = BaseAPI.Fork(Username, RepositoryName);

            return View("Get", GetBaseView(repo));
        }

        public ActionResult Watch(string RepositoryName, string Username)
        {
            if (!Authenticate())
                return View("Login", GetBaseView("You need to authenticate before being able to watch a project"));
            Core.Models.Repository repo = BaseAPI.Watch(Username, RepositoryName);

            return View("Get", GetBaseView(repo));
        }

        public ActionResult Unwatch(string RepositoryName, string Username)
        {
            if (!Authenticate())
                return View("Login", GetBaseView("You need to authenticate before being able to unwatch a project"));
            Core.Models.Repository repo = BaseAPI.Unwatch(Username, RepositoryName);

            return View("Get", GetBaseView(repo));
        }

        public ActionResult Create()
        {
            if (!Authenticate())
                return View("Login", GetBaseView(new LoginViewModel
                                                     {
                                                         Message =
                                                             "You need to authenticate before being able to create a project",
                                                         ReturnURL = Url.Action("Create", "Repository")
                                                     }));

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(string RepositoryName, string Description, string HomePage, bool Public)
        {
            if (!Authenticate())
                return View("Login", GetBaseView(new LoginViewModel
                                                     {
                                                         Message =
                                                             "You need to authenticate before being able to create a project",
                                                         ReturnURL = Url.Action("Create", "Repository")
                                                     }));

            Core.Models.Repository repo = BaseAPI.Create(RepositoryName, Description, HomePage, Public);

            return RedirectToAction("Get", new {RepositoryName = repo.Name, Username = repo.Owner});
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Delete(string RepositoryName)
        {
            if (!Authenticate())
                return View("Login", GetBaseView(new LoginViewModel
                                                     {
                                                         Message =
                                                             "You need to authenticate before being able to delete a project",
                                                         ReturnURL =
                                                             Url.Action("Delete", "Repository", new {RepositoryName})
                                                     }));

            return View(GetBaseView(RepositoryName));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(string RepositoryName, bool Delete)
        {
            if (!Authenticate())
                return View("Login", GetBaseView(new LoginViewModel
                                                     {
                                                         Message =
                                                             "You need to authenticate before being able to create a project",
                                                         ReturnURL =
                                                             Url.Action("Delete", "Repository", new {RepositoryName})
                                                     }));

            if (!Delete)
            {
                SetTemporaryNotification("Repository '{0}' was not deleted", RepositoryName);

                return RedirectToAction("Index");
            }
            bool success = BaseAPI.Delete(RepositoryName);

            SetTemporaryNotification("Repository '{0}' was {1}deleted", RepositoryName, success ? string.Empty : "not ");

            return RedirectToAction("Index");
        }

        public ActionResult PublicKeys(string RepositoryName)
        {
            if (!Authenticate())
                return View("Login", GetBaseView(new LoginViewModel
                                                     {
                                                         Message =
                                                             "You need to authenticate before being able to view public keys for a project",
                                                         ReturnURL =
                                                             Url.Action("PublicKeys", "Repository", new {RepositoryName})
                                                     }));

            IEnumerable<PublicKey> keys = BaseAPI.PublicKeys(RepositoryName);

            return View(GetBaseView(keys));
        }

        public ActionResult Languages(string RepositoryName, string Username)
        {
            IEnumerable<Language> languages = BaseAPI.LanguageBreakDown(RepositoryName, Username);

            return View(GetBaseView(languages));
        }

        public ActionResult Tags(string RepositoryName, string Username)
        {
            IEnumerable<TagOrBranch> tags = BaseAPI.Tags(RepositoryName, Username);

            return View(GetBaseView(tags));
        }

        public ActionResult Branches(string RepositoryName, string Username)
        {
            IEnumerable<TagOrBranch> tags = BaseAPI.Branches(RepositoryName, Username);

            return View(GetBaseView(tags));
        }

        public ActionResult Network(string RepositoryName, string Username)
        {
            IEnumerable<Core.Models.Repository> network = BaseAPI.Network(RepositoryName, Username);

            return View(GetBaseView(network));
        }
    }
}
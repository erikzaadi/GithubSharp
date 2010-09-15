using GithubSharp.Core.Services;

namespace GithubSharp.MvcSample.MvcApplication.Controllers
{
    public sealed class UserController : BaseAPIController<Core.API.User>
    {
        public UserController(ICacheProvider Cache, ILogProvider Log)
            : base(Cache, Log)
        {
            BaseAPI = new Core.API.User(Cache, Log);
        }
    }
}

using GithubSharp.Core.Services;

namespace GithubSharp.MvcSample.MvcApplication.Controllers
{
    public sealed class ObjectController : BaseAPIController<Core.API.Object>
    {
        public ObjectController(ICacheProvider Cache, ILogProvider Log)
            : base(Cache, Log)
        {
            BaseAPI = new Core.API.Object(Cache, Log);
        }
    }
}

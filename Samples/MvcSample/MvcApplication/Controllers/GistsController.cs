using GithubSharp.Core.Services;

namespace GithubSharp.MvcSample.MvcApplication.Controllers
{
    public sealed class GistsController : BaseAPIController<Core.API.Gist>
    {
        public GistsController(ICacheProvider Cache, ILogProvider Log)
            : base(Cache, Log)
        {
            BaseAPI = new Core.API.Gist(Cache, Log);
        }
    }
}

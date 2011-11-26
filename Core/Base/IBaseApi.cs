using GithubSharp.Core.Services;

namespace GithubSharp.Core.Base
{
    public interface IBaseApi
    {
        void Authenticate();
        void Authenticate(Models.GithubUser user);
        ILogProvider LogProvider { get; set; }
        ICacheProvider CacheProvider { get; set; }
    }
}
namespace GithubSharp.Core.Base
{
    public class GithubApiBase
    {
        public GithubApiBase(
            Services.ILogProvider logProvider,
            Services.ICacheProvider cacheProvider,
            Services.IAuthProvider authProvider)
        {
            LogProvider = logProvider;
            CacheProvider = cacheProvider;
            AuthProvider = authProvider;
        }

        public Services.ILogProvider LogProvider { get; set; }
        public Services.ICacheProvider CacheProvider { get; set; }
        public Services.IAuthProvider AuthProvider { get; set; }

        protected IGithubResponse Get(
            string path,
            GithubSharpHttpVerbs method)
        {
            return new GithubRequest(
                LogProvider,
                CacheProvider,
                AuthProvider,
                path,
                method).GetResponse();
        }

        protected IGithubResponseWithReturnType<TReturnType> Get<TReturnType>(
            string path,
            GithubSharpHttpVerbs method)
            where TReturnType : class
        {
            return new GithubRequestWithReturnType<TReturnType>(
                LogProvider,
                CacheProvider,
                AuthProvider,
                path,
                method)
                .GetResponseWithReturnType();
        }

        protected IGithubResponseWithReturnType<TReturnType> Get<TReturnType, TInputType>(
            string path,
            GithubSharpHttpVerbs method,
            TInputType toSend)
            where TReturnType : class
        {
            return new GithubRequestWithInputAndReturnType<TInputType, TReturnType>(
                LogProvider,
                CacheProvider,
                AuthProvider,
                path,
                method,
                toSend)
                .GetResponseWithReturnType();
        }
    }
}


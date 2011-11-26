using System;
using GithubSharp.Core.Base;

namespace GithubSharp.Core
{
    public class GithubRequestWithReturnType<TReturnType> : GithubRequest
        where TReturnType : class
    {
        public GithubRequestWithReturnType(Services.ILogProvider logProvider,
            Services.ICacheProvider cacheProvider,
            Services.IAuthProvider authProvider,
            string path)
            : base(
                   logProvider,
                   cacheProvider,
                   authProvider,
                   path)
        {
        }

        public GithubRequestWithReturnType(Services.ILogProvider logProvider,
            Services.ICacheProvider cacheProvider,
            Services.IAuthProvider authProvider,
            string path,
            GithubSharpHttpVerbs method)
            : base(logProvider, cacheProvider, authProvider, path, method)
        {
        }

        public override bool IsCached(string uri)
        {
            return CacheProvider.IsCached<TReturnType>(uri);
        }

        public IGithubResponseWithReturnType<TReturnType> GetResponseWithReturnType()
        {
            var baseResult = base.GetResponse();
            var baseWithReturnType = new GithubResponseWithReturnType<TReturnType>
            {
                LinkNext = baseResult.LinkNext,
                LinkFirst = baseResult.LinkFirst,
                LinkLast = baseResult.LinkLast,
                LinkPrevious = baseResult.LinkPrevious,
                RateLimitLimit = baseResult.RateLimitLimit,
                RateLimitRemaining = baseResult.RateLimitRemaining,
                Response = baseResult.Response
            };

            try
            {
                baseWithReturnType.Result = JsonConverter
                    .FromJson<TReturnType>(baseWithReturnType.Response);
            }
            catch (Exception error)
            {
                if (LogProvider.HandleAndReturnIfToThrowError(error))
                    throw;
            }

            return baseWithReturnType;
        }
    }
}


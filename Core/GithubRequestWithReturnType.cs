using System;
using GithubSharp.Core.Base;

namespace GithubSharp.Core
{
	public class GithubRequestWithReturnType<TReturnType> : GithubRequest
		where TReturnType : class
	{
		public GithubRequestWithReturnType (Core.Services.ILogProvider logProvider, 
			Core.Services.ICacheProvider cacheProvider,
			Core.Services.IAuthProvider authProvider,
			string path) 
		 : base(logProvider, cacheProvider, authProvider, path)
		{
		}
		public GithubRequestWithReturnType (Core.Services.ILogProvider logProvider, 
			Core.Services.ICacheProvider cacheProvider,
			Core.Services.IAuthProvider authProvider,
			string path,
			string method) 
		 : base(logProvider, cacheProvider, authProvider, path, method)
		{
		}
		
		public override bool IsCached (string uri)
		{
			return CacheProvider.IsCached<TReturnType>(uri);
		}
		
		public new IGithubResponseWithReturnType<TReturnType> GetResponse()
		{
			var baseResult = base.GetResponse() as IGithubResponseWithReturnType<TReturnType>;
			try
            {
                baseResult.Result = JsonConverter.FromJson<TReturnType>(baseResult.Response);
            }
            catch (Exception error)
            {
                if (LogProvider.HandleAndReturnIfToThrowError(error))
                    throw;
            }
			
			return baseResult;
		}
	}
}


using System;

namespace GithubSharp.Core.Base
{
	public class GithubApiBase
	{
		public GithubApiBase (
			Services.ILogProvider logProvider,
			Services.ICacheProvider cacheProvider,
			Services.IAuthProvider authProvider)
		{
			LogProvider = logProvider;
			CacheProvider = cacheProvider;
			AuthProvider = authProvider;
		}
		
		public Services.ILogProvider LogProvider { get;set;}
		public Services.ICacheProvider CacheProvider { get;set;}
		public Services.IAuthProvider AuthProvider { get;set;}
		
		protected IGithubResponse Get(
			string Path, 
			GithubSharpHttpVerbs Method)
		{
			return new GithubRequest(
				LogProvider, 
				CacheProvider, 
				AuthProvider, 
				Path, 
				Method).GetResponse();
		}
		
		protected IGithubResponseWithReturnType<TReturnType> Get<TReturnType>(
			string Path, 
			GithubSharpHttpVerbs Method)
			where TReturnType : class
		{
			return new GithubRequestWithReturnType<TReturnType>(
				LogProvider, 
				CacheProvider, 
				AuthProvider, 
				Path, 
				Method)
				.GetResponseWithReturnType();
		}
		
		protected IGithubResponseWithReturnType<TReturnType> Get<TReturnType, TInputType>(
			string Path, 
			GithubSharpHttpVerbs Method,
			TInputType ToSend)
			where TReturnType : class
		{
			return new GithubRequestWithInputAndReturnType<TInputType, TReturnType>(
				LogProvider, 
				CacheProvider, 
				AuthProvider, 
				Path, 
				Method,
				ToSend)
				.GetResponseWithReturnType();
		}
	}
}


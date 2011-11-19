using System;
using GithubSharp.Core.Services;

namespace GithubSharp.Core
{
	public class GithubRequestWithInputAndReturnType<TInputType,TReturnType> : GithubRequestWithReturnType<TReturnType>
		where TReturnType : class
	{
		public GithubRequestWithInputAndReturnType (
			ILogProvider logProvider, 
			ICacheProvider cacheProvider,
			IAuthProvider authProvider,
			string path,
			TInputType input)
			:base(logProvider,
				cacheProvider,
				authProvider,
				path)
		{
			ModelToSend = input;
		}
		public GithubRequestWithInputAndReturnType (
			ILogProvider logProvider, 
			ICacheProvider cacheProvider,
			IAuthProvider authProvider,
			string path,
			string method,
			TInputType input)
			:base(logProvider,
				cacheProvider,
				authProvider,
				path,
				method)
		{
			ModelToSend = input;
		}
		
		public TInputType ModelToSend { get;set;}
		
			
		public override System.Net.HttpWebRequest PrepareWebRequest (System.Net.HttpWebRequest webRequest)
		{
			webRequest.ContentType  = "application/json"; //TODO Needed?
			webRequest.MediaType = "UTF-8";
			var bytes = GithubSharp.Core.Base.JsonConverter.ToJsonBytes<TInputType>
					(ModelToSend);
			
			webRequest.ContentLength = bytes.Length;
			var stream = webRequest.GetRequestStream();
			stream.Write(bytes, 0, bytes.Length);
			stream.Close();
			
			return webRequest;
		}
	}
}


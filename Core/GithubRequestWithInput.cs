using System;
using GithubSharp.Core.Services;

namespace GithubSharp.Core
{
	public class GithubRequestWithInput<TInputType> : GithubRequest
	{
		public GithubRequestWithInput (
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
		
		public GithubRequestWithInput (
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
			var toReturn = base.PrepareWebRequest (webRequest);
			
			
			GithubSharp.Core.Base.JsonConverter.ToJsonStream<TInputType>
					(ModelToSend, toReturn.GetRequestStream());
			
			
			return toReturn;
		}
	}
}


using System;

namespace GithubSharp.Core
{
	public class GithubFailedResponse : GithubResponse, IGithubResponse
	{
		public GithubFailedResponse (string uri)
		{
			FailedUri = uri;
		}
		
		public string FailedUri {
			get;
			set;
		}
	}
}


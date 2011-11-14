using System;

namespace GithubSharp.Core
{
	public class GithubAuthenticationException : Exception
	{
		public GithubAuthenticationException (string uri)
			:base(string.Format("Failed to authenticate for {0}", uri))
		{
		}
	}
}


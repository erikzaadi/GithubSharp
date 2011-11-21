using System;

namespace GithubSharp.Plugins.AuthProviders.NullAuthProvider
{
	public class NullAuthProvider : GithubSharp.Core.Services.IAuthProvider
	{
		public NullAuthProvider ()
		{
		}

		public GithubSharp.Core.Services.IAuthResponse Login ()
		{
			return new GithubSharp.Core.Services.AuthResponse 
			{
				Success = true
			};
		}

		public GithubSharp.Core.Services.IAuthResponse Logout ()
		{
			return new GithubSharp.Core.Services.AuthResponse 
			{
				Success = true
			};
		}

		public GithubSharp.Core.Services.IAuthPreRequestResponse PreRequestAuth (
			GithubSharp.Core.IGithubRequest githubRequest, 
			System.Net.HttpWebRequest webRequest)
		{
			return new GithubSharp.Core.Services.AuthPreRequestResponse
			{
				Success = true,
				WebRequest = webRequest
			};
		}
		
		public bool IsAuthenticated 
		{
			get { return true;} 
			set{ return;}
		}
		
		
		public string PrepareUri(string uri)
		{
			return uri;
		}

		public string GetToken ()
		{
			return string.Empty;
		}

		public void RestoreFromToken (string token)
		{
			
		}
		
		public string Username {get;set;}
	}
}


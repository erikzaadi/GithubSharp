using System;

namespace GithubSharp.Plugins.AuthProviders.UserPasswordAuthProvider
{
	public class UserPasswordAuthProvider : GithubSharp.Core.Services.IAuthProvider
	{
		public string Password {
			get;
			set;
		}
		
		public UserPasswordAuthProvider (string Token)
		{
			this.RestoreFromToken(Token);
		}
		
		public UserPasswordAuthProvider (string user, string password)
		{
			Username = user;
			Password = password;
			IsAuthenticated = true;
		}
		
		public GithubSharp.Core.Services.IAuthResponse Login ()
		{
			//Make a request to test the login?
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
			var authInfo = string.Format("{0}:{1}",Username,  Password);
			authInfo = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(authInfo));
			webRequest.Headers["Authorization"] = "Basic " + authInfo;
			return new GithubSharp.Core.Services.AuthPreRequestResponse
			{
				Success = true,
				WebRequest = webRequest
			};
		}
		
		public string PrepareUri(string uri)
		{
			return uri;
		}

		public string GetToken ()
		{
			//TODO : Hash details here?
			return string.Empty;
		}

		public void RestoreFromToken (string token)
		{
			//TODO : Unhash details here?
		}
	
		public bool IsAuthenticated {get;set;}
		public string Username {get;set;}
		
	}
}


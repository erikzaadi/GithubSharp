using System;

namespace GithubSharp.Core.Services
{
	public interface IAuthProvider
	{
		IAuthResponse Login();
		IAuthResponse Logout();
		IAuthPreRequestResponse PreRequestAuth(
			IGithubRequest githubRequest, 
			System.Net.HttpWebRequest webRequest);
		string GetToken();
		void RestoreFromToken(string token);
	}
	
	public interface IAuthResponse
	{
		bool Success { get;set;}
		string Message {get;set;}
	}
	
	public class AuthResponse : IAuthResponse
	{
		public bool Success { get;set;}
		public string Message {get;set;}
	}
	
	public interface IAuthPreRequestResponse : IAuthResponse
	{
		System.Net.HttpWebRequest WebRequest {
			get;
			set;
		}
	}
	
	public class AuthPreRequestResponse : AuthResponse, IAuthPreRequestResponse
	{
		public	System.Net.HttpWebRequest WebRequest {
			get;
			set;
		}
	}
}


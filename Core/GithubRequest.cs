using System;
using GithubSharp.Core.Base;

namespace GithubSharp.Core
{
	public interface IGithubRequest
	{
		GithubSharpHttpVerbs Method { get;}
		string Path {get;set;}
		IGithubResponse GetResponse();
		Core.Services.ILogProvider LogProvider {get;set;}
		Core.Services.IAuthProvider AuthProvider {get;set;}
		Core.Services.ICacheProvider CacheProvider {get;set;}
		int? PagingRequestAmount {get;set;}
		int? PagingCurrentPage {get;set;}
		System.Net.HttpWebRequest PrepareWebRequest(System.Net.HttpWebRequest webRequest);
		GithubSharpMimeTypes GithubSharpMimeType {get;set;}
	}
	
	
	public class GithubRequest : IGithubRequest
	{
		public Core.Services.ILogProvider LogProvider {get;set;}
		public Core.Services.IAuthProvider AuthProvider {get;set;}
		public Core.Services.ICacheProvider CacheProvider {get;set;}
		public virtual GithubSharpHttpVerbs Method { get;set; 	}
		public virtual string Path { 	get;set; }
		public virtual int? PagingRequestAmount { get;set; }
		public virtual int? PagingCurrentPage { get;set; }
		public virtual GithubSharpMimeTypes GithubSharpMimeType {get;set;}
		
		public GithubRequest(
				Core.Services.ILogProvider logProvider,
				Core.Services.ICacheProvider cacheProvider,
				Core.Services.IAuthProvider authProvider,
				string path)
			:this(
				logProvider, 
				cacheProvider, 
				authProvider, 
				path, 
				GithubSharpHttpVerbs.GET)
		{
		}
		
		public GithubRequest(
				Core.Services.ILogProvider logProvider,
				Core.Services.ICacheProvider cacheProvider,
				Core.Services.IAuthProvider authProvider,
				string path,
				GithubSharpHttpVerbs method)
			:this(
				logProvider,
				cacheProvider,
				authProvider,
				path,
				method,
				null,
				null)
		{
			
		}
		
		
		public GithubRequest(
				Core.Services.ILogProvider logProvider,
				Core.Services.ICacheProvider cacheProvider,
				Core.Services.IAuthProvider authProvider,
				string path,
				GithubSharpHttpVerbs method, 
				int? pagingLimit,
				int? currentPage)
			:this(
				logProvider,
				cacheProvider,
				authProvider,
				path,
				method,
				pagingLimit,
				currentPage,
				GithubSharpMimeTypes.Json
				)
		{
			
		}
		
		public GithubRequest(
				Core.Services.ILogProvider logProvider,
				Core.Services.ICacheProvider cacheProvider,
				Core.Services.IAuthProvider authProvider,
				string path,
				GithubSharpHttpVerbs method, 
				int? pagingLimit,
				int? currentPage,
				GithubSharpMimeTypes mime)
		{
			LogProvider = logProvider;
			CacheProvider = cacheProvider;
			AuthProvider = authProvider;
			Path = path;
			Method = method;
			PagingCurrentPage = currentPage;
			PagingRequestAmount = pagingLimit;
			GithubSharpMimeType = mime;
		}
		
		public virtual bool IsCached(string uri)
		{
			return CacheProvider.IsCached<IGithubResponse>(uri);
		}
		
		public virtual IGithubResponse GetFromCache(string uri)
		{
			var cached = CacheProvider.Get<IGithubResponse>(uri);
            return cached;
		}
		
		public virtual void Cache(IGithubResponse response, string uri)
		{
			CacheProvider.Set(response, uri);
		}
		
		public virtual System.Net.HttpWebRequest PrepareWebRequest(System.Net.HttpWebRequest webRequest)
		{
			webRequest.Accept = EnumHelper.ToString(GithubSharpMimeType);
			
			return webRequest;
		}
		
		//Hack for mono
		public static bool Validator (object sender, 
			System.Security.Cryptography.X509Certificates.X509Certificate certificate, 
			System.Security.Cryptography.X509Certificates.X509Chain chain, 
			System.Net.Security.SslPolicyErrors sslPolicyErrors)
		{
			return true;
		}
		
		public string AddQueryStringToUri(string uri,
			string name,
			string val)
		{
			return string.Format("{0}{1}{2}={3}",
				uri,
				uri.Contains("?") ? "&" : "?",
				name,
				val);
		}
		
		public virtual string AddPagingToUri(string uri)
		{
			if (PagingCurrentPage.HasValue)
				uri = AddQueryStringToUri(uri, "page", PagingCurrentPage.Value.ToString());
			if (PagingRequestAmount.HasValue)
				uri = AddQueryStringToUri(uri, "per_page", PagingRequestAmount.Value.ToString());
			return uri;
		}
		
		public virtual GithubResponse ParsePagingLinks(GithubResponse response, string linkHeader)
		{
			foreach (var header in linkHeader.Split(new char [] { ',' })){
				var splitted = header.Split(new char[] { ';' });
				var link = splitted[0].Trim();
				var what = splitted[1].Trim();
				what = what.Substring(5);
				what = what.Substring(0, what.Length-1);
				link = link.Substring(1);
				link = link.Substring(0, link.Length-1);
				switch(what)
				{
					case "next" : response.LinkNext = link;break;
					case "prev" : response.LinkPrevious = link;break;
					case "first" : response.LinkFirst = link;break;
					default : response.LinkLast = link;break;
				}
			}
			return response;
		}
		
		public virtual IGithubResponse GetResponse ()
		{
			var uri = string.Format("{0}/{1}", 
				GithubSharp.Core.GithubURLs.GithubApiBaseUrl,
				Path);
			
			uri = AddPagingToUri(uri);
			
			uri = AuthProvider.PrepareUri(uri);
			
			if (IsCached(uri))
			{
            	LogProvider.LogMessage("Returning cached result for {0}", uri);
				return GetFromCache(uri) as GithubResponse;
			}
			
			//Hack for mono
			System.Net.ServicePointManager.ServerCertificateValidationCallback = Validator;
			
			var webRequest = System.Net.HttpWebRequest.Create(new Uri(uri)) as System.Net.HttpWebRequest;
			
			webRequest.Method = EnumHelper.ToString(Method);
			
			var authResult = AuthProvider.PreRequestAuth(this, webRequest);
			
			if (!authResult.Success)
			{
				var authError = new GithubAuthenticationException(uri);
				if (LogProvider.HandleAndReturnIfToThrowError(authError))
				{
					throw authError;
				}
				return new GithubFailedResponse(uri);
			}
			
			webRequest = PrepareWebRequest(authResult.WebRequest);
			
			
			try
			{
				var response = webRequest.GetResponse() as System.Net.HttpWebResponse;
				var responseToReturn = GetGithubResponseFromWebResponse(response);
				Cache(responseToReturn, uri);
				return responseToReturn;
				
			}
			catch (Exception error)
			{
				if (error is System.Net.WebException)
				{
					//Might be a valid response with 404 etc
					var webError = error as System.Net.WebException;
					var webErrorResponse = webError.Response as System.Net.HttpWebResponse;
					if (IsGithubResponse(webErrorResponse))
					{
						var responseEvenWithError = GetGithubResponseFromWebResponse(webErrorResponse);
						Cache(responseEvenWithError, uri);
						return responseEvenWithError;
					}
					var githubException = new GithubException(webErrorResponse, uri); 
					if (LogProvider.HandleAndReturnIfToThrowError(githubException))
						throw githubException;
				}
				if (LogProvider.HandleAndReturnIfToThrowError(error))
					throw;
				return new GithubFailedResponse(uri);
			}
		}
		
		public bool IsGithubResponse(System.Net.HttpWebResponse response)
		{
			return response.Headers.Count > 0 
				&& 
					!string.IsNullOrEmpty(
					response.Headers["X-RateLimit-Limit"]
						);
		}

		public GithubResponse GetGithubResponseFromWebResponse(System.Net.HttpWebResponse response)
		{
			var responseString = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd();
			var responseToReturn = new GithubResponse
				{
					RateLimitLimit = int.Parse(response.Headers["X-RateLimit-Limit"]),
					RateLimitRemaining = int.Parse(response.Headers["X-RateLimit-Remaining"]),
					Response = responseString,
					StatusCode = (int)response.StatusCode,
					StatusText = response.StatusDescription
				};
			if (!string.IsNullOrEmpty(response.Headers.Get("Link")))
			{
				responseToReturn = ParsePagingLinks(
					responseToReturn, 
					response.Headers.Get("Link"));
			}
			return responseToReturn;
		}
	}
	
	
	
}


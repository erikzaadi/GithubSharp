using System;
using System.Collections.Generic;

namespace GithubSharp.Core
{
	public class GithubError  : Exception
	{
		public GithubError(System.Net.HttpWebResponse response, string uri)
			:base(string.Format("Github error when retrieving {0}", uri))
		{
			var responseString = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd();
			GithubErrorResult = GithubSharp.Core.Base.JsonConverter.FromJson<GithubErrorModel>(responseString);
			StatusCode = (int)response.StatusCode;
			StatusText = response.StatusDescription;
		}
		
		public GithubErrorModel GithubErrorResult { get;set;}
		public int StatusCode { get;set;}
		public string StatusText { get;set;}
	}
	
	public class GithubErrorModel
	{
		public string message {
			get;
			set;
		}
		public IEnumerable<GithubErrorDetails> errors {
			get;
			set;
		}
	}
	
	public class GithubErrorDetails
	{
		public string Resource {
			get;
			set;
		}
		
		public string Field {
			get;
			set;
		}
		
		public string Code {
			get;
			set;
		}
	}
}


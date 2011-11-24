using System;

namespace GithubSharp.Core.Base
{
	public enum GithubSharpHttpVerbs
	{
		GET,
		POST,
		PATCH,
		DELETE,
		PUT,
		HEAD,
		OPTIONS
	}
	
	public enum GithubSharpMimeTypes
	{
		Raw,
		Text,
		Html,
		Full,
		Json
	}
	
	public static class EnumHelper
	{
		public static string ToString(this GithubSharpHttpVerbs verb)
		{
			switch (verb)
			{
				case GithubSharpHttpVerbs.GET : return "GET";
				case GithubSharpHttpVerbs.POST : return "POST";
				case GithubSharpHttpVerbs.PATCH : return "PATCH";
				case GithubSharpHttpVerbs.DELETE : return "DELETE";
				case GithubSharpHttpVerbs.PUT : return "PUT";
				case GithubSharpHttpVerbs.HEAD : return "HEAD";
				default : return "OPTIONS";
			}
		}
		
		public static string ToString(this GithubSharpMimeTypes mime)
		{
			var mimeBase = "application/vnd.github.{0}+json";
			switch (mime)
			{
				case GithubSharpMimeTypes.Raw : return string.Format(mimeBase, "raw");
				case GithubSharpMimeTypes.Text : return string.Format(mimeBase, "text");
				case GithubSharpMimeTypes.Html : return string.Format(mimeBase, "html");
				case GithubSharpMimeTypes.Full : return string.Format(mimeBase, "full");
				default : return "application/vnd.github.json"; 
			}
		}
	}
}


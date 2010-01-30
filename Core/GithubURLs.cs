
using System;

namespace GithubSharp.Core
{
	public static class GithubURLs
	{
		public static string GetRepos { get{ return "http://github.com/api/v2/xml/repos/show/{0}";}}
		public static string GetRepo { get{ return "http://github.com/api/v2/xml/repos/show/{0}/{1}";}}
		public static string RawFile { get{ return "http://github.com/{0}/{1}/raw/master/{2}";}}
		public static string Commits { get{ return "http://github.com/api/v2/xml/commits/list/{0}/{1}/master";}}
		public static string BlobOrTree { get{ return "http://github.com/api/v2/xml/blob/show/{0}/{1}/{2}";}}
	}
}

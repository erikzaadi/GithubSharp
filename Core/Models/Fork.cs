using System;

namespace GithubSharp.Core.Models
{
	[Serializable]
	public class Fork
	{
		public Fork ()
		{
		}
	
		public BasicUser user {get;set;}
	    public string url { get; set; }
	    public DateTime created_at { get; set; }
	}
}


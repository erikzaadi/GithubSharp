using System;

namespace GithubSharp.Core.Models
{
	[Serializable]
	public class BasicUser
	{
		public BasicUser ()
		{
		}
		
	    public string login { get; set; }
	    public int id { get; set; }
	    public string avatar_url { get; set; }
	    public string gravatar_id { get; set; }
	    public string url { get; set; }

	}
}


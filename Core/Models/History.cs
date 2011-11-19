using System;

namespace GithubSharp.Core.Models
{
	[Serializable]
	public class History
	{
		public History ()
		{
		}
		public string url { get; set; }
	    public string version { get; set; }
	    public BasicUser user { get; set; }
	    public ChangeStatus change_status { get; set; }
	    public DateTime committed_at { get; set; }

	}
}


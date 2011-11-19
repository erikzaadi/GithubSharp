using System;

namespace GithubSharp.Core.Models
{
	[Serializable]
	public class ChangeStatus
	{
		public ChangeStatus ()
		{
		}
		public int deletions { get; set; }
		public int additions { get; set; }
		public int total { get; set; }
	}
}


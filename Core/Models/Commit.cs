
using System;
using System.Collections.Generic;

namespace GithubSharp.Core.Models
{
	
	public class Commit
	{
		public IEnumerable<CommmitParent> parents { get; set; }
		public Person author {get;set;}
		public string url { get; set; }
		public string id { get; set; }
		public DateTime committed_date { get; set; }
		public DateTime authored_date { get; set; }
		public string message { get; set; }
		public string tree { get; set; }
		public Person committer {get;set;}
	}

    public class CommmitParent
    {
        public string id { get; set; }
    }
	
	public class Person
	{
		public string name { get; set; }
		public string login { get; set; }
		public string email { get; set; }
	}

    public class SingleFileCommit : Commit
    {
        public IEnumerable<SingleFileCommitFileReference> added { get; set; }
        public IEnumerable<SingleFileCommitFileReference> removed { get; set; }
        public IEnumerable<SingleFileCommitFileReference> modified { get; set; }
    }

    public class SingleFileCommitFileReference
    {
        public string filename { get; set; }
    }
}

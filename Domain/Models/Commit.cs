
using System;
using System.Collections.Generic;

namespace GithubSharp.Domain.Models
{
	
	public class Commit
	{
		public List<int> ParentCommitIDs { get; set; }
		public Person Author {get;set;}
		public string Url { get; set; }
		public string ID { get; set; }
		public DateTime Committed { get; set; }
		public DateTime Authored { get; set; }
		public string Message { get; set; }
		public string Tree { get; set; }
		public Person Committer {get;set;}
		
	}
	
	public class Person
	{
		public string Name { get; set; }
		public string Login { get; set; }
		public string Email { get; set; }
	}
	
}

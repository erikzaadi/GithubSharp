using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GithubSharp.Core.Models
{
    public class Commit
    {
        public List<CommmitParent> parents { get; set; }

        public Person author { get; set; }
  
        public string url { get; set; }

        public string sha { get; set; }

        public string message { get; set; }
   
        public CommmitParent tree { get; set; }

        public Person committer { get; set; }
    }

    public class CommmitParent
    {
        public string sha { get; set; }
		
        public string url { get; set; }
    }

    public class Person
    {
        public string name { get; set; }
		
	    public DateTime date { get; set; } 

        public string email { get; set; }
    }

    [DataContract]
    public class SingleFileCommit : Commit
    {
        [DataMember(Name = "added")]
        public IEnumerable<SingleFileCommitFileReference> Added { get; set; }

        [DataMember(Name = "removed")]
        public IEnumerable<SingleFileCommitFileReference> Removed { get; set; }

        [DataMember(Name = "modified")]
        public IEnumerable<SingleFileCommitFileReference> Modified { get; set; }
    }

    [DataContract]
    public class SingleFileCommitFileReference
    {
        [DataMember(Name = "filename")]
        public string Filename { get; set; }
    }
}

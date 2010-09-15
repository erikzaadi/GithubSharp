using System;
using System.Runtime.Serialization;

namespace GithubSharp.Core.Models
{
    [DataContract]
    public class Repository
    {
        [DataMember(Name = "number")]
        public string URL { get; set; }

        [DataMember(Name = "number")]
        public string Description { get; set; }

        [DataMember(Name = "number")]
        public string Homepage { get; set; }

        [DataMember(Name = "number")]
        public string Name { get; set; }

        [DataMember(Name = "number")]
        public string Owner { get; set; }

        [DataMember(Name = "number")]
        public bool Fork { get; set; }

        [DataMember(Name = "number")]
        public bool Private { get; set; }

        [DataMember(Name = "number")]
        public int OpenIssues { get; set; }

        [DataMember(Name = "number")]
        public int Watchers { get; set; }

        [DataMember(Name = "number")]
        public int Forks { get; set; }

        public string WatchersURL { get { return string.Format("http://github.com/{0}/{1}/watchers", Owner, Name); } }
        public string DownloadURL { get { return string.Format("http://github.com/{0}/{1}/zipball/master", Owner, Name); } }
        public string ForksURL { get { return string.Format("http://github.com/{0}/{1}/network/members", Owner, Name); } }
        public string IssuesURL { get { return string.Format("http://github.com/{0}/{1}/issues", Owner, Name); } }
        public string WikiURL { get { return string.Format("http://wiki.github.com/{0}/{1}", Owner, Name); } }
        public string GraphsURL { get { return string.Format("http://github.com/{0}/{1}/graphs", Owner, Name); } }
        public string ForkQuoueURL { get { return string.Format("http://github.com/{0}/{1}/forkqueue", Owner, Name); } }
        public string GitCloneURL { get { return string.Format("git://github.com/{0}/{1}.git", Owner, Name); } }
        public string HttpCloneURL { get { return string.Format("http://github.com/{0}/{1}.git", Owner, Name); } }
        public string ForkURL { get { return string.Format("http://github.com/{0}/{1}/fork", Owner, Name); } }
        public string WatchURL { get { return string.Format("http://github.com/{0}/{1}/toggle_watch", Owner, Name); } }
    }

    [DataContract]
    public class RepositoryFromSearch
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "size")]
        public int Size { get; set; }

        [DataMember(Name = "followers")]
        public int Followers { get; set; }

        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "language")]
        public string Language { get; set; }

        [DataMember(Name = "fork")]
        public bool Fork { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "pushed")]
        private string PrivatePushed
        {
            get { return Pushed.ToString(); }
            set { Pushed = DateTime.Parse(value); }
        }
        public DateTime Pushed { get; set; }

        [DataMember(Name = "forks")]
        public int Forks { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "score")]
        public float Score { get; set; }

        [DataMember(Name = "created")]
        private string PrivateCreated
        {
            get { return Created.ToString(); }
            set { Created = DateTime.Parse(value); }
        }
        public DateTime Created { get; set; }
    }

    [DataContract]
    public class Language
    {
        public string Name { get; set; }
        public int CalculatedBytes { get; set; }
    }

    [DataContract]
    public class TagOrBranch
    {
        public string Name { get; set; }
        public string Sha { get; set; }
    }
}

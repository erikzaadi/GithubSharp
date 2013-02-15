using System;
using System.Runtime.Serialization;

namespace GithubSharp.Core.Models
{
    [DataContract]
    public class Repository
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "full_name")]
        public string FullName { get; set; }

        //[DataMember(Name = "owner")]
        //public string Owner { get; set; }//TODO

        [DataMember(Name = "private")]
        public bool Private { get; set; }

        [DataMember(Name = "html_url")]
        public string HtmlUrl { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "fork")]
        public bool Fork { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "forks_url")]
        public string ForksUrl { get; set; }

        [DataMember(Name = "collaborators_url")]
        public string CollaboratorsUrl { get; set; }
        
        [DataMember(Name = "homepage")]
        public string Homepage { get; set; }

        [DataMember(Name = "open_issues_count")]
        public int OpenIssuesCount { get; set; }

        [DataMember(Name = "watchers")]
        public int WatchersCount { get; set; }

        [DataMember(Name = "forks")]
        public int Forks { get; set; }

        //[DataMember(Name = "source")]
        //public string Source { get; set; }

        [DataMember(Name = "parent")]
        public ParentRepository Parent { get; set; }//TODO

        //public string WatchersURL { get { return string.Format("http://github.com/{0}/{1}/watchers", Owner, Name); } }
        //public string DownloadURL { get { return string.Format("http://github.com/{0}/{1}/zipball/master", Owner, Name); } }
        //public string ForksURL { get { return string.Format("http://github.com/{0}/{1}/network/members", Owner, Name); } }
        //public string IssuesURL { get { return string.Format("http://github.com/{0}/{1}/issues", Owner, Name); } }
        //public string WikiURL { get { return string.Format("http://wiki.github.com/{0}/{1}", Owner, Name); } }
        //public string GraphsURL { get { return string.Format("http://github.com/{0}/{1}/graphs", Owner, Name); } }
        //public string ForkQuoueURL { get { return string.Format("http://github.com/{0}/{1}/forkqueue", Owner, Name); } }
        //public string GitCloneURL { get { return string.Format("git://github.com/{0}/{1}.git", Owner, Name); } }
        //public string HttpCloneURL { get { return string.Format("http://github.com/{0}/{1}.git", Owner, Name); } }
        //public string ForkURL { get { return string.Format("http://github.com/{0}/{1}/fork", Owner, Name); } }
        //public string WatchURL { get { return string.Format("http://github.com/{0}/{1}/toggle_watch", Owner, Name); } }
    }
    [DataContract]
    public class ParentRepository
    {

        [DataMember(Name = "full_name")]
        public string FullName { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }
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
            set
            {
                Pushed = value != null ? DateTime.Parse(value) : default(DateTime);
            }
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
            set { Created = value != null ? DateTime.Parse(value) : default(DateTime); }
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

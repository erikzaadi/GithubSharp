
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GithubSharp.Core.Models
{
	public class Repository
	{
         public string url { get; set; }
         public string description { get; set; }
         public string homepage { get; set; }
         public string name { get; set; }
         public string owner { get; set; }
         public bool fork { get; set; }
         public bool @private { get; set; }
         public int open_issues { get; set; }
         public int watchers { get; set; }
         public int forks { get; set; }
         public string WatchersURL { get { return string.Format("http://github.com/{0}/{1}/watchers", owner, name); } }
         public string DownloadURL { get { return string.Format("http://github.com/{0}/{1}/zipball/master", owner, name); } }
         public string ForksURL { get { return string.Format("http://github.com/{0}/{1}/network/members", owner, name); } }
         public string IssuesURL { get { return string.Format("http://github.com/{0}/{1}/issues", owner, name); } }
         public string WikiURL { get { return string.Format("http://wiki.github.com/{0}/{1}", owner, name); } }
         public string GraphsURL { get { return string.Format("http://github.com/{0}/{1}/graphs", owner, name); } }
         public string ForkQuoueURL { get { return string.Format("http://github.com/{0}/{1}/forkqueue", owner, name); } }
         public string GitCloneURL { get { return string.Format("git://github.com/{0}/{1}.git", owner, name); } }
         public string HttpCloneURL { get { return string.Format("http://github.com/{0}/{1}.git", owner, name); } }
         public string ForkURL { get { return string.Format("http://github.com/{0}/{1}/fork", owner, name); } }
         public string WatchURL { get { return string.Format("http://github.com/{0}/{1}/toggle_watch", owner, name); } }
	}

    public class RepositoryFromSearch
    {
        public string name { get; set; }
        public int size { get; set; }
        public int followers { get; set; }
        public string username { get; set; }
        public string language { get; set; }
        public bool fork { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public DateTime pushed { get; set; }
        public int forks { get; set; }
        public string description { get; set; }
        public float score { get; set; }
        public DateTime created { get; set; }
    }

    internal class RepositoryCollection<RepoType>
    {
        public IEnumerable<RepoType> repositories { get; set; }
    }
}

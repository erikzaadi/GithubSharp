using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GithubSharp.Core.Models.Internal
{
    internal class RepositoryCollection<RepoType>
    {
        public IEnumerable<RepoType> repositories { get; set; }
    }

    internal class RepositoryContainer<RepoType>
    {
        public RepoType repository { get; set; }
    }

    internal class RepositoryFromNetworkContainer
    {
        public IEnumerable<Models.Repository> network { get; set; }

    }
    internal class RepositoryDelete
    {
        public string delete_token { get; set; }
    }

    internal class RepositoryDeleted
    {
        public string status { get; set; }
    }

    internal class LanguagesCollection
    {
        public Dictionary<string, int> languages { get; set; }
    }
    internal class TagCollection
    {
        public Dictionary<string, string> tags { get; set; }
    }
    internal class BranchesCollection
    {
        public Dictionary<string, string> branches { get; set; }
    }
}

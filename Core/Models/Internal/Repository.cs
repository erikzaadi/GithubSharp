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

    internal class RepositoryDelete
    {
        public string delete_token { get; set; }
    }

    internal class RepositoryDeleted
    {
        public string status { get; set; }
    }
}

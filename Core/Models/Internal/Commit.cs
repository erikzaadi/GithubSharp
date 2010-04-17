using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GithubSharp.Core.Models.Internal
{
    internal class CommitListContainer
    {
        public IEnumerable<Commit> commits { get; set; }
    }

    internal class SingleFileCommitContainer
    {
        public SingleFileCommit commit { get; set; }
    }
}

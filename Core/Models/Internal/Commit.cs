using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GithubSharp.Core.Models.Internal
{
    [DataContract]
    internal class CommitListContainer
    {
        [DataMember(Name = "commits")]
        public IEnumerable<Commit> Commits { get; set; }
    }

    [DataContract]
    internal class SingleFileCommitContainer
    {
        [DataMember(Name = "commit")]
        public SingleFileCommit Commit { get; set; }
    }
}

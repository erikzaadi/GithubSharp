using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace GithubSharp.Core.Models.Internal
{
    [Obsolete]
    [DataContract]
    internal class PullRequestCollection
    {
        [DataMember(Name = "pulls")]
        public IEnumerable<Models.PullRequest> PullRequests { get; set; }
    }

    [DataContract]
    internal class PullRequestContainer
    {
        [DataMember(Name = "pull")]
        public Models.PullRequest PullRequest { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace GithubSharp.Core.Models.Internal
{
    [DataContract]
    class PullRequestCollection
    {
        [DataMember(Name = "pulls")]
        public IEnumerable<Models.PullRequest> PullRequests { get; set; }
    }
}

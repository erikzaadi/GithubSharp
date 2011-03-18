using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GithubSharp.Core.Models.Internal
{
    [DataContract]
    public class IssuesCollection
    {
        [DataMember(Name = "issues")]
        public IEnumerable<Issue> Issues { get; set; }
    }

    [DataContract]
    public class IssueContainer
    {
        [DataMember(Name = "issue")]
        public Issue Issue { get; set; }
    }

    [DataContract]
    public class LabelsCollection
    {
        [DataMember(Name = "labels")]
        public string[] Labels { get; set; }
    }

    [DataContract]
    public class CommentsCollection
    {
        [DataMember(Name = "comments")]
        public IEnumerable<Comment> Comments { get; set; }
    }

    [DataContract]
    public class CommentSavedContainer
    {
        [DataMember(Name = "comment")]
        public CommentSaved Comment { get; set; }
    }

    [DataContract]
    public class CommentSaved
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
    }
}

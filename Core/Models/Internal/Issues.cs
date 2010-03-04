using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GithubSharp.Core.Models.Internal
{
    internal class IssuesCollection
    {
        public IEnumerable<Issue> issues { get; set; }
    }

    internal class IssueContainer
    {
        public Issue issue { get; set; }
    }

    internal class LabelsCollection
    {
        public string[] labels { get; set; }
    }

    internal class CommentsCollection
    {
        public IEnumerable<Comment> comments { get; set; }
    }

    internal class CommentSavedContainer
    {
        public CommentSaved comment { get; set; }
    }

    internal class CommentSaved
    {
        public string comment { get; set; }
        public string status { get; set; }
    }

}

using System;
using System.Runtime.Serialization;

namespace GithubSharp.Core.Models
{
    [DataContract]
    public class Issue
    {
        [DataMember(Name = "number")]
        public int Number { get; set; }

        [DataMember(Name = "votes")]
        public int Votes { get; set; }

        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "body")]
        public string Body { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "closed_at")]
        public DateTime ClosedAt { get; set; }

        [DataMember(Name = "user")]
        public string User { get; set; }

        [DataMember(Name = "labels")]
        public string[] Labels { get; set; }

        [DataMember(Name = "state")]
        public IssueState State { get; set; }
    }

    [DataContract]
    public enum IssueState
    {
        [DataMember(Name = "open")]
        Open,
        [DataMember(Name = "closed")]
        Closed
    }

    [DataContract]
    public class Comment
    {
        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "updated_at")]
        public DateTime UpdatedAt { get; set; }

        [DataMember(Name = "body")]
        public string Body { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "user")]
        public string User { get; set; }
    }
}

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
        private string PrivateCreatedAt
        {
            get { return CreatedAt.ToString(); }
            set { CreatedAt = DateTime.Parse(value); }
        }
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "body")]
        public string Body { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "closed_at")]
        private string PrivateClosedAt
        {
            get { return ClosedAt.ToString(); }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    ClosedAt = DateTime.Parse(value);
            }
        }
        public DateTime? ClosedAt { get; set; }

        [DataMember(Name = "user")]
        public string User { get; set; }

        [DataMember(Name = "labels")]
        public string[] Labels { get; set; }                

        [DataMember(Name = "state")] //EnumMember does not work?
        public string State { get; set; }

        [DataMember(Name = "comments")]
        public int Comments { get; set; }

        [DataMember(Name = "position")]
        public double Position { get; set; }

        [DataMember(Name = "html_url")]
        public string HtmlUrl { get; set; }
        
    }

    [DataContract]
    public enum IssueState
    {
        [EnumMember(Value = "open")]
        Open,
        [EnumMember(Value= "closed")]
        Closed
    }

    [DataContract]
    public class CommentForIssue
    {
        [DataMember(Name = "created_at")]
        private string PrivateCreatedAt
        {
            get { return CreatedAt.ToString(); }
            set { CreatedAt = DateTime.Parse(value); }
        }
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "updated_at")]
        private string PrivateUpdatedAt
        {
            get { return UpdatedAt.ToString(); }
            set { UpdatedAt = DateTime.Parse(value); }
        }
        public DateTime UpdatedAt { get; set; }

        [DataMember(Name = "body")]
        public string Body { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "user")]
        public string User { get; set; }
    }
}

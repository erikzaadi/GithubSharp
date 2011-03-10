using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using GithubSharp.Core.Models.Internal;

namespace GithubSharp.Core.Models
{
    [DataContract]
    public class PullRequest
    {
        [DataMember(Name = "issue_updated_at")]
        private string IssueUpdatedPrivate
        {
            get
            {
                return IssueUpdated.ToString();
            }
            set
            {
                IssueUpdated = DateTime.Parse(value);
            }
        }
        public DateTime IssueUpdated { get; set; }

        [DataMember(Name = "created_at")]
        private string CreatedPrivate
        { 
            get 
            {
                return Created.ToString();
            }
            set
            {
                Created = DateTime.Parse(value);
            }
        }
        public DateTime Created { get; set; }

        [DataMember(Name = "updated_at")]
        private string UpdatedPrivate
        {
            get
            {
                return Updated.ToString();
            }
            set
            {
                Updated = DateTime.Parse(value);
            }
        }
        
        public DateTime Updated { get; set; }

        [DataMember(Name = "closed_at")]
        private string ClosedPrivate
        {
            get
            {
                return Closed.HasValue ? Closed.Value.ToString() : null;
            }
            set
            {
                if (value != null)
                    Closed = DateTime.Parse(value);
            }
        }
        public DateTime? Closed { get; set; }

        [DataMember(Name = "position")]
        public int Position { get; set; }

        [DataMember(Name = "number")]
        public int Number { get; set; }
        
        [DataMember(Name = "votes")]
        public int Votes { get; set; }
        
        [DataMember(Name = "patch_url")]
        public string PatchUrl { get; set; }
        
        [DataMember(Name = "comments")]
        public int Comments { get; set; }
        
        [DataMember(Name = "body")]
        public string Body { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "issue_user")]
        public IssueUser IssueUser { get; set; }

        [DataMember(Name = "user")]
        public IssueUser User { get; set; }

        [DataMember(Name = "base")]
        public PullRequestCommitReference Base { get; set; }

        [DataMember(Name = "head")]
        public PullRequestCommitReference Head { get; set; }

        [DataMember(Name = "state")]
        string State { get; set; }

        [DataMember(Name = "labels")]
        public string[] Labels { get; set; }

        [DataMember(Name = "diff_url")]
        public string DiffUrl { get; set; }

        [DataMember(Name = "discussion")]
        public List<DiscussionEntry> Discussion { get; set; }
    }

    [DataContract]
    public class DiscussionEntry
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "authored_date")]
        private string AuthoredDatePrivate
        { 
            get 
            {
                return Created.ToString();
            }
            set
            {
                Created = DateTime.Parse(value);
            }
        }
        public DateTime Created { get; set; }

        //Same backend. authored_date used by commit, created_at used by IssueComment
        [DataMember(Name = "created_at")]
        private string CreatedAtPrivate
        {
            get
            {
                return Created.ToString();
            }
            set
            {
                Created = DateTime.Parse(value);
            }
        }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "body")]
        public string Body { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "user")]
        public IssueUser User { get; set; }

        [DataMember(Name = "author")]
        public IssueUser Author { get; set; }
    }

    [DataContract]
    public class IssueUser
    {
        [DataMember(Name="gravatar_id")]
        public string GravatarId { get; set; }
    
        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "login")]
        public string Login { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set;}

        [DataMember(Name = "email")]
        public string Email { get; set; }
    }

    [DataContract]
    public class PullRequestCommitReference
    {
        [DataMember(Name="repository")]
        public Repository Repository { get; set; }

        [DataMember(Name = "sha")]
        public string Sha { get; set; }

        [DataMember(Name = "label")]
        public string Label { get; set; }

        [DataMember(Name = "user")]
        public IssueUser User { get; set; }

        [DataMember(Name = "ref")]
        public string Ref { get; set; }
    }
}
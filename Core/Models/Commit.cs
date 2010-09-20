using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GithubSharp.Core.Models
{
    [DataContract]
    public class Commit
    {
        [DataMember(Name = "parents")]
        public IEnumerable<CommmitParent> Parents { get; set; }

        [DataMember(Name = "author")]
        public Person Author { get; set; }

        [DataMember(Name = "url")]
        public string URL { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "comitted_date")]
        private string PrivateCommittedDate
        {
            get { return CommittedDate.ToString(); }
            set { CommittedDate = DateTime.Parse(value); }
        }
        public DateTime CommittedDate { get; set; }

        [DataMember(Name = "authored_date")]
        private string PrivateAuthoredDate
        {
            get { return AuthoredDate.ToString(); }
            set { AuthoredDate = DateTime.Parse(value); }
        }
        public DateTime AuthoredDate { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "tree")]
        public string Tree { get; set; }

        [DataMember(Name = "comitter")]
        public Person Committer { get; set; }
    }

    [DataContract]
    public class CommmitParent
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
    }

    [DataContract]
    public class Person
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "login")]
        public string Login { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }
    }

    [DataContract]
    public class SingleFileCommit : Commit
    {
        [DataMember(Name = "added")]
        public IEnumerable<SingleFileCommitFileReference> Added { get; set; }

        [DataMember(Name = "removed")]
        public IEnumerable<SingleFileCommitFileReference> Removed { get; set; }

        [DataMember(Name = "modified")]
        public IEnumerable<SingleFileCommitFileReference> Modified { get; set; }
    }

    [DataContract]
    public class SingleFileCommitFileReference
    {
        [DataMember(Name = "filename")]
        public string Filename { get; set; }
    }
}

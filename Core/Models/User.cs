using System;
using System.Runtime.Serialization;

namespace GithubSharp.Core.Models
{
    [DataContract]
    public class UserInCollection
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "location")]
        public string Location { get; set; }

        [DataMember(Name = "followers")]
        public int Followers { get; set; }

        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "language")]
        public string Language { get; set; }

        [DataMember(Name = "fullname")]
        public string Fullname { get; set; }

        [DataMember(Name = "repos")]
        public int Repos { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "pushed")]
        private string PrivatePushed
        {
            get { return Pushed.ToString(); }
            set { Pushed = DateTime.Parse(value); }
        }
        public DateTime Pushed { get; set; }

        [DataMember(Name = "score")]
        public float Score { get; set; }

        [DataMember(Name = "created")]
        private string PrivateCreated
        {
            get { return Created.ToString(); }
            set { Created = DateTime.Parse(value); }
        }
        public DateTime Created { get; set; }
    }

    [DataContract]
    public class User
    {
        [DataMember(Name = "gravatar_id")]
        public string GravatarId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "company")]
        public string Company { get; set; }

        [DataMember(Name = "location")]
        public string Location { get; set; }

        [DataMember(Name = "created_at")]
        private string PrivateCreatedAt
        {
            get { return CreatedAt.ToString(); }
            set { CreatedAt = DateTime.Parse(value); }
        }
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "public_gist_count")]
        public int PublicGistCount { get; set; }

        [DataMember(Name = "public_repo_count")]
        public int PublicRepoCount { get; set; }

        [DataMember(Name = "blog")]
        public string Blog { get; set; }

        [DataMember(Name = "following")]
        public int Following { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "login")]
        public string Login { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }
    }

    [DataContract]
    public class UserAuthenticated : User
    {
        [DataMember(Name = "total_private_repo_count")]
        public int TotalPrivateRepoCount { get; set; }

        [DataMember(Name = "collaborators")]
        public int Collaborators { get; set; }

        [DataMember(Name = "disk_usage")]
        public int DiskUsage { get; set; }

        [DataMember(Name = "owned_private_repo_count")]
        public int OwnedPrivateRepoCount { get; set; }

        [DataMember(Name = "private_gist_count")]
        public int PrivateGistCount { get; set; }

        [DataMember(Name = "plan")]
        public UserAuthenticatedPlan Plan { get; set; }
    }

    [DataContract]
    public class UserAuthenticatedPlan
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "collaborators")]
        public int Collaborators { get; set; }

        [DataMember(Name = "space")]
        public int Space { get; set; }

        [DataMember(Name = "private_repos")]
        public int PrivateRepos { get; set; }
    }

    [DataContract]
    public class PublicKey
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "key")]
        public string Key { get; set; }
    }

   
}

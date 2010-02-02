using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GithubSharp.Core.Models
{
    public class UserInCollection
    {
        public string name { get; set; }
        public string location { get; set; }
        public int followers { get; set; }
        public string username { get; set; }
        public string language { get; set; }
        public string fullname { get; set; }
        public int repos { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public DateTime pushed { get; set; }
        public float score { get; set; }
        public DateTime created { get; set; }
    }

    public class User
    {
        public string gravatar_id { get; set; }
        public string name { get; set; }
        public string company { get; set; }
        public string location { get; set; }
        public DateTime created_at { get; set; }
        public int public_gist_count { get; set; }
        public int public_repo_count { get; set; }
        public string blog { get; set; }
        public int following { get; set; }
        public int id { get; set; }
        public string login { get; set; }
        public string email { get; set; }
    }

    public class UserAuthenticated : User
    {
        public int total_private_repo_count { get; set; }
        public int collaborators { get; set; }
        public int disk_usage { get; set; }
        public int owned_private_repo_count { get; set; }
        public int private_gist_count { get; set; }
        public UserAuthenticatedPlan plan { get; set; }
    }

    public class UserAuthenticatedPlan
    {
        public string name { get; set; }
        public int collaborators { get; set; }
        public int space { get; set; }
        public int private_repos { get; set; }
    }

    public class PublicKey
    {
        public string title { get; set; }
        public int id { get; set; }
        public string key { get; set; }
    }

    internal class PublicKeyCollection<PublicKeyType>
    {
        public IEnumerable<PublicKeyType> public_keys { get; set; }
    }

    internal class UsersCollection<UserType>
    {
        public IEnumerable<UserType> users { get; set; }
    }

    internal class EmailCollection
    {
        public IEnumerable<string> emails { get; set; }
    }

    internal class UserContainer<UserType>
    {
        public UserType user { get; set; }
    }
}

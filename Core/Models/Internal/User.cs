using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GithubSharp.Core.Models.Internal
{
    [DataContract]
    internal class PublicKeyCollection<TPublicKeyType>
    {
        [DataMember(Name = "public_keys")]
        public IEnumerable<TPublicKeyType> PublicKeys { get; set; }
    }

    [DataContract]
    internal class UsersCollection<TUserType>
    {
        [DataMember(Name = "users")]
        public IEnumerable<TUserType> Users { get; set; }
    }

    [DataContract]
    internal class EmailCollection
    {
        [DataMember(Name = "emails")]
        public IEnumerable<string> Emails { get; set; }
    }

    [DataContract]
    internal class UserContainer<TUserType>
    {
        [DataMember(Name = "user")]
        public TUserType User { get; set; }
    }

    [DataContract]
    internal class CollaboratorsCollection
    {
        [DataMember(Name = "collaborators")]
        public IEnumerable<string> Collaborators { get; set; }
    }
}

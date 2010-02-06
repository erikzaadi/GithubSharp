using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GithubSharp.Core.Models.Internal
{
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

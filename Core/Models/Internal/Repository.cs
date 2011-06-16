using System.Collections.Generic;
using System.Runtime.Serialization;
using System;

namespace GithubSharp.Core.Models.Internal
{
    [DataContract]
    internal class RepositoryCollection<TRepoType>
    {
        [DataMember(Name = "repositories")]
        public IEnumerable<TRepoType> Repositories { get; set; }
    }

    [DataContract]
    internal class RepositoryContainer<TRepoType>
    {
        [DataMember(Name = "repository")]
        public TRepoType Repository { get; set; }
    }

    [DataContract]
    internal class RepositoryFromNetworkContainer
    {
        [DataMember(Name = "network")]
        public IEnumerable<Repository> Network { get; set; }
    }

    [DataContract]
    internal class RepositoryDelete
    {
        [DataMember(Name = "delete_token")]
        public string DeleteToken { get; set; }
    }

    [DataContract]
    internal class RepositoryDeleted
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }
    }

    [DataContract]
    internal class LanguagesCollection
    {
        [DataMember(Name = "languages")]
        public Dictionary<string, int> Languages { get; set; }
    }

    [DataContract]
    internal class TagCollection
    {
        [DataMember(Name = "tags")]
        public JsonSimpleDictionary Tags { get; set; }
    }

    [DataContract]
    internal class BranchesCollection
    {
        [DataMember(Name = "branches")]
        public JsonSimpleDictionary Branches { get; set; }
    }
}

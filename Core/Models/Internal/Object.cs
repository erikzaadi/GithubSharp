using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GithubSharp.Core.Models.Internal
{
    [DataContract]
    internal class ObjectContainer
    {
        [DataMember(Name = "tree")]
        public IEnumerable<Object> Tree { get; set; }
    }

    [DataContract]
    internal class BlobContainer
    {
        [DataMember(Name = "blob")]
        public Blob Blob { get; set; }
    }

    [DataContract]
    internal class BlobListContainer
    {
        [DataMember(Name = "blobs")]
        public Dictionary<string, string> Blobs { get; set; }
    }
}

using System.Runtime.Serialization;

namespace GithubSharp.Core.Models
{
    [DataContract]
    public class Object
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "sha")]
        public string Sha { get; set; }

        [DataMember(Name = "mode")]
        public string Mode { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        public ObjectItemType ObjectItemType
        {
            get { return Type == "blob" ? ObjectItemType.Blob : ObjectItemType.Tree; }
        }
    }

    [DataContract]
    public class Blob
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "sha")]
        public string Sha { get; set; }

        [DataMember(Name = "mode")]
        public string Mode { get; set; }

        [DataMember(Name = "size")]
        public int Size { get; set; }

        [DataMember(Name = "mime_type")]
        public string MimeType { get; set; }

        [DataMember(Name = "data")]
        public string Data { get; set; }
    }

    public enum ObjectItemType
    {
        Blob,
        Tree
    }
}
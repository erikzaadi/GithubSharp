using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GithubSharp.Core.Models
{
    public class Object
    {
        public string name { get; set; }
        public string sha { get; set; }
        public string mode { get; set; }
        public string type { get; set; }
        public ObjectItemType ObjectItemType { get { return type == "blob" ? ObjectItemType.Blob : Models.ObjectItemType.Tree; } }
    }

    public class Blob
    {
        public string name { get; set; }
        public string sha { get; set; }
        public string mode { get; set; }
        public int size { get; set; }
        public string mime_type { get; set; }
        public string data { get; set; }
    }

    public enum ObjectItemType
    {
        Blob,
        Tree
    }
}

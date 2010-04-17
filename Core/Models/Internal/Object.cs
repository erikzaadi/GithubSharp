using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GithubSharp.Core.Models.Internal
{
    internal class ObjectContainer
    {
        public IEnumerable<Object> tree { get; set; }
    }

    internal class BlobContainer
    {
        public Blob blob { get; set; }
    }

    internal class BlobListContainer
    {
        public Dictionary<string, string> blobs { get; set; }
    }
}

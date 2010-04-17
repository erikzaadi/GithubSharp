using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GithubSharp.Core.Models.Internal
{
    internal class NetworkChunkContainer
    {
        public IEnumerable<NetworkChunk> commits { get; set; }
    }
}

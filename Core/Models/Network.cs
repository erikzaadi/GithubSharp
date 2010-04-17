using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GithubSharp.Core.Models
{
    public class NetworkMeta
    {
        public IEnumerable<IEnumerable<IEnumerable<int>>> spacemap { get; set; }
        public int focus { get; set; }
        public string nethash { get; set; }
        public DateTime[] dates { get; set; }
        public IEnumerable<NetworkUser> users { get; set; }
    }

    public class NetworkUser
    {
        public string name { get; set; }
        public string repo { get; set; }
        public IEnumerable<NetworkUserHeadInfo> heads { get; set; }
    }

    public class NetworkUserHeadInfo
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class NetworkBlock
    {
        public string name { get; set; }
        public int start { get; set; }
        public int count { get; set; }
    }

    public class NetworkChunk
    {
        public string author { get; set; }
        public int time { get; set; }
        public string id { get; set; }
        public DateTime date { get; set; }
        public string gravatar { get; set; }
        public int space { get; set; }
        public string message { get; set; }
        public string login { get; set; }

        //TODO: Need to parse this more accurate, it's string (sha id),int (commit id/nr),int(branch?)
        public IEnumerable<IEnumerable<string>> parents { get; set; }
    }
}

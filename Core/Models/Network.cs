using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace GithubSharp.Core.Models
{
    [DataContract]
    public class NetworkMeta
    {
        [DataMember(Name = "spacemap")]
        public IEnumerable<IEnumerable<IEnumerable<int>>> Spacemap { get; set; }

        [DataMember(Name = "focus")]
        public int Focus { get; set; }

        [DataMember(Name = "nethash")]
        public string Nethash { get; set; }

        [DataMember(Name = "dates")]
        private List<string> PrivateCreated
        {
            get 
            {
                return Dates.Select(DateTime => DateTime.ToString()).ToList();
            }
            set
            {
                if(Dates == null) Dates = new List<DateTime>();
                foreach (var val in value)
                    Dates.Add(DateTime.Parse(val));
            }
        }
        public List<DateTime> Dates { get; set; }

        [DataMember(Name = "users")]
        public IEnumerable<NetworkUser> Users { get; set; }
    }

    [DataContract]
    public class NetworkUser
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "repo")]
        public string Repo { get; set; }

        [DataMember(Name = "heads")]
        public IEnumerable<NetworkUserHeadInfo> Heads { get; set; }
    }

    [DataContract]
    public class NetworkUserHeadInfo
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }
    }

    [DataContract]
    public class NetworkBlock
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "start")]
        public int Start { get; set; }

        [DataMember(Name = "count")]
        public int Count { get; set; }
    }

    [DataContract]
    public class NetworkChunk
    {
        [DataMember(Name = "author")]
        public string Author { get; set; }

        [DataMember(Name = "time")]
        public int Time { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "date")]
        private string PrivateDate
        {
            get { return Date.ToString(); }
            set { Date = DateTime.Parse(value); }
        }
        public DateTime Date{ get; set; }

        [DataMember(Name = "gravatar")]
        public string Gravatar { get; set; }

        [DataMember(Name = "space")]
        public int Space { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "login")]
        public string Login { get; set; }

        //TODO: Need to parse this more accurate, it's string (sha id),int (commit id/nr),int(branch?)
        [DataMember(Name = "parents")]
        public IEnumerable<IEnumerable<string>> Parents { get; set; }
    }
}

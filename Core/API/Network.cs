using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GithubSharp.Core.Services;
using GithubSharp.Core.Models;

namespace GithubSharp.Core.API
{
    public class Network : Base.BaseAPI, Base.IBaseAPI
    {
        public Network(ICacheProvider cacheProvider, ILogProvider logProvider) : base(cacheProvider, logProvider) { }

        public NetworkMeta Meta(
            string Username,
            string RepositoryName)
        {
            LogProvider.LogMessage(string.Format("Network.Meta - Username : '{0}', RepositoryName : '{1}'",
                Username,
                RepositoryName));

            var url = string.Format("http://github.com/{0}/{1}/network_meta",
                Username,
                RepositoryName);

            return ConsumeJsonUrl<NetworkMeta>(url);
        }

        public IEnumerable<NetworkChunk> MetaChunks(
                   string Username,
                   string RepositoryName,
                   string NetworkHash)
        {
            return MetaChunks(Username,
                RepositoryName,
                NetworkHash,
                -1,
                -1);
        }


        public IEnumerable<NetworkChunk> MetaChunks(
                    string Username,
                    string RepositoryName,
                    string NetworkHash,
                    int Start,
                    int End)
        {
            LogProvider.LogMessage(string.Format("Network.MetaChunks - Username : '{0}', RepositoryName : '{1}', NetworkHash : '{2}'",
                Username,
                RepositoryName,
                NetworkHash));

            var url = string.Format("http://github.com/{0}/{1}/network_data_chunk?nethash={2}{3}",
                Username,
                RepositoryName,
                NetworkHash,
                End > 0 && Start > -1 ?
                    string.Format("?start={0}&end={1}", Start, End) : string.Empty);

            var result = ConsumeJsonUrl<Models.Internal.NetworkChunkContainer>(url);

            return result != null ? result.commits : null;
        }
    }
}

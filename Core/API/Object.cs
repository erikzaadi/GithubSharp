using System.Collections.Generic;
using GithubSharp.Core.Services;
using GithubSharp.Core.Models;

namespace GithubSharp.Core.API
{
    public class Object : Base.BaseApi
    {
        public Object(ICacheProvider CacheProvider, ILogProvider LogProvider) : base(CacheProvider, LogProvider) { }

        public IEnumerable<Models.Object> Trees(
            string Username,
            string RepositoryName,
            string TreeSha)
        {
            LogProvider.LogMessage(string.Format("Object.Trees - TreeSha : '{0}' , Username : '{1}', RepositoryName : '{2}'", TreeSha, Username, RepositoryName));

            var url = string.Format("tree/show/{0}/{1}/{2}",
                Username,
                RepositoryName,
                TreeSha);

            var result = ConsumeJsonUrl<Core.Models.Internal.ObjectContainer>(url);

            return result == null ? null : result.Tree;
        }

        public Blob Blob(
            string Username,
            string RepositoryName,
            string TreeSha,
            string Path)
        {
            LogProvider.LogMessage(string.Format("Object.Blob - TreeSha : '{0}' , Username : '{1}', RepositoryName : '{2}', Path : '{3}'",
                TreeSha,
                Username,
                RepositoryName,
                Path));

            var url = string.Format("blob/show/{0}/{1}/{2}/{3}",
                Username,
                RepositoryName,
                TreeSha,
                Path);

            var result = ConsumeJsonUrl<Core.Models.Internal.BlobContainer>(url);

            return result == null ? null : result.Blob;
        }

        public Dictionary<string, string> BlobList(
            string Username,
            string RepositoryName,
            string TreeSha)
        {
            LogProvider.LogMessage(string.Format("Object.BlobList - TreeSha : '{0}' , Username : '{1}', RepositoryName : '{2}'",
                TreeSha,
                Username,
                RepositoryName));

            var url = string.Format("blob/all/{0}/{1}/{2}",
                Username,
                RepositoryName,
                TreeSha);

            var result = ConsumeJsonUrl<Core.Models.Internal.BlobListContainer>(url);

            return result == null ? null : result.Blobs;
        }

        public byte[] RawBinary(
          string Username,
            string RepositoryName,
            string BlobSha)
        {
            LogProvider.LogMessage(string.Format("Object.RawBinary - BlobSha : '{0}' , Username : '{1}', RepositoryName : '{2}'",
                BlobSha,
                Username,
                RepositoryName));

            var url = string.Format("blob/show/{0}/{1}/{2}",
                Username,
                RepositoryName,
                BlobSha);

            return ConsumeUrlToBinary(url);
        }

        public string RawString(
         string Username,
           string RepositoryName,
           string BlobSha)
        {
            LogProvider.LogMessage(string.Format("Object.RawString - BlobSha : '{0}' , Username : '{1}', RepositoryName : '{2}'",
                BlobSha,
                Username,
                RepositoryName));

            var url = string.Format("blob/show/{0}/{1}/{2}",
                Username,
                RepositoryName,
                BlobSha);

            return ConsumeUrlToString(url);
        }
    }
}

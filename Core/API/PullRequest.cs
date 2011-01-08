using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GithubSharp.Core.Services;

namespace GithubSharp.Core.API
{
    public class PullRequest : Base.BaseAPI
    {
        public PullRequest(ICacheProvider CacheProvider, ILogProvider LogProvider) : base(CacheProvider, LogProvider) { }

        public IEnumerable<Models.PullRequest> List(string Username, string RepositoryName)
        {
            return List(Username, RepositoryName, null);
        }

        public IEnumerable<Models.PullRequest> List(string Username, string RepositoryName, string State)
        {
            LogProvider.LogMessage(string.Format("PullRequest.List - {0} - {1} - {2}", Username, RepositoryName, State));
            var url = string.Format("pulls/{0}/{1}{2}", Username, RepositoryName, string.IsNullOrEmpty(State) ? "" : "/" + State);
            var result = ConsumeJsonUrl<Models.Internal.PullRequestCollection>(url);
            return result == null ? null : result.PullRequests;
        }

        public Models.PullRequest GetById(string Username, string RepositoryName, string Id)
        {
            LogProvider.LogMessage(string.Format("PullRequest.GetById - {0} - {1} - {2}", Username, RepositoryName, Id));
            var url = string.Format("pulls/{0}/{1}/{2}", Username, RepositoryName, Id);
            var result = ConsumeJsonUrl<Models.Internal.PullRequestContainer>(url);
            return result == null ? null : result.PullRequest;
        }
    }
}

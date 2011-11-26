using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GithubSharp.Core.Services;
using System.Collections.Specialized;

namespace GithubSharp.Core.API
{
    public class PullRequest : Base.BaseApi
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

        public Models.PullRequest Create(string Username, string RepositoryName, string BaseRef, string HeadRef, string Title, string Body)
        {
            LogProvider.LogMessage(string.Format("PullRequest.Create - {0} - {1} - {2} - {3} - {4}", Username, RepositoryName, BaseRef, HeadRef, Title));
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(RepositoryName) || string.IsNullOrEmpty(BaseRef) || string.IsNullOrEmpty(HeadRef) || string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(Body))
                return null;

            var url = string.Format("pulls/{0}/{1}", Username, RepositoryName);

            var formValues = new NameValueCollection();
            formValues.Add("pull[base]", BaseRef);
            formValues.Add("pull[head]", HeadRef);
            formValues.Add("pull[title]", Title);
            formValues.Add("pull[body]", Body);

            var result = ConsumeJsonUrlAndPostData<Models.Internal.PullRequestContainer>(url, formValues);

            return result != null ? result.PullRequest : null;
        }
    }
}

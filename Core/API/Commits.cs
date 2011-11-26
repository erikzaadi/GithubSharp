using System.Collections.Generic;
using GithubSharp.Core.Services;
using GithubSharp.Core.Models;

namespace GithubSharp.Core.API
{
    public class Commits : Base.BaseApi
    {
        public Commits(ICacheProvider CacheProvider, ILogProvider LogProvider) : base(CacheProvider, LogProvider) { }

        public IEnumerable<Commit> CommitsForBranch(
            string Username,
            string RepositoryName,
            string BranchName)
        {
            LogProvider.LogMessage(string.Format("Commits.CommitsForBranch - Username : '{0}', RepositoryName : '{1}', Branch : '{2}'",
                Username,
                RepositoryName,
                BranchName));

            var url = string.Format("commits/list/{0}/{1}/{2}",
                Username,
                RepositoryName,
                BranchName);

            var result = ConsumeJsonUrl<Models.Internal.CommitListContainer>(url);

            return result != null ? result.Commits : null;
        }


        public IEnumerable<Commit> CommitsForFile(
            string Username,
            string RepositoryName,
            string BranchName,
            string FilePath)
        {
            LogProvider.LogMessage(string.Format("Commits.CommitsForFile - Username : '{0}', RepositoryName : '{1}', Branch : '{2}', Path : '{3}'",
                Username,
                RepositoryName,
                BranchName,
                FilePath));

            var url = string.Format("commits/list/{0}/{1}/{2}/{3}",
                Username,
                RepositoryName,
                BranchName,
                FilePath);

            var result = ConsumeJsonUrl<Models.Internal.CommitListContainer>(url);

            return result != null ? result.Commits : null;
        }


        public SingleFileCommit CommitForSingleFile(
            string Username,
            string RepositoryName,
            string CommitShaId)
        {
            LogProvider.LogMessage(string.Format("Commits.CommitForSingleFile - Username : '{0}', RepositoryName : '{1}', CommitShaId : '{2}'",
                Username,
                RepositoryName,
                CommitShaId));

            var url = string.Format("commits/show/{0}/{1}/{2}",
                Username,
                RepositoryName,
                CommitShaId);

            var result = ConsumeJsonUrl<Models.Internal.SingleFileCommitContainer>(url);

            return result != null ? result.Commit : null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GithubSharp.Core.Services;
using GithubSharp.Core.Models;

namespace GithubSharp.Core.API
{
    public class Commits : Base.BaseAPI, Base.IBaseAPI
    {
        public Commits(ICacheProvider cacheProvider, ILogProvider logProvider) : base(cacheProvider, logProvider) { }

        public IEnumerable<Commit> CommitsForBranch(
            string Username,
            string RepositoryName,
            string BranchName)
        {
            LogProvider.LogMessage(string.Format("Commits.CommitsForBranch - Username : '{0}', RepositoryName : '{1}', Branch : '{2}'",
                Username,
                RepositoryName,
                BranchName));

            var url = string.Format("commits/list/{0}/{1}/{3}",
                Username,
                RepositoryName,
                BranchName);

            var result = ConsumeJsonUrl<Models.Internal.CommitListContainer>(url);

            return result != null ? result.commits : null;
        }


        public IEnumerable<Commit> CommitsForFile(
            string Username,
            string RepositoryName,
            string BranchName,
            string FilePath)
        {
            LogProvider.LogMessage(string.Format("Commits.Commits - Username : '{0}', RepositoryName : '{1}', Branch : '{2}', Path : '{3}'",
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

            return result != null ? result.commits : null;
        }


        public SingleFileCommit CommitForFile(
            string Username,
            string RepositoryName,
            string CommitShaId)
        {
            LogProvider.LogMessage(string.Format("Commits.Commits - Username : '{0}', RepositoryName : '{1}', CommitShaId : '{2}'",
                Username,
                RepositoryName,
                CommitShaId));

            var url = string.Format("commits/show/{0}/{1}/{2}",
                Username,
                RepositoryName,
                CommitShaId);

            var result = ConsumeJsonUrl<Models.Internal.SingleFileCommitContainer>(url);

            return result != null ? result.commit : null;
        }
    }
}

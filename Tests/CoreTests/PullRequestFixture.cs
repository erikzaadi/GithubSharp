using GithubSharp.Core.API;
using GithubSharp.Plugins.LogProviders.NullLogger;
using NUnit.Framework;

namespace GithubSharp.Tests.CoreTests
{
    [TestFixture]
    public class PullRequestFixture
    {
        [Test]
        public void CanGetPullRequests()
        {
            var pullrequestApi = new PullRequest(new BasicCacher.BasicCacher(), new NullLogger());
            var pullrequest = pullrequestApi.List("rhysc", "GithubSharp");
            Assert.NotNull(pullrequest);
        }
    }
}

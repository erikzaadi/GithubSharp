using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GithubSharp.Core.API;
using GithubSharp.Plugins.LogProviders.NullLogger;
using NUnit.Framework;

namespace GithubSharp.Tests.CoreTests
{
    [TestFixture]
    public class RepositoryFixture
    {
        //http://json2csharp.com/ to create models
        //http://jsonformat.com/ TO SEE CLEAN JSON MODELS
        [Test]
        public void CanGetRepository()
        {
            var repoApi = new Repository(new BasicCacher.BasicCacher(), new NullLogger());
            var repos = repoApi.Get("rhysc", "GithubSharp");
            Assert.NotNull(repos);
            Assert.AreEqual("GithubSharp", repos.Name);
        }
    }
}

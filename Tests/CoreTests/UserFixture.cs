using GithubSharp.Core.API;
using GithubSharp.Plugins.LogProviders.NullLogger;
using NUnit.Framework;

namespace GithubSharp.Tests.CoreTests
{
    [TestFixture]
    public class UserFixture
    {
        [Test]
        public void UserCanBeRetrieved()
        {
            var userApi = new User(new BasicCacher.BasicCacher(), new NullLogger());
            var user = userApi.Get("rhysc");
            Assert.NotNull(user);
            Assert.AreEqual("Rhys Campbell", user.Name);
            Assert.AreEqual("RhysC", user.Login);
            Assert.AreEqual("https://api.github.com/users/RhysC", user.Url);
        }
    }
}

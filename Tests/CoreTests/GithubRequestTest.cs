using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace CoreTests
{
	[TestFixture()]
	public class GithubRequestTest
	{
		[Test()]
		public void GithubRequestsShouldAffectTheRateLimitRemaining ()
		{
			var baseGithubRequest = new GithubSharp.Core.GithubRequest(
				new GithubSharp.Plugins.LogProviders.NullLogger.NullLogger(true),
				new GithubSharp.Plugins.CacheProviders.NullCacher.NullCacher(),
				new GithubSharp.Plugins.AuthProviders.NullAuthProvider.NullAuthProvider(),
				""
				);
			
			var response = baseGithubRequest.GetResponse();
			
			var first = response.RateLimitRemaining;
			
			response = baseGithubRequest.GetResponse();
			
			Assert.IsTrue(first > response.RateLimitRemaining, 
				string.Format("Rate Limit should decrease: {0} should be larger than {1}", first, response.RateLimitRemaining));
		}
		
		
		[Test()]
		public void GithubRequestsPagingShouldHavePaginationLink ()
		{
			var baseGithubRequest = new GithubSharp.Core.GithubRequest(
				new GithubSharp.Plugins.LogProviders.NullLogger.NullLogger(true),
				new GithubSharp.Plugins.CacheProviders.NullCacher.NullCacher(),
				new GithubSharp.Plugins.AuthProviders.NullAuthProvider.NullAuthProvider(),
				"users/jenkinsci/repos"
				);
			
			baseGithubRequest.PagingCurrentPage = 3;
			baseGithubRequest.PagingRequestAmount = 5;
			
			var response = baseGithubRequest.GetResponse();
			
			Assert.AreEqual("https://api.github.com/users/jenkinsci/repos?page=4&per_page=5", response.LinkNext);
			Assert.AreEqual("https://api.github.com/users/jenkinsci/repos?page=2&per_page=5", response.LinkPrevious);
			Assert.AreEqual("https://api.github.com/users/jenkinsci/repos?page=1&per_page=5", response.LinkFirst);
			Assert.That(response.LinkLast.StartsWith("https://api.github.com/users/jenkinsci/repos"));
		}

        [Test()]
            public void GithubRequestWithType()
            {
   			    var baseGithubRequest = new GithubSharp.Core.GithubRequestWithReturnType<GithubSharp.Core.Models.Commit>(
				    new GithubSharp.Plugins.LogProviders.NullLogger.NullLogger(true),
				    new GithubSharp.Plugins.CacheProviders.NullCacher.NullCacher(),
				    new GithubSharp.Plugins.AuthProviders.NullAuthProvider.NullAuthProvider(),
				    "repos/erikzaadi/GithubSharp/git/commits/725f7bbf87ab0979a080e4daaa8a9dd2b9d89489"
				    );
	             
                var commit = baseGithubRequest.GetResponseWithReturnType();

                Assert.IsNotNull(commit);
                Assert.IsNotNull(commit.Result);
                Assert.IsNotNullOrEmpty(commit.Result.sha);
                Assert.IsNotNull(commit.Result.committer.date);
                Assert.IsNotNull(commit.Result.author.name);
				Assert.IsNotNull(commit.Result.message);
				Assert.IsNotNull(commit.Result.parents);
                Assert.IsTrue(commit.Result.parents.Count > 0);
				Assert.IsNotNull(commit.Result.tree.sha);
            }
		[Test]
		public void GithubRequestWithInput()
		{
			var gistFiles = new Dictionary<string,GithubSharp.Core.Models.GistFileForCreation>();
			gistFiles.Add(
				"fileName.txt",
				new GithubSharp.Core.Models.GistFileForCreation
			{
				content = "bla bla"
			});
			
			var gistToCreate = new GithubSharp.Core.Models.GistToCreateOrEdit
			{
				@public = true,
				description = "testGist",
				files = gistFiles
			};
			var baseGithubRequest = new GithubSharp.Core.GithubRequestWithInputAndReturnType
					<GithubSharp.Core.Models.GistToCreateOrEdit, GithubSharp.Core.Models.Gist>(
					    new GithubSharp.Plugins.LogProviders.NullLogger.NullLogger(true),
					    new GithubSharp.Plugins.CacheProviders.NullCacher.NullCacher(),
					    new GithubSharp.Plugins.AuthProviders.UserPasswordAuthProvider.UserPasswordAuthProvider
								(TestSettings.Username, TestSettings.Password),
					    "gists",
						"POST",
						gistToCreate
			    );
			
			GithubSharp.Core.IGithubResponseWithReturnType<GithubSharp.Core.Models.Gist> response = null;
			
			try
			{
				response = baseGithubRequest.GetResponseWithReturnType();
			}
			catch (Exception err)
			{
				if (err is GithubSharp.Core.GithubError)
				{
					var githuberr = err as GithubSharp.Core.GithubError;
					Assert.Fail("StatusCode : {0}, StatusText : {1}, Message : {2}",
						githuberr.StatusCode, githuberr.StatusText, githuberr.GithubErrorResult.message);
					return;
				}
				else
				{
					Assert.Fail(err.Message);
					return;
				} 
			}
	        Assert.IsNotNull(response.Result);
			Assert.AreEqual(response.Result.description , gistToCreate.description);
			
			Assert.AreEqual(response.Result.files["fileName.txt"].content, gistToCreate.files["fileName.txt"].content);
			
			//Let's clean up 
			var gistDeleteRequest = new GithubSharp.Core.GithubRequest(
				new GithubSharp.Plugins.LogProviders.NullLogger.NullLogger(true),
					    new GithubSharp.Plugins.CacheProviders.NullCacher.NullCacher(),
					    new GithubSharp.Plugins.AuthProviders.UserPasswordAuthProvider.UserPasswordAuthProvider
								(TestSettings.Username, TestSettings.Password),
						string.Format("gists/{0}", response.Result.id),
						"DELETE"
				
				);
			
			var deleteResult = gistDeleteRequest.GetResponse();
			
			
			Assert.IsNotNull(deleteResult);
			
			Assert.AreEqual(deleteResult.StatusCode, 204);
			
		}
	}
}


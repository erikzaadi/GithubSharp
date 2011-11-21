using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace CoreTests
{
	[TestFixture]
	public class GistModelTest
	{
		[Test]
		public void TestCreateEditAndDelete()
		{
			var gistModel = new GithubSharp.Core.API.Gist(
					    new GithubSharp.Plugins.LogProviders.NullLogger.NullLogger(true),
					    new GithubSharp.Plugins.CacheProviders.NullCacher.NullCacher(),
					    new GithubSharp.Plugins.AuthProviders.UserPasswordAuthProvider.UserPasswordAuthProvider
								(TestSettings.Username, TestSettings.Password));
			
			var gistFiles = new Dictionary<string,GithubSharp.Core.Models.GistFileForCreation>();
			gistFiles.Add(
				"fileName.txt",
				new GithubSharp.Core.Models.GistFileForCreation
			{
				content = System.Guid.NewGuid().ToString()
			});
			
			
			var toCreate = new GithubSharp.Core.Models.GistToCreateOrEdit
			{
				description = "test gist",
				@public = false,
				files = gistFiles
			};
			
			var createdGist = gistModel.Create(toCreate);
			
			Assert.IsNotNull(createdGist);
			Assert.AreEqual(createdGist.description, toCreate.description);
			Assert.AreEqual(createdGist.files["fileName.txt"].content, toCreate.files["fileName.txt"].content);
			
			toCreate.files["fileName.txt"].content = System.Guid.NewGuid().ToString();
			
			var editedGist = gistModel.Edit(createdGist.id, toCreate);
			
			Assert.AreEqual(editedGist.files["fileName.txt"].content, toCreate.files["fileName.txt"].content);
			Assert.AreNotEqual(editedGist.files["fileName.txt"].content, createdGist.files["fileName.txt"].content);
			Assert.AreEqual(editedGist.id, createdGist.id);
			
			gistModel.Delete(editedGist.id);
		}
	}
}


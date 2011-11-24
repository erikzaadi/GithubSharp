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
			var gistModel = GetAuthenticatedGistAPI();
			
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
		
		[Test]
		public void PublicGistsTest()
		{
			var gistModel = GetAuthenticatedGistAPI();
			
			var publicGists = gistModel.Public();
			
			Assert.IsNotNull(publicGists);
			Assert.IsTrue(new List<GithubSharp.Core.Models.Gist>(publicGists).Count > 0);
		}
		
		[Test]
		public void GistStarTest()
		{
			var gistModel = GetAuthenticatedGistAPI();
			
			var createdGist = CreateGist(gistModel);
			
			Assert.IsFalse(gistModel.HasStar(createdGist.id));
			
			gistModel.Star(createdGist.id);
			
			Assert.IsTrue(gistModel.HasStar(createdGist.id));
			
			gistModel.Unstar(createdGist.id);
			
			Assert.IsFalse(gistModel.HasStar(createdGist.id));
			
			gistModel.Delete(createdGist.id);
		}
		
		[Test]
		public void GistCommentsTest()
		{
			var gistAPI = GetAuthenticatedGistAPI();
			var createdGist = CreateGist(gistAPI);
			
			var gistComments = gistAPI.ListComments(createdGist.id);
			
			Assert.IsTrue(gistComments == null || new List<GithubSharp.Core.Models.GistComment>(gistComments).Count == 0);
			
			var gistComment = new GithubSharp.Core.Models.GistCommentForCreationOrEdit { body = System.Guid.NewGuid().ToString()};
			
			var createdGistComment = gistAPI.CreateComment(createdGist.id,gistComment);
			
			Assert.AreEqual(createdGistComment.body, gistComment.body);
			
			Assert.IsTrue(new List<GithubSharp.Core.Models.GistComment>(gistAPI.ListComments(createdGist.id)).Count == 1);
			
			var editedGistCommentToSend = new GithubSharp.Core.Models.GistCommentForCreationOrEdit { body = createdGistComment.body + " aha!"};
			
			var editedGistComment = gistAPI.EditComment(createdGistComment.id, 
				editedGistCommentToSend);
			
			Assert.AreNotEqual(editedGistComment.body, createdGistComment.body);
			
			//To fast?
			//Assert.AreNotEqual(editedGistComment.created_at, createdGistComment.created_at);
			//Assert.IsTrue(editedGistComment.created_at >  createdGistComment.created_at);
			Assert.AreEqual(editedGistComment.body, editedGistCommentToSend.body);
			Assert.AreEqual(createdGistComment.id, editedGistComment.id);
			
			var retrievedComment = gistAPI.GetComment(createdGistComment.id);
			
			Assert.AreEqual(editedGistComment.body, retrievedComment.body);
			Assert.AreEqual(createdGistComment.id, retrievedComment.id);
			Assert.AreEqual(editedGistComment.created_at, retrievedComment.created_at);
			
			gistAPI.DeleteComment(retrievedComment.id);
			
			Assert.IsTrue(new List<GithubSharp.Core.Models.GistComment>(gistAPI.ListComments(createdGist.id)).Count == 0);
		}
		
		private GithubSharp.Core.API.Gist GetAuthenticatedGistAPI()
		{
			return new GithubSharp.Core.API.Gist(
			    new GithubSharp.Plugins.LogProviders.NullLogger.NullLogger(true),
			    new GithubSharp.Plugins.CacheProviders.NullCacher.NullCacher(),
			    new GithubSharp.Plugins.AuthProviders.UserPasswordAuthProvider.UserPasswordAuthProvider
						(TestSettings.Username, TestSettings.Password));
		}
		
		private GithubSharp.Core.Models.Gist CreateGist(GithubSharp.Core.API.Gist gistAPI)
		{
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
			
			var createdGist = gistAPI.Create(toCreate);
			
			return createdGist;
		}
	}
}


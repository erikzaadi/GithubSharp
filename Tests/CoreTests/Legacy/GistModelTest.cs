using CoreTests;
using NUnit.Framework;
using System.Collections.Generic;

namespace GithubSharp.Tests.CoreTests
{
    [TestFixture]
    public class GistModelTest
    {
        [Test]
        public void TestCreateEditAndDelete()
        {
            var gistModel = GetAuthenticatedGistApi();

            var gistFiles = new Dictionary<string, Core.Models.GistFileForCreation>
                                {
                                    {
                                        "fileName.txt", new Core.Models.GistFileForCreation
                                                            {
                                                                content = System.Guid.NewGuid().ToString()
                                                            }
                                        }
                                };


            var toCreate = new Core.Models.GistToCreateOrEdit
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
            var gistModel = GetAuthenticatedGistApi();

            var publicGists = gistModel.Public();

            Assert.IsNotNull(publicGists);
            Assert.IsTrue(new List<Core.Models.Gist>(publicGists).Count > 0);
        }

        [Test]
        public void GistStarTest()
        {
            var gistModel = GetAuthenticatedGistApi();

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
            var gistApi = GetAuthenticatedGistApi();
            var createdGist = CreateGist(gistApi);

            var gistComments = gistApi.ListComments(createdGist.id);

            Assert.IsTrue(gistComments == null || new List<Core.Models.Comment>(gistComments).Count == 0);

            var gistComment = new Core.Models.CommentForCreationOrEdit { body = System.Guid.NewGuid().ToString() };

            var createdGistComment = gistApi.CreateComment(createdGist.id, gistComment);

            Assert.AreEqual(createdGistComment.body, gistComment.body);

            Assert.IsTrue(new List<Core.Models.Comment>(gistApi.ListComments(createdGist.id)).Count == 1);

            var editedGistCommentToSend = new Core.Models.CommentForCreationOrEdit { body = createdGistComment.body + " aha!" };

            var editedGistComment = gistApi.EditComment(createdGistComment.id,
                editedGistCommentToSend);

            Assert.AreNotEqual(editedGistComment.body, createdGistComment.body);

            //To fast?
            //Assert.AreNotEqual(editedGistComment.created_at, createdGistComment.created_at);
            //Assert.IsTrue(editedGistComment.created_at >  createdGistComment.created_at);
            Assert.AreEqual(editedGistComment.body, editedGistCommentToSend.body);
            Assert.AreEqual(createdGistComment.id, editedGistComment.id);

            var retrievedComment = gistApi.GetComment(createdGistComment.id);

            Assert.AreEqual(editedGistComment.body, retrievedComment.body);
            Assert.AreEqual(createdGistComment.id, retrievedComment.id);
            Assert.AreEqual(editedGistComment.created_at, retrievedComment.created_at);

            gistApi.DeleteComment(retrievedComment.id);

            Assert.IsTrue(new List<Core.Models.Comment>(gistApi.ListComments(createdGist.id)).Count == 0);
        }

        private static Core.API.Gist GetAuthenticatedGistApi()
        {
            return new Core.API.Gist(
                new Plugins.LogProviders.NullLogger.NullLogger(true),
                new Plugins.CacheProviders.NullCacher.NullCacher(),
                new Plugins.AuthProviders.UserPasswordAuthProvider.UserPasswordAuthProvider
                        (TestSettings.Username, TestSettings.Password));
        }

        private static Core.Models.Gist CreateGist(Core.API.Gist gistApi)
        {
            var gistFiles = new Dictionary<string, Core.Models.GistFileForCreation>
                                {
                                    {
                                        "fileName.txt", new Core.Models.GistFileForCreation
                                                            {
                                                                content = System.Guid.NewGuid().ToString()
                                                            }
                                        }
                                };


            var toCreate = new Core.Models.GistToCreateOrEdit
            {
                description = "test gist",
                @public = false,
                files = gistFiles
            };

            var createdGist = gistApi.Create(toCreate);

            return createdGist;
        }
    }
}


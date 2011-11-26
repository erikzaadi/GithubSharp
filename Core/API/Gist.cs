using GithubSharp.Core.Services;
using System.Collections.Generic;
using GithubSharp.Core.Base;

namespace GithubSharp.Core.API
{
    public class Gist : GithubApiBase
    {
        public Gist(
            ILogProvider logProvider,
            ICacheProvider cacheProvider,
            IAuthProvider authProvider)
            : base(
                logProvider,
                cacheProvider,
                authProvider) { }

        public IEnumerable<Models.Gist> List(string username)
        {
            return Get<IEnumerable<Models.Gist>>(
                string.Format(
                    "users/{0}/gists",
                    username),
                GithubSharpHttpVerbs.Get).Result;
        }
        public IEnumerable<Models.Gist> List()
        {
            return Get<IEnumerable<Models.Gist>>(
                string.Format(
                    "users/{0}/gists",
                    AuthProvider.Username),
                GithubSharpHttpVerbs.Get).Result;
        }

        public IEnumerable<Models.Gist> Public()
        {
            return Get<IEnumerable<Models.Gist>>(
                "gists/public",
                GithubSharpHttpVerbs.Get).Result;
        }

        public IEnumerable<Models.Gist> Starred()
        {
            return Get<IEnumerable<Models.Gist>>(
                "gists/starred",
                GithubSharpHttpVerbs.Get).Result;
        }

        public Models.Gist Get(string id)
        {
            return Get<Models.Gist>(
                string.Format(
                    "gists/{0}",
                    id),
                GithubSharpHttpVerbs.Get).Result;
        }

        public Models.Gist Create(Models.GistToCreateOrEdit gist)
        {
            return Get<Models.Gist, Models.GistToCreateOrEdit>(
                "gists",
                GithubSharpHttpVerbs.Post,
                gist).Result;
        }

        public Models.Gist Edit(string id, Models.GistToCreateOrEdit gist)
        {
            return Get<Models.Gist, Models.GistToCreateOrEdit>(
                string.Format(
                    "gists/{0}",
                    id),
                GithubSharpHttpVerbs.Patch,
                gist).Result;
        }

        public void Star(string id)
        {
            Get(
                string.Format(
                    "gists/{0}/star",
                    id),
                GithubSharpHttpVerbs.Put);
        }

        public void Unstar(string id)
        {
            Get(
                string.Format(
                    "gists/{0}/star",
                    id),
                GithubSharpHttpVerbs.Delete);
        }

        public bool HasStar(string id)
        {
            return Get(
                string.Format(
                    "gists/{0}/star",
                    id),
                GithubSharpHttpVerbs.Get
                ).StatusCode == 204;
        }

        public Models.Gist Fork(string id)
        {
            return Get<Models.Gist>(
                string.Format(
                    "gists/{0}/fork",
                    id),
                GithubSharpHttpVerbs.Post).Result;
        }

        public void Delete(string id)
        {
            Get(
                string.Format(
                    "gists/{0}",
                    id),
                GithubSharpHttpVerbs.Delete);

        }

        public IEnumerable<Models.Comment> ListComments(string gistid)
        {
            return Get<IEnumerable<Models.Comment>>(
                string.Format(
                    "gists/{0}/comments",
                    gistid),
                GithubSharpHttpVerbs.Get).Result;
        }

        public Models.Comment CreateComment(string gistid, Models.CommentForCreationOrEdit comment)
        {
            return Get<Models.Comment, Models.CommentForCreationOrEdit>(
                string.Format(
                    "gists/{0}/comments",
                    gistid),
                GithubSharpHttpVerbs.Post,
                comment).Result;
        }


        public Models.Comment GetComment(string gistcommentid)
        {
            return Get<Models.Comment>(
                string.Format(
                    "gists/comments/{0}",
                    gistcommentid),
                GithubSharpHttpVerbs.Get).Result;
        }

        public Models.Comment EditComment(string gistcommentid, Models.CommentForCreationOrEdit comment)
        {
            return Get<Models.Comment, Models.CommentForCreationOrEdit>(
                string.Format(
                    "gists/comments/{0}",
                    gistcommentid),
                GithubSharpHttpVerbs.Patch,
                comment).Result;
        }

        public void DeleteComment(string gistcommentid)
        {
            Get(
                string.Format(
                    "gists/comments/{0}",
                    gistcommentid),
                GithubSharpHttpVerbs.Delete);
        }


    }
}

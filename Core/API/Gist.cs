using GithubSharp.Core.Services;
using System.Collections.Generic;
using GithubSharp.Core.Base;

namespace GithubSharp.Core.API
{
    public class Gist : Base.GithubApiBase
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
			return base.Get<IEnumerable<Models.Gist>>(
				string.Format(
					"users/{0}/gists", 
					username), 
				GithubSharpHttpVerbs.GET).Result;
		}		
		public IEnumerable<Models.Gist> List()
		{
			return base.Get<IEnumerable<Models.Gist>>(
				string.Format(
					"users/{0}/gists", 
					base.AuthProvider.Username), 
				GithubSharpHttpVerbs.GET).Result;
		}
		
		public IEnumerable<Models.Gist> Public()
		{
			return base.Get<IEnumerable<Models.Gist>>(
				"gists/public",
				GithubSharpHttpVerbs.GET).Result;
		}
		
		public IEnumerable<Models.Gist> Starred()
		{
			return base.Get<IEnumerable<Models.Gist>>(
				"gists/starred",
				GithubSharpHttpVerbs.GET).Result;
		}
		
		public Models.Gist Get(string id)
		{
			return base.Get<Models.Gist>(
				string.Format(
					"gists/{0}", 
					id),
				GithubSharpHttpVerbs.GET).Result;
		}
		
		public Models.Gist Create(Models.GistToCreateOrEdit gist)
		{
			return base.Get<Models.Gist, Models.GistToCreateOrEdit>(
				"gists", 
				GithubSharpHttpVerbs.POST,
				gist).Result;
		}
		
		public Models.Gist Edit(string id, Models.GistToCreateOrEdit gist)
		{
			return base.Get<Models.Gist, Models.GistToCreateOrEdit>(
				string.Format(
					"gists/{0}", 
					id),
				GithubSharpHttpVerbs.PATCH,
				gist).Result;
		}
		
		public void Star(string id)
		{
			base.Get(
				string.Format(
					"gists/{0}/star",
					id),
				GithubSharpHttpVerbs.PUT);
		}
		
		public void Unstar(string id)
		{
			base.Get(
				string.Format(
					"gists/{0}/star",
					id),
				GithubSharpHttpVerbs.DELETE);
		}
   
		public bool HasStar(string id)
		{
			return base.Get(
				string.Format(
					"gists/{0}/star",
					id),
				GithubSharpHttpVerbs.GET
				).StatusCode == 204;
		}
		
		public Models.Gist Fork(string id)
		{
			return base.Get<Models.Gist>(
				string.Format(
					"gists/{0}/fork",
					id),
				GithubSharpHttpVerbs.POST).Result;
		}
		
		public void Delete(string id)
		{
			base.Get(
				string.Format(
					"gists/{0}",
					id),
				GithubSharpHttpVerbs.DELETE);
				
		}
		
		public IEnumerable<Models.Comment> ListComments (string gistid)
		{
			return base.Get<IEnumerable<Models.Comment>>(
				string.Format(
					"gists/{0}/comments",
					gistid),
				GithubSharpHttpVerbs.GET).Result;
		}
		
		public Models.Comment CreateComment(string gistid, Models.CommentForCreationOrEdit comment)
		{
			return base.Get<Models.Comment, Models.CommentForCreationOrEdit>(
				string.Format(
					"gists/{0}/comments",
					gistid),
				GithubSharpHttpVerbs.POST,
				comment).Result;
		}
		
		
		public Models.Comment GetComment(string gistcommentid)
		{
			return base.Get<Models.Comment>(
				string.Format(
					"gists/comments/{0}",
					gistcommentid),
				GithubSharpHttpVerbs.GET).Result;
		}
		
		public Models.Comment EditComment(string gistcommentid, Models.CommentForCreationOrEdit comment)
		{
			return base.Get<Models.Comment, Models.CommentForCreationOrEdit>(
				string.Format(
					"gists/comments/{0}",
					gistcommentid),
				GithubSharpHttpVerbs.PATCH,
				comment).Result;
		}
		
		public void DeleteComment(string gistcommentid)
		{
			base.Get(
				string.Format(
					"gists/comments/{0}",
					gistcommentid),
				GithubSharpHttpVerbs.DELETE);
		}

			
    }
}

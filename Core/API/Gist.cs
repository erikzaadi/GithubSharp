using GithubSharp.Core.Services;
using System.Collections.Generic;

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
				"GET").Result;
		}		
		public IEnumerable<Models.Gist> List()
		{
			return base.Get<IEnumerable<Models.Gist>>(
				string.Format(
					"users/{0}/gists", 
					base.AuthProvider.Username), 
				"GET").Result;
		}
		
		public IEnumerable<Models.Gist> Public()
		{
			return base.Get<IEnumerable<Models.Gist>>(
				"gists/public",
				"GET").Result;
		}
		
		public IEnumerable<Models.Gist> Starred()
		{
			return base.Get<IEnumerable<Models.Gist>>(
				"gists/starred",
				"GET").Result;
		}
		
		public Models.Gist Get(string id)
		{
			return base.Get<Models.Gist>(
				string.Format(
					"gists/{0}", 
					id),
				"GET").Result;
		}
		
		public Models.Gist Create(Models.GistToCreateOrEdit gist)
		{
			return base.Get<Models.Gist, Models.GistToCreateOrEdit>(
				"gists", 
				"POST",
				gist).Result;
		}
		
		public Models.Gist Edit(string id, Models.GistToCreateOrEdit gist)
		{
			return base.Get<Models.Gist, Models.GistToCreateOrEdit>(
				string.Format(
					"gists/{0}", 
					id),
				"PATCH",
				gist).Result;
		}
		
		public void Star(string id)
		{
			base.Get(
				string.Format(
					"gists/{0}/star",
					id),
				"PUT");
		}
		
		public void Unstar(string id)
		{
			base.Get(
				string.Format(
					"gists/{0}/star",
					id),
				"DELETE");
		}
   
		public bool HasStar(string id)
		{
			return base.Get(
				string.Format(
					"gists/{0}/star",
					id),
				"GET"
				).StatusCode == 204;
		}
		
		public Models.Gist Fork(string id)
		{
			return base.Get<Models.Gist>(
				string.Format(
					"gists/{0}/fork",
					id),
				"POST").Result;
		}
		
		public void Delete(string id)
		{
			base.Get(
				string.Format(
					"gists/{0}",
					id),
				"DELETE");
				
		}
			
    }
}

//add commit compare : http://github.com/blog/612-introducing-github-compare-view

namespace GithubSharp.Core
{
	public class Github
	{

        public Models.GithubUser _User { get; set; }
        public GithubURLs _GithubURLs { get; set; }

        public Github(Services.ICacheProvider CacheProvider, Models.GithubUser user)
		{
            _User = user;
            _GithubURLs = new GithubURLs { User = user };
		}
		/*
		#region Public Methods
		
		public IList<Domain.Models.Commit> GetCommits(string Repository)
		{
			string cacheKey = string.Format("_CacheProvider_Commits_{0}_{1}_{2}", _User.Name, Repository, _User.APIToken);
            var cached = _CacheProvider.Get<IList<Domain.Models.Commit>>(
                cacheKey);
            if (cached != null)
                return cached;

            string url = string.Format(GithubURLs.Commits, _User.Name, Repository, _User.APIToken);
			
            var result = _GetXMLFromURL(url);
            if (result == null)
                return null;

            var commitArray = result.Descendants("commit");
			var commits = commitArray.Select(commit=>GetCommitFromXMLNode(commit)).ToList();
            _CacheProvider.Set(commits, cacheKey);
			
			return commits;
		}
		
   		public IList<Domain.Models.Repository> GetRepositories()
        {
            string cacheKey = string.Format("_CacheProvider_Repositories_{0}_{1}", _User.Name, _User.APIToken);
            var cached = _CacheProvider.Get<IList<Domain.Models.Repository>>(
                cacheKey);
            if (cached != null)
                return cached;

            string url = string.Format(GithubURLs.GetRepos, _User.Name, _User.APIToken);
            var result = _GetXMLFromURL(url);
            if (result == null)
                return null;

            var repArray = result.Descendants("repository");
            var reps = repArray.Select(rep=>GetRepositoryFromXMLNode(rep)).ToList();

            _CacheProvider.Set(reps, cacheKey);

            return reps;
        }

        public Domain.Models.Repository GetRepository(string RepositoryName)
        {
            string cacheKey = string.Format("_CacheProvider_Repository_{0}_{1}", Username, RepositoryName);
            var cached = _CacheProvider.Get<Domain.Models.Repository>(
                cacheKey);
            if (cached != null)
                return cached;
			Domain.Models.Repository current = null;
			 
			//If we have all repositories cached, fetch the repository from the cached collection
			string ReposCacheKey = string.Format("_CacheProvider_Repositories_{0}", Username);
            var cachedRepos = _CacheProvider.Get<IList<Domain.Models.Repository>>(
                ReposCacheKey);
            if (cachedRepos != null)
			{
				current = cachedRepos.SingleOrDefault(repo => repo.Name == RepositoryName);
			}
			else
			{
				string url = string.Format(GithubURLs.GetRepo, Username, RepositoryName);
	            var result = _GetXMLFromURL(url);
	            if (result == null)
	                return null;
				current = GetRepositoryFromXMLNode(result.Element("repository"));
			}
		
			if (current == null)
				return null;
			
			_CacheProvider.Set(current, cacheKey);

            return current;
        }
		
		public byte[] GetBlobBinaryContent(string RepositoryName, string BlobSha)
		{
			var url = string.Format(GithubURLs.BlobOrTree, Username, RepositoryName, BlobSha);
			if (!_VerifyURL(url))
			{
				return null;
			}
			return _GetBytesFromURL(url);
		}
		
		public string GetBlobURL(string RepositoryName, string BlobSha)
		{
			var url = string.Format(GithubURLs.BlobOrTree, Username, RepositoryName, BlobSha);
			if (!_VerifyURL(url))
			{
				return null;
			}
			return url;
		}
		
		public string GetBlobStringContent(string RepositoryName, string BlobSha)
		{
			var url = string.Format(GithubURLs.BlobOrTree, Username, RepositoryName, BlobSha);
			if (!_VerifyURL(url))
			{
				return null;
			}
			return _GetStringFromURL(url);
		}

        public string GetFileContent(string RepositoryName, string FileName)
        {
            var assetURL = GetFileURL(RepositoryName, FileName);
            if (string.IsNullOrEmpty(assetURL))
                return null;

            return _GetStringFromURL(assetURL);
        }

        public byte[] GetFileContentStream(string RepositoryName, string FileName)
        {
            var assetURL = GetFileURL(RepositoryName, FileName);
            if (string.IsNullOrEmpty(assetURL))
                return null;

            return _GetBytesFromURL(assetURL);
        }

        public string GetFileURL(string RepositoryName, string FileName)
        {
             var assetURL = _GetAssetURL(RepositoryName, FileName);
            return _VerifyURL(assetURL) ? assetURL : null;
        }
		
		public Domain.Models.Tree GetTree(string RepositoryName, string TreeSHA)
		{
			 string cacheKey = string.Format("_CacheProvider_GetTree_{0}_{1}_{1}", Username, RepositoryName, TreeSHA);
            var cached = _CacheProvider.Get<Domain.Models.Tree>(
                cacheKey);
            if (cached != null)
                return cached;
			Domain.Models.Tree current = null;
			
			string url = string.Format(GithubURLs.BlobOrTree, Username, RepositoryName, TreeSHA);
            var result = _GetStringFromURL(url);
            if (result == null)
                return null;
			current = GetTreeFromYaml(result);
			
			if (current == null)
				return null;
			current.RepositoryName = RepositoryName;
			current.Sha = TreeSHA;
			
			_CacheProvider.Set(current, cacheKey);

            return current;
		}

		#endregion Public Methods
		
		#region Private Helpers

        private bool _VerifyURL(string url)
        {
            string cacheKey = string.Format("VerifyURL_{0}", url);
            var cached = _CacheProvider.Get<string>(
                cacheKey);
            if (cached != null)
                return bool.Parse(cached);

            try
            {
                var webRequest = WebRequest.Create(url);
                webRequest.Method = "HEAD";
				if (!webRequest.GetResponse().Headers["Status"].ToLower().Contains("200"))
					return false;
            }
            catch 
            {
                return false;
            }

            _CacheProvider.Set(true.ToString(), cacheKey);
            return true;
        }

        private string _GetAssetURL(string RepositoryName, string FileName)
        {
            return string.Format(GithubURLs.RawFile, Username, RepositoryName, FileName);
        }

        private string _GetStringFromURL(string url)
        {
            string cacheKey = string.Format("GetStringFromURL_{0}", url);
            var cached = _CacheProvider.Get<string>(
                cacheKey);
            if (cached != null)
                return cached;
            var webClient = new WebClient();
            string result = null;
            try
            {
                result = webClient.DownloadString(url);
            }
            catch
            {
                return null;
            }

            _CacheProvider.Set(result, cacheKey);
            return result;
        }

        private byte[] _GetBytesFromURL(string url)
        {
            string cacheKey = string.Format("GetBytesFromURL_{0}", url);
            var cached = _CacheProvider.Get<byte[]>(
                cacheKey);
            if (cached != null)
                return cached;
            var webClient = new WebClient();
            byte[] result = null;
            try
            {
                result = webClient.DownloadData(url);
            }
            catch
            {
                return null;
            }

            _CacheProvider.Set(result, cacheKey);
            return result;
        }

        private XDocument _GetXMLFromURL(string URL)
        {
            string cacheKey = string.Format("GetXMLFromURL_{0}", URL);
            var cached = _CacheProvider.Get<XDocument>(
                cacheKey);
            if (cached != null)
                return cached;
            string resultXML = _GetStringFromURL(URL);
            if (string.IsNullOrEmpty(resultXML))
                return null;

            XDocument result = null;
            try
            {
                result = XDocument.Parse(resultXML);
            }
            catch
            {
                return null;
            }
            _CacheProvider.Set(result, cacheKey);
            return result;
        }
		
        private string ElementValueSingleOrDefault(XElement element, string name)
        {
            return element.Element(name) != null && !string.IsNullOrEmpty(element.Element(name).Value) ? element.Element(name).Value : "";
        }
		
		private Domain.Models.Repository GetRepositoryFromXMLNode(XElement RepNode)
		{
			return new Domain.Models.Repository
                  {
                      Url = ElementValueSingleOrDefault(RepNode, "url"),
                      Description = ElementValueSingleOrDefault(RepNode, "description"),
                      Homepage = ElementValueSingleOrDefault(RepNode, "homepage"),
                      Name = ElementValueSingleOrDefault(RepNode, "name"),
                      Owner = ElementValueSingleOrDefault(RepNode, "owner"),
                      OpenIssues = int.Parse(ElementValueSingleOrDefault(RepNode, "open-issues")),
                      Watchers = int.Parse(ElementValueSingleOrDefault(RepNode, "watchers")),
                      Forks = int.Parse(ElementValueSingleOrDefault(RepNode, "forks")),
                      Fork = bool.Parse(ElementValueSingleOrDefault(RepNode, "fork")),
                      IsPrivate = bool.Parse(ElementValueSingleOrDefault(RepNode, "private"))
                  };
		}
		
		private Domain.Models.Person GetPersonFromXMLNode(XElement personNode)
		{
			return new Domain.Models.Person
			{
				Email = ElementValueSingleOrDefault(personNode, "email"),
				Login = ElementValueSingleOrDefault(personNode, "login"),
				Name = ElementValueSingleOrDefault(personNode, "name")
			};
		}
		
		private Domain.Models.Commit GetCommitFromXMLNode(XElement commitNode)
		{
			return new Domain.Models.Commit
                  {
                      Url = ElementValueSingleOrDefault(commitNode, "url"),                     
                      ID = ElementValueSingleOrDefault(commitNode, "id"),
                      Message = ElementValueSingleOrDefault(commitNode, "message"),
                      Tree = ElementValueSingleOrDefault(commitNode, "tree"),
					  Committed = DateTime.Parse( ElementValueSingleOrDefault(commitNode, "committed-date")),
					  Authored = DateTime.Parse( ElementValueSingleOrDefault(commitNode, "authored-date")),
					  Author = GetPersonFromXMLNode(commitNode.Element("author")),
					  Committer = GetPersonFromXMLNode(commitNode.Element("committer"))//,
					  //ParentCommitIDs = commitNode.Element("parents").Elements("parent").Select(p=> int.Parse(ElementValueSingleOrDefault(p,"id"))).ToList()
                  };
		}
		
		private Domain.Models.Tree GetTreeFromYaml (string result)
		{
			var toReturn = new Domain.Models.Tree();
			var items = new List<Domain.Models.BlobItem>();
			foreach (string line in result.Split(new char[]{'\n'}))
			{
				var yammeld = line.Split(new char[]{'\t'});
				var details = yammeld[0].Split(new char[]{' '});
				
				items.Add(new Domain.Models.BlobItem
				          {
					Name = yammeld[1],
					Sha = details[2],
					Type = details[1] == "tree" ? Domain.Models.BlobItemType.Tree : Domain.Models.BlobItemType.Blob
				});
			}
			
			toReturn.BlobItems = items;
			
			return toReturn;
		}
		
		#endregion Private Helpers
*/
	}
}

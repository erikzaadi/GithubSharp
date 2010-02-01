using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GithubSharp.Core.Base
{
    internal class Url
    {
        internal Url(Services.ICacheProvider cacheProvider)
        {
            _CacheProvider = cacheProvider;
        }

        internal Services.ICacheProvider _CacheProvider;

        internal string GithubBaseURL { get { return "http://github.com/api/v2/json/"; } }
       
        internal string GithubAuthenticationQueryString(GithubSharp.Core.Models.GithubUser User)
        {
            return User != null ?  string.Format("?login={0}&token={1}", User.Name, User.APIToken) : string.Empty;
        }
       
        internal string _GetStringFromURL(string url)
        {
            string cacheKey = string.Format("GetStringFromURL_{0}", url);
            var cached = _CacheProvider.Get<string>(
                cacheKey);
            if (cached != null)
                return cached;
            var webClient = new System.Net.WebClient();
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

    }
}

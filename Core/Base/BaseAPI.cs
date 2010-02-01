using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GithubSharp.Core.Base
{
    public class BaseAPI
    {
        protected BaseAPI(Services.ICacheProvider cacheProvider) : this(cacheProvider, null) { }

        protected BaseAPI(Services.ICacheProvider cacheProvider, Models.GithubUser CurrentUser)
        {
            _Url = new GithubSharp.Core.Base.Url(cacheProvider);
            _CurrentUser = CurrentUser;
        }

        private Models.GithubUser _CurrentUser { get; set; }
        private Base.Url _Url { get; set; }

        protected T ConsumeJsonUrl<T>(string Url) where T : class
        {
            var url = string.Format("{0}{1}{2}", 
                _Url.GithubBaseURL, 
                Url, 
                _Url.GithubAuthenticationQueryString(_CurrentUser));
            var result = _Url._GetStringFromURL(url);
            if (result == null)
                return null;
            return Base.JsonConverter.FromJson<T>(result);
        }

        protected void Authenticate()
        {
            if (!HasUser)
                throw new Exception("You need to provide a valid GithubUser with an api token (see http://github.com/blog/170-token-authentication)");
        }

        protected string Username { get { return HasUser ? _CurrentUser.Name : string.Empty; } }

        protected bool HasUser { get { return _CurrentUser != null && !string.IsNullOrEmpty(_CurrentUser.Name) && !string.IsNullOrEmpty(_CurrentUser.APIToken); } }
    }
}

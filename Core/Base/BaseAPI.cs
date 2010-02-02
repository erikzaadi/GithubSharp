using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GithubSharp.Core.Services;
using System.Collections.Specialized;

namespace GithubSharp.Core.Base
{
    public class BaseAPI
    {
        protected BaseAPI(
            ICacheProvider cacheProvider,
            ILogProvider logProvider)
            : this(cacheProvider, logProvider, null) { }

        protected BaseAPI(
            ICacheProvider cacheProvider,
            ILogProvider logProvider,
            Models.GithubUser CurrentUser)
        {
            _Url = new GithubSharp.Core.Base.Url(cacheProvider, logProvider);
            _CurrentUser = CurrentUser;
        }

        private Models.GithubUser _CurrentUser { get; set; }
        private Base.Url _Url { get; set; }

        protected ILogProvider LogProvider { get { return _Url._LogProvider; } }

        protected T ConsumeJsonUrl<T>(string Url) where T : class
        {
            var url = string.Format("{0}{1}{2}",
                _Url.GithubBaseURL,
                Url,
                _Url.GithubAuthenticationQueryString(_CurrentUser));
            var result = _Url.GetStringFromURL(url);
            if (result == null)
                return null;
            try
            {
                return Base.JsonConverter.FromJson<T>(result);
            }
            catch (Exception error)
            {
                LogProvider.HandleError(error);
                return null;
            }
        }

        protected T ConsumeJsonUrlAndPostData<T>(string Url) where T : class
        {
            return ConsumeJsonUrlAndPostData<T>(Url, new NameValueCollection());
        }

        protected T ConsumeJsonUrlAndPostData<T>(string Url, NameValueCollection FormValues) where T : class
        {
            var url = string.Format("{0}{1}{2}",
                _Url.GithubBaseURL,
                Url,
                _Url.GithubAuthenticationQueryString(_CurrentUser));

            var result = _Url.UploadValuesAndGetString(url, FormValues);
            if (result == null)
                return null;
            try
            {
                return Base.JsonConverter.FromJson<T>(result);
            }
            catch (Exception error)
            {
                LogProvider.HandleError(error);
                return null;
            }
        }

        protected void Authenticate()
        {
            if (!HasUser)
            {
                LogProvider.HandleError(new Exception("You need to provide a valid GithubUser with an api token (see http://github.com/blog/170-token-authentication)"));
            }
        }

        protected string CurrentUsername { get { return HasUser ? _CurrentUser.Name : string.Empty; } }

        protected bool HasUser { get { return _CurrentUser != null && !string.IsNullOrEmpty(_CurrentUser.Name) && !string.IsNullOrEmpty(_CurrentUser.APIToken); } }
    }
}

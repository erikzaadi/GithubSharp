using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GithubSharp.Core.Services;
using System.Collections.Specialized;

namespace GithubSharp.Core.Base
{
    public interface IBaseAPI
    {
        void Authenticate();
        void Authenticate(Models.GithubUser CurrentUser);
        ILogProvider LogProvider { get; set; }
        ICacheProvider CacheProvider { get; set; }
    }

    public class BaseAPI : IBaseAPI
    {
        public BaseAPI(ICacheProvider cacheProvider, ILogProvider logProvider)
        {
            CacheProvider = cacheProvider;
            LogProvider = logProvider;
        }

        private Models.GithubUser _CurrentUser { get; set; }
        private Base.Url UrlConsumer
        {
            get
            {
                if (_Url == null)
                    _Url = new Url(CacheProvider, LogProvider);
                return _Url;
            }
            set
            {
                _Url = value;
            }
        }
        private Base.Url _Url;

        public void Authenticate(Models.GithubUser CurrentUser)
        {
            if (CurrentUser == null)
                LogProvider.LogMessage("Authenticate => Null user");
            else
                LogProvider.LogMessage("Authenticate => Name : {0}, APIToken : {1}", CurrentUser.Name, CurrentUser.APIToken);

            _CurrentUser = CurrentUser;
        }

        public ICacheProvider CacheProvider { get; set; }
        public ILogProvider LogProvider { get; set; }

        internal byte[] ConsumeUrlToBinary(string Url)
        {
            var url = GetAuthenticatedUrl(Url);

            return UrlConsumer.GetBinaryFromURL(url);
        }

        internal byte[] ConsumeUrlToBinaryAndPostData(string Url)
        {
            return ConsumeUrlToBinaryAndPostData(Url, new NameValueCollection());
        }

        internal byte[] ConsumeUrlToBinaryAndPostData(string Url, NameValueCollection FormValues)
        {
            var url = GetAuthenticatedUrl(Url);

            return UrlConsumer.UploadValuesAndGetBinary(url, FormValues);
        }

        private string GetAuthenticatedUrl(string Url)
        {
            var url = string.Format("{0}{1}{2}",
                Url.StartsWith("http") ? Url : UrlConsumer.GithubBaseURL,
                Url,
                UrlConsumer.GithubAuthenticationQueryString(_CurrentUser));
            return url;
        }

        internal string ConsumeUrlToString(string Url)
        {
            var url = GetAuthenticatedUrl(Url);

            return UrlConsumer.GetStringFromURL(url);
        }

        internal string ConsumeUrlToStringAndPostData(string Url)
        {
            return ConsumeUrlToStringAndPostData(Url, new NameValueCollection());
        }

        internal string ConsumeUrlToStringAndPostData(string Url, NameValueCollection FormValues)
        {
            var url = GetAuthenticatedUrl(Url);

            return UrlConsumer.UploadValuesAndGetString(url, FormValues);
        }

        internal T ConsumeJsonUrl<T>(string Url) where T : class
        {
            var result = ConsumeUrlToString(Url);
            if (result == null)
                return null;
            try
            {
                return Base.JsonConverter.FromJson<T>(result);
            }
            catch (Exception error)
            {
                if (LogProvider.HandleAndReturnIfToThrowError(error))
                    throw;
                return null;
            }
        }

        internal T ConsumeJsonUrlAndPostData<T>(string Url) where T : class
        {
            return ConsumeJsonUrlAndPostData<T>(Url, new NameValueCollection());
        }

        internal T ConsumeJsonUrlAndPostData<T>(string Url, NameValueCollection FormValues) where T : class
        {
            var result = ConsumeUrlToStringAndPostData(Url, FormValues);
            if (result == null)
                return null;
            try
            {
                return Base.JsonConverter.FromJson<T>(result);
            }
            catch (Exception error)
            {
                if (LogProvider.HandleAndReturnIfToThrowError(error))
                    throw;
                return null;
            }
        }

        public void Authenticate()
        {
            if (!HasUser)
            {
                var error = new Exception("You need to provide a valid GithubUser with an api token (see http://github.com/blog/170-token-authentication)");
                if (LogProvider.HandleAndReturnIfToThrowError(error))
                    throw error;
            }
        }

        public string CurrentUsername { get { return HasUser ? _CurrentUser.Name : string.Empty; } }

        public bool HasUser { get { return _CurrentUser != null && !string.IsNullOrEmpty(_CurrentUser.Name) && !string.IsNullOrEmpty(_CurrentUser.APIToken); } }
    }
}

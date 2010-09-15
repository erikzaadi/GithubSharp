using System;
using GithubSharp.Core.Services;
using System.Collections.Specialized;

namespace GithubSharp.Core.Base
{
    public interface IBaseAPI
    {
        void Authenticate();
        void Authenticate(Models.GithubUser User);
        ILogProvider LogProvider { get; set; }
        ICacheProvider CacheProvider { get; set; }
    }

    public class BaseAPI : IBaseAPI
    {
        public BaseAPI(ICacheProvider Cache, ILogProvider Log)
        {
            CacheProvider = Cache;
            LogProvider = Log;
        }

        private Models.GithubUser CurrentUser { get; set; }
        private Url UrlConsumer
        {
            get { return _Url ?? (_Url = new Url(CacheProvider, LogProvider)); }
        }
        private Url _Url;

        public void Authenticate(Models.GithubUser User)
        {
            if (User == null)
                LogProvider.LogMessage("Authenticate => Null user");
            else
                LogProvider.LogMessage("Authenticate => Name : {0}, APIToken : {1}", User.Name, User.APIToken);

            CurrentUser = User;
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
                Url.StartsWith("http") ? "" : Url,
                UrlConsumer.GithubAuthenticationQueryString(CurrentUser));
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
                return JsonConverter.FromJson<T>(result);
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
                return JsonConverter.FromJson<T>(result);
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

        public string CurrentUsername { get { return HasUser ? CurrentUser.Name : string.Empty; } }

        public bool HasUser { get { return CurrentUser != null && !string.IsNullOrEmpty(CurrentUser.Name) && !string.IsNullOrEmpty(CurrentUser.APIToken); } }
    }
}

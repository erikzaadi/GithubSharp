using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.IO;
using GithubSharp.Core.Services;

namespace GithubSharp.Core.Base
{
    internal class Url
    {

        //TODO: Add ILogger for all the try-catch.. debug parameter?
        internal Url(ICacheProvider cacheProvider, ILogProvider logProvider)
        {
            _CacheProvider = cacheProvider;
            _LogProvider = logProvider;
        }

        internal ICacheProvider _CacheProvider;
        internal ILogProvider _LogProvider;

        internal string GithubBaseURL { get { return "http://github.com/api/v2/json/"; } }

        internal string GithubAuthenticationQueryString(GithubSharp.Core.Models.GithubUser User)
        {
            return User != null ? string.Format("?login={0}&token={1}", User.Name, User.APIToken) : string.Empty;
        }

        internal byte[] GetBinaryFromURL(string url)
        {
            _LogProvider.LogMessage(string.Format("Url.GetBinaryFromURL - '{0}'", url));
            string cacheKey = string.Format("GetBinaryFromURL_{0}", url);

            var cached = _CacheProvider.Get<byte[]>(
                cacheKey);
            if (cached != null)
            {
                _LogProvider.LogMessage("Url.GetBinaryFromURL  :  Returning cached result");
                return cached;
            }
            _LogProvider.LogMessage("Url.GetBinaryFromURL  :  Cached result unavailable, fetching url content");

            var webClient = new System.Net.WebClient();
            byte[] result = null;
            try
            {
                result = webClient.DownloadData(url);
            }
            catch (Exception error)
            {
                if (_LogProvider.HandleAndReturnIfToThrowError(error))
					throw;
                return null;
            }

            _CacheProvider.Set(result, cacheKey);
            return result;
        }

        internal byte[] UploadValuesAndGetBinary(string url, NameValueCollection FormValues)
        {
            return UploadValuesAndGetBinary(url, FormValues, "POST");
        }
        internal byte[] UploadValuesAndGetBinary(string url, NameValueCollection FormValues, string Method)
        {
            _LogProvider.LogMessage(
              string.Format("Url.UploadValuesAndGetBinary ({0})",
              url,
              string.Join(":", FormValues.AllKeys.ToList().Select(key => string.Format("\nKey : {0} , Value : {1}", key, FormValues[key])).ToArray())));

            string cacheKey = string.Format("UploadValuesAndGetBinary{0}_{1}_{2}_{3}",
                url,
                Method,
                string.Join("-", FormValues.AllKeys),
                string.Join(":", FormValues.AllKeys.ToList().Select(key => FormValues[key]).ToArray())
                );

            var cached = _CacheProvider.Get<byte[]>(
                cacheKey);
            if (cached != null)
            {
                _LogProvider.LogMessage("Url.UploadValuesAndGetBinary  :  Returning cached result");
                return cached;
            }

            _LogProvider.LogMessage("Url.UploadValuesAndGetBinary  :  Cached result unavailable, fetching url content");


            var webClient = new System.Net.WebClient();
            byte[] result = null;
            try
            {
                result = webClient.UploadValues(url, Method, FormValues);
            }
            catch (Exception error)
            {
                if (_LogProvider.HandleAndReturnIfToThrowError(error))
					throw;
                return null;
            }

            _CacheProvider.Set(result, cacheKey);
            return result;
        }

        internal string UploadValuesAndGetString(string url, NameValueCollection FormValues)
        {
            return UploadValuesAndGetString(url, FormValues, "POST");
        }

        internal string UploadValuesAndGetString(string url, NameValueCollection FormValues, string Method)
        {
            _LogProvider.LogMessage("Url.UploadValuesAndGetString - Calling UploadValuesAndGetBinary...");

            var result = UploadValuesAndGetBinary(url, FormValues, Method);

            return result == null ? null : Encoding.UTF8.GetString(result);
        }

        internal string GetStringFromURL(string url)
        {
            string cacheKey = string.Format("GetStringFromURL_{0}", url);
            var cached = _CacheProvider.Get<string>(
                cacheKey);
            if (cached != null)
            {
                _LogProvider.LogMessage("Url.GetStringFromURL  :  Returning cached result");
                return cached;
            }

            _LogProvider.LogMessage("Url.GetStringFromURL  :  Cached result unavailable, fetching url content");

            var webClient = new System.Net.WebClient();
            string result = null;
            try
            {
                result = webClient.DownloadString(url);
            }
            catch (Exception error)
            {
                if (_LogProvider.HandleAndReturnIfToThrowError(error))
					throw;
                return null;
            }

            _CacheProvider.Set(result, cacheKey);
            return result;
        }

    }
}

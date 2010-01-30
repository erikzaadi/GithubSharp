
using System;

namespace GithubSharp.Core.Helpers
{
	public class URLUtils
	{
		prot XDocument _GetXMLFromURL(string URL)
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
	}
}

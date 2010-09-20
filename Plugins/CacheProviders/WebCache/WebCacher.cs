using System;
using System.Web;
using GithubSharp.Core.Services;

namespace GithubSharp.Plugins.CacheProviders.WebCache
{
    public class WebCacher : ICacheProvider
    {
        public WebCacher()
        {
            if (HttpContext.Current == null)
                throw new NullReferenceException("System.Web.HttpContext.Current is null");
            if (HttpContext.Current.Cache == null)
                throw new NullReferenceException("System.Web.HttpContext.Current.Application is null");
            _Cache = HttpContext.Current.Cache;
        }

        private readonly System.Web.Caching.Cache _Cache;
        private const string CachePrefix = "GithubSharp.Plugins.CacheProviders.WebCacher";

        #region ICacheProvider implementation
        public T Get<T>(string Name)
            where T : class
        {
            return Get<T>(Name, DefaultDuractionInMinutes);
        }


        public T Get<T>(string Name, int CacheDurationInMinutes)
            where T : class
        {
            var cached = _Cache[CachePrefix + Name] as CachedObject<T>;
            if (cached == null)
                return null;

            if (cached.When.AddMinutes(CacheDurationInMinutes) < DateTime.Now)
                return null;

            return cached.Cached;
        }


        public bool IsCached<T>(string Name)
            where T : class
        {
            return Get<T>(Name) != null;
        }


        public void Set<T>(T ObjectToCache, string Name)
            where T : class
        {
            var cacheObj = new CachedObject<T>();
            cacheObj.Cached = ObjectToCache;
            cacheObj.When = DateTime.Now;

            _Cache[CachePrefix + Name] = cacheObj;
        }


        public void Delete(string Name)
        {
            _Cache.Remove(CachePrefix + Name);
        }


        public void DeleteWhereStartingWith(string Name)
        {
            var enumerator = _Cache.GetEnumerator();

            while (enumerator.MoveNext())
            {
                if (enumerator.Key.ToString().StartsWith(CachePrefix + Name))
                    _Cache.Remove(enumerator.Key.ToString());
            }
        }


        public void DeleteAll<T>()
            where T : class
        {
            var enumerator = _Cache.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                if (enumerator.Key.ToString().StartsWith(CachePrefix))
                {
                    var obj = _Cache[enumerator.Key.ToString()] as CachedObject<T>;
                    if (obj != null)
                    {
                        _Cache.Remove(enumerator.Key.ToString());
                    }
                }
            }
        }


        public int DefaultDuractionInMinutes
        {
            get { return 20; }
        }

        #endregion

    }
}

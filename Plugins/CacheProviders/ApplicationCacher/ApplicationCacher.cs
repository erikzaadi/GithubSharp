using System;
using GithubSharp.Core.Services;
using System.Linq;
using System.Web;

namespace GithubSharp.Plugins.CacheProviders.ApplicationCacher
{
	public class ApplicationCacher : ICacheProvider
	{
		public ApplicationCacher()
		{
			if (HttpContext.Current == null)
				throw new NullReferenceException("System.Web.HttpContext.Current is null");
			if (HttpContext.Current.Application == null)
				throw new NullReferenceException("System.Web.HttpContext.Current.Application is null");
		    _application = HttpContext.Current.Application;
		}
		
		private readonly HttpApplicationState _application;
		private const string CachePrefix = "GithubSharp.Plugins.CacheProviders.ApplicationCacher";
		
		#region ICacheProvider implementation
		public T Get<T> (string Name) 
			where T : class
		{
			return Get<T>(Name, DefaultDuractionInMinutes);
		}
		
		
		public T Get<T> (string Name, int CacheDurationInMinutes)
			where T : class
		{
            var cached = _application[CachePrefix + Name] as CachedObject<T>;
            if (cached == null)
				return null;

			return cached.When.AddMinutes(CacheDurationInMinutes) > DateTime.Now ? null : cached.Cached;
		}
		
		
		public bool IsCached<T> (string Name)
			where T : class
		{
			return Get<T>(Name) != null;
		}
		
		
		public void Set<T> (T ObjectToCache, string Name)
			where T : class
		{
			var cacheObj = new CachedObject<T>();
			cacheObj.Cached = ObjectToCache;
			cacheObj.When = DateTime.Now;
			
			_application[CachePrefix + Name] = cacheObj;
		}
		
		
		public void Delete (string Name)
		{
			_application.Remove(CachePrefix + Name);
		}
		
		
		public void DeleteWhereStartingWith (string Name)
		{
			_application.AllKeys.Where(P => P.StartsWith(CachePrefix + Name)).ToList().ForEach(Key => _application.Remove(Key));
		}
		
		
		public void DeleteAll<T> ()
			where T : class
		{
			_application.AllKeys.Where(P => P.StartsWith(CachePrefix)).ToList().ForEach(Key =>
		    {
                var obj = _application[Key] as CachedObject<T>;
				if (obj != null)
				{
					_application.Remove(Key);
				}
			});
		}
		
		
		public int DefaultDuractionInMinutes {
			get { return 20;}
		}
		
		#endregion
		
	}
}


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
			_Application = HttpContext.Current.Application;
		}
		
		private readonly HttpApplicationState _Application;
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
            var cached = _Application[CachePrefix + Name] as CachedObject<T>;
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
			
			_Application[CachePrefix + Name] = cacheObj;
		}
		
		
		public void Delete (string Name)
		{
			_Application.Remove(CachePrefix + Name);
		}
		
		
		public void DeleteWhereStartingWith (string Name)
		{
			_Application.AllKeys.Where(P => P.StartsWith(CachePrefix + Name)).ToList().ForEach(Key => _Application.Remove(Key));
		}
		
		
		public void DeleteAll<T> ()
			where T : class
		{
			_Application.AllKeys.Where(P => P.StartsWith(CachePrefix)).ToList().ForEach(Key =>
		    {
                var obj = _Application[Key] as CachedObject<T>;
				if (obj != null)
				{
					_Application.Remove(Key);
				}
			});
		}
		
		
		public int DefaultDuractionInMinutes {
			get { return 20;}
		}
		
		#endregion
		
	}
}

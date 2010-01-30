
using System;
using GithubSharp.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
		
		private HttpApplicationState _Application;
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
			object obj = _Application[CachePrefix + Name];
			if (obj == null || !(obj is CachedObject<T>))
				return null;
			var cached = obj as CachedObject<T>;
			if (cached.When.AddMinutes(CacheDurationInMinutes) > DateTime.Now)
				return null;
			else 
				return cached.Cached;
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
			_Application.AllKeys.Where(p=> p.StartsWith(CachePrefix + Name)).ToList().ForEach(key =>
		    {
				_Application.Remove(key);
			});
		}
		
		
		public void DeleteAll<T> ()
			where T : class
		{
			_Application.AllKeys.Where(p=> p.StartsWith(CachePrefix)).ToList().ForEach(key =>
		    {
				var obj = _Application[key];
				if (obj != null && obj is CachedObject<T>)
				{
					_Application.Remove(key);
				}
			});
		}
		
		
		public int DefaultDuractionInMinutes {
			get { return 20;}
		}
		
		#endregion
		
	}
}

using System;

namespace GithubSharp.Plugins.CacheProviders.NullCacher
{
	public class NullCacher : GithubSharp.Core.Services.ICacheProvider
	{
		public NullCacher ()
		{
		}

		public T Get<T> (string Name) where T : class
		{
			return null;
		}

		public T Get<T> (string Name, int CacheDurationInMinutes) where T : class
		{
			return null;
		}

		public bool IsCached<T> (string Name) where T : class
		{
			return false;
		}

		public void Set<T> (T ObjectToCache, string Name) where T : class
		{
		}

		public void Delete (string Name)
		{
		}

		public void DeleteWhereStartingWith (string Name)
		{
		}

		public void DeleteAll<T> () where T : class
		{
		}

		public int DefaultDuractionInMinutes {
			get {
				return 1;
			}
		}
	}
}


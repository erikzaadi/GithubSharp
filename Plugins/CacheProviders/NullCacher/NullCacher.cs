namespace GithubSharp.Plugins.CacheProviders.NullCacher
{
	public class NullCacher : Core.Services.ICacheProvider
	{
		public T Get<T> (string name) where T : class
		{
			return null;
		}

		public T Get<T> (string name, int cacheDurationInMinutes) where T : class
		{
			return null;
		}

		public bool IsCached<T> (string name) where T : class
		{
			return false;
		}

		public void Set<T> (T objectToCache, string name) where T : class
		{
		}

		public void Delete (string name)
		{
		}

		public void DeleteWhereStartingWith (string name)
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


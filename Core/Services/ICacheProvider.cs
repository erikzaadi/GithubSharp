
using System;

namespace GithubSharp.Core.Services
{

	public interface ICacheProvider
	{
		T Get<T>(string Name) where T : class;
		T Get<T>(string Name, int CacheDurationInMinutes) where T : class;
		bool IsCached<T>(string Name) where T : class;
		void Set<T>(T ObjectToCache, string Name) where T : class;
		void Delete(string Name);
		void DeleteWhereStartingWith(string Name);
		void DeleteAll<T>() where T : class;
		int DefaultDuractionInMinutes {get;}
	}
	
	public class CachedObject<T> where T : class
	{
        public T Cached { get; set; }
        public DateTime When { get; set; }
	}
}

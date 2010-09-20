using System;
using GithubSharp.Plugins.LogProviders.SimpleLogProvider;
using GithubSharp.Core.API;

namespace ConsoleSample
{
    class Program
    {
        static void Main()
        {
            var user = new User(new BasicCacher.BasicCacher(), new SimpleLogProvider());
            var u = user.Get("rumpl");
            Console.WriteLine(u.Blog);
        }
    }
}

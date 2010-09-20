using System;
using GithubSharp.Core.API;
using GithubSharp.Plugins.LogProviders.SimpleLogProvider;

namespace ConsoleSample
{
    class Program
    {
        static void Main()
        {
            var user = new User(new BasicCacher.BasicCacher(), new SimpleLogProvider());
            var u = user.Get("rumpl");
            Console.WriteLine(u.Blog);
            u = user.Get("rumpl");
            Console.WriteLine(u.Blog);
        }
    }
}

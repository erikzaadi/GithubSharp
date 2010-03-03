using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Modules;

namespace GithubSharp.MvcSample.MvcApplication
{
    internal class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<Core.Services.ICacheProvider>().To<GithubSharp.Plugins.CacheProviders.WebCache.WebCacher>();
            Bind<Core.Services.ILogProvider>().To<GithubSharp.Plugins.LogProviders.SimpleLogProvider.SimpleLogProvider>();
        }
    }
}

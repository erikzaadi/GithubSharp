using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GithubSharp.Core.Services;

namespace GithubSharp.Core.API
{
    public class Commits : Base.BaseAPI, Base.IBaseAPI
    {
        public Commits(ICacheProvider cacheProvider, ILogProvider logProvider) : base(cacheProvider, logProvider) { }

		
        //Listing Commits on a Branch
        //commits/list/:user_id/:repository/:branch

        //Listing Commits for a File
        //commits/list/:user_id/:repository/:branch/*path

        //Showing a Specific Commit
        //commits/show/:user_id/:repository/:sha
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GithubSharp.Core.Services;

namespace GithubSharp.Core.API
{
    public class Object : Base.BaseAPI, Base.IBaseAPI
    {
		//Trees
        //tree/show/:user/:repo/:tree_sha

        //Blobs
        //blob/show/:user/:repo/:tree_sha/:path

        //Raw (doesn't return json)
        //blob/show/:user/:repo/:sha
    }
}

using GithubSharp.Core.Services;

namespace GithubSharp.Core.API
{
    public class Gist : Base.BaseAPI
    {
        public Gist(ICacheProvider CacheProvider, ILogProvider LogProvider) : base(CacheProvider, LogProvider) { }
        //http://github.com/mattikus/pygist/blob/master/pygist.py
        //http://github.com/miyagawa/gistp/blob/master/gistp
        //http://github.com/defunkt/gist/blob/master/gist.rb
        //http://gist.github.com/4277

        //http://gist.github.com/api/v1/xml/search/gist
        //http://gist.github.com/api/v1/xml/new

        //Delete
        //http://gist.github.com/delete/:id
        // _method = delete ,authenticity_token, 

        //Edit
        //http://gist.github.com/gists/:id/edit
        // _method = put,  authenticity_token, file_ext[fileN.ext] , file_contents[fileN.ext], file_name[fileN.ext]

        //Get all gists for user
        //http://gist.github.com/api/v1/xml/gists/erikzaadi

        //Download
        // /gists/:id/download

        //Raw
        //http://gist.github.com/{repo}.txt

        //format - Parse to get the syntax highlighted html
        //http://gist.github.com/291158.json

        //http://gist.github.com/291158.js
    }
}

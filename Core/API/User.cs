using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GithubSharp.Core.API
{
    public class User
    {
        //Search for users
        //http://github.com/api/v2/xml/user/search/chacon

        //User info
        //http://github.com/api/v2/yaml/user/show/defunkt
        /* if authenticated, returns:
          total_private_repo_count: 1
  collaborators: 3
  disk_usage: 50384
  owned_private_repo_count: 1
  private_gist_count: 0
  plan: 
    name: mega
    collaborators: 60
    space: 20971520
    private_repos: 125
         */

        //Authenticate
        ///Update user info (POST)
        //https://github.com/api/v2/json/user/show/schacon
        //Uses values (name, email, blog, company, location)

        //Followers
        //http://github.com/api/v2/yaml/user/show/defunkt/followers

        //Authenticate
        //Follow (POST)
        //http://github.com/api/v2/yaml/user/defunkt/follow 

        //Authenticate
        //UnFollow (POST)
        //http://github.com/api/v2/yaml/user/defunkt/unfollow 

        //Watched repositories
        //http://github.com/api/v2/yaml/repos/watched/schacon 

        //Authenticate
        //Public keys
        //http://github.com/api/v2/xml/user/keys?login=erikzaadi&token=111

        //Authenticate
        //Public keys - Add (POST)
        //http://github.com/api/v2/xml/user/key/add
        //Uses values name, key

        //Authenticate
        //Public keys - Remove (POST)
        //http://github.com/api/v2/xml/user/key/remove
        //Uses values id

        //Authenticate
        //Emails
        //http://github.com/api/v2/xml/user/emails?login=erikzaadi&token=111

        //Authenticate
        //Emails - Add (POST)
        //http://github.com/api/v2/xml/user/email/add
        //Uses values ?? email

        //Authenticate
        //Emails - Remove (POST)
        //http://github.com/api/v2/xml/user/key/remove
        //Uses values ?? email
    }
}

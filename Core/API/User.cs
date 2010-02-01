using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GithubSharp.Core.API
{
    public class User : Base.BaseAPI
    {
        public User(Services.ICacheProvider cacheProvider)
            : base(cacheProvider)
        {
        }

        /// <summary>
        /// Search for users
        /// </summary>
        /// <param name="Search">search string</param>
        /// <returns>Stripped down details of the users</returns>
        public IEnumerable<Models.UserInCollection> Search(string Search)
        {
            var url = string.Format("{1}{2}",
                "user/search/",
                Search);
            var result = ConsumeJsonUrl<Models.UsersCollection<Models.UserInCollection>>(url);
            return result == null ? null : result.users;
        }

        /// <summary>
        /// Gets extended details for a user
        /// </summary>
        /// <param name="Username"></param>
        /// <returns></returns>
        public Models.User Get(string Username)
        {
            var url = string.Format("{1}{2}",
               "user/show/",
               Username);
            var result = ConsumeJsonUrl<Models.UserContainer<Models.User>>(url);

            return result == null ? null : result.user;
        }

        /// <summary>
        /// Gets extended details (including private information) for a user
        /// </summary>
        /// <param name="AuthenticatedUser"></param>
        /// <returns></returns>
        public Models.UserAuthenticated Get()
        {
            Authenticate();
            var url = string.Format("{1}{2}{3}",
                "user/show/",
                Username);
            var result = ConsumeJsonUrl<Models.UserContainer<Models.UserAuthenticated>>(url);

            return result == null ? null : result.user;
        }

        /// <summary>
        /// Returns a list of followers (string array of user names)
        /// </summary>
        /// <param name="Username"></param>
        /// <returns></returns>
        public string[] Followers(string Username)
        {
            var url = string.Format("{1}{2}/followers",
              "user/show/",
              Username);
            var result = ConsumeJsonUrl<Models.UsersCollection<string>>(url);

            return result == null ? null : result.users.ToArray();
        }


        /// <summary>
        /// Returns a list of watched repositories
        /// </summary>
        /// <param name="Username"></param>
        /// <returns></returns>
        public IEnumerable<Models.Repository> WatchedRepositories(string Username)
        {
            var url = string.Format("{1}{2}",
              "repos/watched/",
              Username);
            var result = ConsumeJsonUrl<Models.RepositoryCollection<Models.Repository>>(url);

            return result == null ? null : result.repositories;
        }

        //Authenticate
        ///Update user info (POST)
        //https://github.com/api/v2/json/user/show/schacon
        //Uses values (name, email, blog, company, location)

        //Authenticate
        //Follow (POST)
        //http://github.com/api/v2/yaml/user/defunkt/follow 

        //Authenticate
        //UnFollow (POST)
        //http://github.com/api/v2/yaml/user/defunkt/unfollow 
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

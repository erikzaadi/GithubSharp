using System;
using System.Collections.Generic;
using System.Linq;
using GithubSharp.Core.Services;
using System.Collections.Specialized;

namespace GithubSharp.Core.API
{
    public class User : Base.BaseApi
    {
        public User(ICacheProvider cacheProvider, ILogProvider logProvider) : base(cacheProvider, logProvider) { }
        /// <summary>
        /// Search for users
        /// </summary>
        /// <param name="search">search string</param>
        /// <returns>Stripped down details of the users</returns>
        public IEnumerable<Models.UserInCollection> Search(string search)
        {
            LogProvider.LogMessage(string.Format("User.Search - '{0}'", search));
            var url = string.Format("{0}{1}",
                "user/search/",
                search);
            var result = ConsumeJsonUrl<Models.Internal.UsersCollection<Models.UserInCollection>>(url);
            return result == null ? null : result.Users;
        }

        /// <summary>
        /// Gets extended details for a user
        /// </summary>
        /// <param name="Username"></param>
        /// <returns></returns>
        public Models.User Get(string Username)
        {
            LogProvider.LogMessage(string.Format("User.Get - '{0}'", Username));
            var url = string.Format("{0}{1}",
               "users/",
               Username);
            var result = ConsumeJsonUrl<Models.User>(url);

            return result;
        }

        /// <summary>
        /// Gets extended details (including private information) for a user
        ///<para>Needs to bee authenticated (with a valid Github User)</para>
        /// </summary>
        ///<returns></returns>
        public Models.UserAuthenticated Get()
        {
            LogProvider.LogMessage(string.Format("User.Get (Authenticated) - '{0}'", CurrentUsername));
            Authenticate();
            var url = string.Format("{0}{1}",
                "user/show/",
                CurrentUsername);
            var result = ConsumeJsonUrl<Models.Internal.UserContainer<Models.UserAuthenticated>>(url);

            return result == null ? null : result.User;
        }

        /// <summary>
        /// Returns a list of followers (string array of user names)
        /// </summary>
        /// <param name="Username"></param>
        /// <returns></returns>
        public string[] Followers(string Username)
        {
            LogProvider.LogMessage(string.Format("User.Followers - '{0}'", Username));
            var url = string.Format("{0}{1}/followers",
              "user/show/",
              Username);
            var result = ConsumeJsonUrl<Models.Internal.UsersCollection<string>>(url);

            return result == null ? null : result.Users.ToArray();
        }


        /// <summary>
        /// Returns a list of watched repositories
        /// </summary>
        /// <param name="Username"></param>
        /// <returns></returns>
        public IEnumerable<Models.Repository> WatchedRepositories(string Username)
        {
            LogProvider.LogMessage(string.Format("User.WatchedRepositories - '{0}'", Username));
            var url = string.Format("{0}{1}",
              "repos/watched/",
              Username);
            var result = ConsumeJsonUrl<Models.Internal.RepositoryCollection<Models.Repository>>(url);

            return result == null ? null : result.Repositories;
        }

        /// <summary>
        /// Updates a users details
        ///<para>Needs to bee authenticated (with a valid Github User)</para>
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Email"></param>
        /// <param name="Blog"></param>
        /// <param name="Company"></param>
        /// <param name="Location"></param>
        /// <returns></returns>
        public Models.UserAuthenticated Update(
            string Name,
            string Email,
            string Blog,
            string Company,
            string Location)
        {
            LogProvider.LogMessage(string.Format("User.Update (Authenticated)\nName: '{0}' Email : '{1}' Blog : '{2}' Company : '{3}' Location : '{4}'",
                Name,
                Email,
                Blog,
                Company,
                Location));

            Authenticate();

            var url = string.Format("user/show/{0}", CurrentUsername);

            var formValues = new NameValueCollection();

            if (Name != null)//an empty string is ok
                formValues.Add("name", Name);
            if (Email != null)//an empty string is ok
                formValues.Add("email", Email);
            if (Blog != null)//an empty string is ok
                formValues.Add("blog", Blog);
            if (Company != null)//an empty string is ok
                formValues.Add("company", Company);
            if (Location != null)//an empty string is ok
                formValues.Add("location", Location);

            if (formValues.Count == 0)
            {
                var error = new Exception("User.Update : At least one parameter needs to either be and empty string or with content, all parameters were null");
                if (LogProvider.HandleAndReturnIfToThrowError(error))
                    throw error;

                return null;
            }

            var result = ConsumeJsonUrlAndPostData<Models.Internal.UserContainer<Models.UserAuthenticated>>(url, formValues);

            return result == null ? null : result.User;
        }

        /// <summary>
        /// Follow user
        ///<para>Needs to bee authenticated (with a valid Github User)</para>
        /// </summary>
        /// <param name="Username"></param>
        /// <returns></returns>
        public string[] Follow(string Username)
        {
            LogProvider.LogMessage(string.Format("User.Follow - '{0}'", Username));

            Authenticate();

            var url = string.Format("user/follow/{0}", Username);

            var result = ConsumeJsonUrlAndPostData<Models.Internal.UsersCollection<string>>(url);

            return result == null ? null : result.Users.ToArray();
        }


        /// <summary>
        /// UnFollow user
        ///<para>Needs to bee authenticated (with a valid Github User)</para>
        /// 
        /// <para>Note: Does not work <see cref="http://github.com/develop/develop.github.com/issues#issue/39"/></para>
        /// </summary>
        /// <param name="Username"></param>
        /// <returns></returns>
        public string[] UnFollow(string Username)
        {
            LogProvider.LogMessage(string.Format("User.UnFollow - '{0}'", Username));
            Authenticate();

            var url = string.Format("{0}{1}",
              "user/unfollow/",
              Username);
            var result = ConsumeJsonUrlAndPostData<Models.Internal.UsersCollection<string>>(url);

            return result == null ? null : result.Users.ToArray();
        }

        /// <summary>
        /// List all public keys
        /// 
        ///<para>Needs to bee authenticated (with a valid Github User)</para>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.PublicKey> PublicKeys()
        {
            LogProvider.LogMessage("User.PublicKeys");

            Authenticate();

            var url = "user/keys";

            var result = ConsumeJsonUrl<Models.Internal.PublicKeyCollection<Models.PublicKey>>(url);

            return result == null ? null : result.PublicKeys.ToArray();
        }

        /// <summary>
        /// Add a public key
        ///<para>Needs to bee authenticated (with a valid Github User)</para>
        /// </summary>
        /// <param name="PublicKey"></param>
        /// <returns></returns>
        public IEnumerable<Models.PublicKey> AddPublicKey(Models.PublicKey PublicKey)
        {
            LogProvider.LogMessage(string.Format("User.AddPublicKey - Title : '{0}' Key : {1}", PublicKey.Title, PublicKey.Id));

            Authenticate();

            var url = "user/key/add";

            var formValues = new NameValueCollection();
            formValues.Add("title", PublicKey.Title);
            formValues.Add("key", PublicKey.Key);

            var result = ConsumeJsonUrlAndPostData<Models.Internal.PublicKeyCollection<Models.PublicKey>>(url, formValues);

            return result == null ? null : result.PublicKeys.ToArray();
        }

        /// <summary>
        /// Removes a public key
        ///<para>Needs to bee authenticated (with a valid Github User)</para>
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IEnumerable<Models.PublicKey> RemovePublicKey(int Id)
        {
            LogProvider.LogMessage(string.Format("User.RemovePublicKey - id : '{0}' ", Id));

            Authenticate();

            var url = "user/key/remove";

            var formValues = new NameValueCollection();
            formValues.Add("id", Id.ToString());

            var result = ConsumeJsonUrlAndPostData<Models.Internal.PublicKeyCollection<Models.PublicKey>>(url, formValues);

            return result == null ? null : result.PublicKeys.ToArray();
        }


        /// <summary>
        /// Gets all the emails active for the user
        ///<para>Needs to bee authenticated (with a valid Github User)</para>
        /// </summary>
        /// <returns></returns>
        public string[] Emails()
        {
            LogProvider.LogMessage("User.Emails");

            Authenticate();

            var url = "user/emails";

            var result = ConsumeJsonUrl<Models.Internal.EmailCollection>(url);

            return result == null ? null : result.Emails.ToArray();
        }

        /// <summary>
        /// Adds an email to the user
        ///<para>Needs to bee authenticated (with a valid Github User)</para>
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public string[] AddEmail(string Email)
        {
            LogProvider.LogMessage("User.AddEmail {0}", Email);

            Authenticate();

            var url = "user/email/add";

            var formValues = new NameValueCollection();
            formValues.Add("email", Email);

            var result = ConsumeJsonUrlAndPostData<Models.Internal.EmailCollection>(url, formValues);

            return result == null ? null : result.Emails.ToArray();
        }

        /// <summary>
        /// Removes an email to the user
        /// <para>Needs to bee authenticated (with a valid Github User)</para>
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public string[] RemoveEmail(string Email)
        {
            LogProvider.LogMessage("User.RemoveEmail {0}", Email);

            Authenticate();

            var url = "user/email/remove";

            var formValues = new NameValueCollection();
            formValues.Add("email", Email);

            var result = ConsumeJsonUrlAndPostData<Models.Internal.EmailCollection>(url, formValues);

            return result == null ? null : result.Emails.ToArray();
        }
    }
}

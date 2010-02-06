using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GithubSharp.Core.Services;
using System.Collections.Specialized;

namespace GithubSharp.Core.API
{
    public class Repository : Base.BaseAPI, Base.IBaseAPI
    {

        /// <summary>
        /// Search 
        /// </summary>
        /// <param name="Search"></param>
        /// <returns></returns>
        public IEnumerable<Models.RepositoryFromSearch> Search(string Search)
        {
            LogProvider.LogMessage(string.Format("Repository.Search - '{0}'", Search));

            var url = string.Format("{0}{1}",
                "repos/search/",
                Search);

            var result = ConsumeJsonUrl<Models.RepositoryCollection<Models.RepositoryFromSearch>>(url);

            return result == null ? null : result.repositories;
        }

        public Models.Repository Get(string Username, string RepositoryName)
        {
            LogProvider.LogMessage(string.Format("Repository.Get - Username : '{0}' , RepositoryName : '{1}'", Username, RepositoryName));

            var url = string.Format("{0}{1}/{2}",
                "repos/show/",
                Username,
                RepositoryName);

            var result = ConsumeJsonUrl<Models.RepositoryContainer<Models.Repository>>(url);

            return result == null ? null : result.repository;
        }

        public IEnumerable<Models.Repository> List(string Username)
        {
            LogProvider.LogMessage(string.Format("Repository.List - Username : '{0}'", Username));

            var url = string.Format("{0}{1}",
                "repos/show/",
                Username);

            var result = ConsumeJsonUrl<Models.RepositoryCollection<Models.Repository>>(url);

            return result == null ? null : result.repositories;
        }

        public Models.Repository Watch(string Username, string RepositoryName)
        {
            LogProvider.LogMessage(string.Format("Repository.Watch - Username : '{0}' , RepositoryName : '{1}'", Username, RepositoryName));

            Authenticate();

            var url = string.Format("{0}{1}/{2}",
                "repos/watch/",
                Username,
                RepositoryName);

            var result = ConsumeJsonUrl<Models.RepositoryContainer<Models.Repository>>(url);

            return result == null ? null : result.repository;
        }

        public Models.Repository Unwatch(string Username, string RepositoryName)
        {
            LogProvider.LogMessage(string.Format("Repository.Watch - Username : '{0}' , RepositoryName : '{1}'", Username, RepositoryName));

            Authenticate();

            var url = string.Format("{0}{1}/{2}",
                "repos/unwatch/",
                Username,
                RepositoryName);

            var result = ConsumeJsonUrl<Models.RepositoryContainer<Models.Repository>>(url);

            return result == null ? null : result.repository;
        }

        public Models.Repository Fork(string Username, string RepositoryName)
        {
            LogProvider.LogMessage(string.Format("Repository.Fork - Username : '{0}' , RepositoryName : '{1}'", Username, RepositoryName));

            Authenticate();

            var url = string.Format("{0}{1}/{2}",
                "repos/fork/",
                Username,
                RepositoryName);

            var result = ConsumeJsonUrl<Models.RepositoryContainer<Models.Repository>>(url);

            return result == null ? null : result.repository;
        }

        public Models.Repository Create(string RepositoryName, string Description, string HomePage, bool Public)
        {
            LogProvider.LogMessage(string.Format("Repository.Create - RepositoryName : '{0}' , Description : '{1}' , HomePage : '{2}', Public : '{3}'",
                RepositoryName,
                Description,
                HomePage,
                Public));

            Authenticate();

            var url = "repos/create";

            var formValues = new NameValueCollection();
            if (string.IsNullOrEmpty(RepositoryName))
            {
                var error = new NullReferenceException("RepositoryName was null or empty");
                if (LogProvider.HandleAndReturnIfToThrowError(error))
                    throw error;
                return null;
            }
            formValues.Add("name", RepositoryName);

            if (!string.IsNullOrEmpty(Description))
                formValues.Add("description", Description);
            if (!string.IsNullOrEmpty(HomePage))
                formValues.Add("homepage", HomePage);

            formValues.Add("public", (Public ? 1 : 0).ToString());

            var result = ConsumeJsonUrlAndPostData<Models.RepositoryContainer<Models.Repository>>(url, formValues);

            return result == null ? null : result.repository;
        }

        public bool Delete(string RepositoryName)
        {
            LogProvider.LogMessage("Repository.Delete - RepositoryName : '{0}'", RepositoryName);

            Authenticate();

            var url = "repos/delete/" + RepositoryName;

            var result = ConsumeJsonUrlAndPostData<GithubSharp.Core.Models.RepositoryDelete>(url);

            if (result == null)
                return false;

            var formValues = new NameValueCollection();
            formValues.Add("delete_token", result.delete_token);

            var status = ConsumeJsonUrlAndPostData<GithubSharp.Core.Models.RepositoryDeleted>(url, formValues);

            return status != null && status.status == "deleted";
        }

        //{"delete_token":"jhkkqrjzyz"}
        //{"status":"deleted"}

        //Authenticate
        //Delete (POST)
        //http://github.com/api/v2/yaml/repos/delete/:repo
        //Returns a token called 'delete_token', which you need to repost to (the token is a url)

        //Authenticate
        //Repository Visibility
        //http://github.com/api/v2/yaml/repos/set/:state/:repo
        //where state is public/private

        //Authenticate
        //Deploy Keys
        //http://github.com/api/v2/yaml/repos/keys/:repo
        //returns title, id, key

        //Authenticate
        //Add Deploy Keys (POST)
        //http://github.com/api/v2/yaml/repos/keys/:repo/add
        //values title, key

        //Authenticate
        //Remove Deploy Keys (POST)
        //http://github.com/api/v2/yaml/repos/keys/:repo/remove
        //values id

        //Get Collaborators (Authenticate to see private)
        //http://github.com/api/v2/xml/repos/show/erikzaadi/jQueryPlugins/collaborators

        //Authenticate
        //Add Collaborator (POST)
        //http://github.com/api/v2/xml/repos/collaborators/:repo/add/:user

        //Authenticate
        //Remove Collaborator (POST)
        //http://github.com/api/v2/xml/repos/collaborators/:repo/remove/:user

        //Show network (forkers)
        //http://github.com/api/v2/xml/repos/show/:user/:repo/network
        /*
         <network type="array"> 
          <network> 
            <description>Collection of jQuery plugins</description> 
            <url>http://github.com/erikzaadi/jQueryPlugins</url> 
            <homepage></homepage> 
            <fork type="boolean">false</fork> 
            <forks type="integer">1</forks> 
            <open-issues type="integer">3</open-issues> 
            <private type="boolean">false</private> 
            <name>jQueryPlugins</name> 
            <watchers type="integer">7</watchers> 
            <owner>erikzaadi</owner> 
          </network> 
          <network> 
            <description>Collection of jQuery plugins</description> 
            <url>http://github.com/vandalo/jQueryPlugins</url> 
            <homepage></homepage> 
            <fork type="boolean">true</fork> 
            <forks type="integer">0</forks> 
            <open-issues type="integer">0</open-issues> 
            <private type="boolean">false</private> 
            <name>jQueryPlugins</name> 
            <watchers type="integer">1</watchers> 
            <owner>vandalo</owner> 
          </network> 
        </network> 
         */

        //Language Breakdown
        //http://github.com/api/v2/xml/repos/show/:user/:repo/languages

        //Repository Refs (Tags)
        //http://github.com/api/v2/xml/repos/show/:user/:repo/tags
        //Might be broken as xml, use json?
        /*
         <tags> 
  <v1.2.0>cfad76700b3d38eb3be97e2d5ef75cc0a398f818</v1.2.0> 
  <1.0.3>be47ad8aea4f854fc2d6773456fb28f3e9f519e7</1.0.3> 
  <v1.2.1>f85cef0b1916f09ceb38f778ada98b23c8610da7</v1.2.1> 
  <v1.2.2>85fa6ec3a68b6ff8acfa69c59fbdede1385f63bb</v1.2.2> 
  <1.0.5>6c4af60f5fc5193b956a4698b604ad96ef3c51c6</1.0.5> 
  <v1.2.3>2962356828cc0ce07674b1c1fa39fde893732344</v1.2.3> 
  <1.0.5.1>ae106e2a3569e5ea874852c613ed060d8e232109</1.0.5.1> 
  <v1.2.4>1987b5010ed1abff915bd87146753323754bfb13</v1.2.4> 
  <v1.2.5>94f389bf5d9af4511597d035e69d1be9510b50c7</v1.2.5> 
  <v1.0.7>1adc5b8136c2cd6c694629947e1dbc49c8bffe6a</v1.0.7> 
</tags>
         */

        //To get a list of remote branches
        //http://github.com/api/v2/yaml/repos/show/schacon/ruby-git/branches
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using GithubSharp.Core.Services;
using System.Collections.Specialized;
using GithubSharp.Core.Base;

namespace GithubSharp.Core.API
{
    public class Repository : Base.BaseApi
    {
        public Repository(ICacheProvider CacheProvider, ILogProvider LogProvider) : base(CacheProvider, LogProvider) { }

        public IEnumerable<Models.RepositoryFromSearch> Search(string Search)
        {
            LogProvider.LogMessage(string.Format("Repository.Search - '{0}'", Search));

            var url = string.Format("{0}{1}",
                "repos/search/",
                Search);

            var result = ConsumeJsonUrl<Models.Internal.RepositoryCollection<Models.RepositoryFromSearch>>(url);

            return result == null ? null : result.Repositories;
        }

        public Models.Repository Get(string Username, string RepositoryName)
        {
            LogProvider.LogMessage(string.Format("Repository.Get - Username : '{0}' , RepositoryName : '{1}'", Username, RepositoryName));

            var url = string.Format("{0}{1}/{2}",
                "repos/show/",
                Username,
                RepositoryName);

            var result = ConsumeJsonUrl<Models.Internal.RepositoryContainer<Models.Repository>>(url);

            return result == null ? null : result.Repository;
        }

        public IEnumerable<Models.Repository> List(string Username)
        {
            LogProvider.LogMessage(string.Format("Repository.List - Username : '{0}'", Username));

            var url = string.Format("{0}{1}",
                "repos/show/",
                Username);

            var result = ConsumeJsonUrl<Models.Internal.RepositoryCollection<Models.Repository>>(url);

            return result == null ? null : result.Repositories;
        }

        public Models.Repository Watch(string Username, string RepositoryName)
        {
            LogProvider.LogMessage(string.Format("Repository.Watch - Username : '{0}' , RepositoryName : '{1}'", Username, RepositoryName));

            Authenticate();

            var url = string.Format("repos/watch/{0}/{1}",
                Username,
                RepositoryName);

            var result = ConsumeJsonUrl<Models.Internal.RepositoryContainer<Models.Repository>>(url);

            return result == null ? null : result.Repository;
        }

        public Models.Repository Unwatch(string Username, string RepositoryName)
        {
            LogProvider.LogMessage(string.Format("Repository.Unwatch - Username : '{0}' , RepositoryName : '{1}'", Username, RepositoryName));

            Authenticate();

            var url = string.Format("repos/unwatch/{0}/{1}",
                Username,
                RepositoryName);

            var result = ConsumeJsonUrl<Models.Internal.RepositoryContainer<Models.Repository>>(url);

            return result == null ? null : result.Repository;
        }

        public Models.Repository Fork(string Username, string RepositoryName)
        {
            LogProvider.LogMessage(string.Format("Repository.Fork - Username : '{0}' , RepositoryName : '{1}'", Username, RepositoryName));

            Authenticate();

            var url = string.Format("repos/fork/{0}/{1}",
                Username,
                RepositoryName);

            var result = ConsumeJsonUrl<Models.Internal.RepositoryContainer<Models.Repository>>(url);

            return result == null ? null : result.Repository;
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

            var result = ConsumeJsonUrlAndPostData<Models.Internal.RepositoryContainer<Models.Repository>>(url, formValues);

            return result == null ? null : result.Repository;
        }

        public bool Delete(string RepositoryName)
        {
            LogProvider.LogMessage("Repository.Delete - RepositoryName : '{0}'", RepositoryName);

            Authenticate();

            var url = "repos/delete/" + RepositoryName;

            var result = ConsumeJsonUrlAndPostData<GithubSharp.Core.Models.Internal.RepositoryDelete>(url);

            if (result == null)
                return false;

            var formValues = new NameValueCollection();
            formValues.Add("delete_token", result.DeleteToken);

            var status = ConsumeJsonUrlAndPostData<GithubSharp.Core.Models.Internal.RepositoryDeleted>(url, formValues);

            return status != null && status.Status == "deleted";
        }

        public Models.Repository SetVisibility(string RepositoryName, bool Visibility)
        {
            LogProvider.LogMessage("Repository.SetVisibility - RepositoryName : '{0}'", RepositoryName);

            Authenticate();

            var url = string.Format("repos/set/{0}/{1}",
                Visibility ? "public" : "private",
                RepositoryName);

            var result = ConsumeJsonUrl<Models.Internal.RepositoryContainer<Models.Repository>>(url);

            return result == null ? null : result.Repository;
        }

        public IEnumerable<Models.PublicKey> PublicKeys(string RepositoryName)
        {
            LogProvider.LogMessage("Repository.PublicKeys - RepositoryName : '{0}'", RepositoryName);

            Authenticate();

            var url = string.Format("repos/keys/{0}", RepositoryName);

            var result = ConsumeJsonUrl<Models.Internal.PublicKeyCollection<Models.PublicKey>>(url);

            return result == null ? null : result.PublicKeys.ToArray();
        }

        public IEnumerable<Models.PublicKey> AddDeployKeys(string RepositoryName, string Title, string Key)
        {
            LogProvider.LogMessage("Repository.AddDeployKeys - RepositoryName : '{0}'", RepositoryName);

            Authenticate();

            var url = string.Format("repos/keys/{0}/add", RepositoryName);

            var formValues = new NameValueCollection();
            formValues.Add("title", Title);
            formValues.Add("key", Key);

            var result = ConsumeJsonUrlAndPostData<Models.Internal.PublicKeyCollection<Models.PublicKey>>(url, formValues);

            return result == null ? null : result.PublicKeys.ToArray();
        }

        public IEnumerable<Models.PublicKey> RemovePublicKey(string RepositoryName, int Id)
        {
            LogProvider.LogMessage(string.Format("Repository.RemovePublicKey - RepositoryName : '{0}' , id : '{1}' ", RepositoryName, Id));

            Authenticate();

            var url = string.Format("repos/keys/{0}/remove", RepositoryName);

            var formValues = new NameValueCollection();
            formValues.Add("id", Id.ToString());

            var result = ConsumeJsonUrlAndPostData<Models.Internal.PublicKeyCollection<Models.PublicKey>>(url, formValues);

            return result == null ? null : result.PublicKeys.ToArray();
        }

        public string[] GetCollaborators(string Username, string RepositoryName)
        {
            LogProvider.LogMessage(string.Format("Repository.GetCollaborators - RepositoryName : '{0}' , Username : '{1}'", RepositoryName, Username));

            var url = string.Format("repos/show/{0}/{1}/collaborators", Username, RepositoryName);

            var result = ConsumeJsonUrl<Models.Internal.CollaboratorsCollection>(url);

            return result == null ? null : result.Collaborators.ToArray();
        }

        public string[] AddCollaborator(string RepositoryName, string Username)
        {
            LogProvider.LogMessage(string.Format("Repository.AddCollaborator - RepositoryName : '{0}' , Username : '{1}' ", RepositoryName, Username));

            Authenticate();

            var url = string.Format("repos/collaborators/{0}/add/{1}", RepositoryName, Username);

            var formValues = new NameValueCollection();

            var result = ConsumeJsonUrlAndPostData<Models.Internal.CollaboratorsCollection>(url, formValues);

            return result == null ? null : result.Collaborators.ToArray();
        }

        public string[] RemoveCollaborator(string RepositoryName, string Username)
        {
            LogProvider.LogMessage(string.Format("Repository.RemoveCollaborator - RepositoryName : '{0}' , Username : '{1}' ", RepositoryName, Username));

            Authenticate();

            var url = string.Format("repos/collaborators/{0}/remove/{1}", RepositoryName, Username);

            var formValues = new NameValueCollection();

            var result = ConsumeJsonUrlAndPostData<Models.Internal.CollaboratorsCollection>(url, formValues);

            return result == null ? null : result.Collaborators.ToArray();
        }

        public IEnumerable<Models.Repository> Network(string RepositoryName, string Username)
        {
            LogProvider.LogMessage(string.Format("Repository.Network - RepositoryName : '{0}' , Username : '{1}' ", RepositoryName, Username));

            var url = string.Format("repos/show/{1}/{0}/network", RepositoryName, Username);

            var result = ConsumeJsonUrl<Models.Internal.RepositoryFromNetworkContainer>(url);

            return result == null ? null : result.Network.ToArray();
        }

        public IEnumerable<Models.Language> LanguageBreakDown(string RepositoryName, string Username)
        {
            LogProvider.LogMessage(string.Format("Repository.LanguageBreakDown - RepositoryName : '{0}' , Username : '{1}' ", RepositoryName, Username));

            var url = string.Format("repos/show/{1}/{0}/languages", RepositoryName, Username);

            var result = ConsumeJsonUrl<Models.Internal.LanguagesCollection>(url);

            return result == null ? null : result.Languages.ToList().Select(p => new Models.Language { Name = p.Key, CalculatedBytes = p.Value }).ToArray();
        }

        public IEnumerable<Models.TagOrBranch> Tags(string RepositoryName, string Username)
        {
            LogProvider.LogMessage(string.Format("Repository.Tags - RepositoryName : '{0}' , Username : '{1}' ", RepositoryName, Username));

            var url = string.Format("repos/show/{1}/{0}/tags", RepositoryName, Username);

            var result = ConsumeJsonUrl<Models.Internal.TagCollection>(url);

            return result == null ? null : result.Tags.Dict.ToList().Select(p => new Models.TagOrBranch { Name = p.Key, Sha = p.Value }).ToArray();
        }

        public Models.TagOrBranch[] Branches(string RepositoryName, string Username)
        {
            LogProvider.LogMessage(string.Format("Repository.Branches - RepositoryName : '{0}' , Username : '{1}' ", RepositoryName, Username));

            var url = string.Format("repos/show/{1}/{0}/branches", RepositoryName, Username);

            var result = ConsumeJsonUrl<Models.Internal.BranchesCollection>(url);

            return result == null ? null : result.Branches.Dict.Select(p => new Models.TagOrBranch { Name = p.Key, Sha = p.Value }).ToArray();
        }
    }
}

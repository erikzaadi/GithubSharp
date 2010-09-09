using System.Collections.Generic;
using GithubSharp.Core.Services;
using System.Collections.Specialized;

namespace GithubSharp.Core.API
{
    public class Issues : Base.BaseAPI
    {
        public Issues(ICacheProvider CacheProvider, ILogProvider LogProvider) : base(CacheProvider, LogProvider) { }

        public IEnumerable<Models.Issue> Search(
            string RepositoryName,
            string Username,
            Models.IssueState State,
            string Search)
        {
            string state = State == Models.IssueState.open ? "open" : "closed";
            LogProvider.LogMessage(string.Format("Issues.Search - '{0}', RepositoryName : '{1}', Username : '{2}', State : '{3}'", Search, RepositoryName, Username, state));

            var url = string.Format("issues/search/{0}/{1}/{2}/{3}",
                Username,
                RepositoryName,
                state,
                Search);

            var result = ConsumeJsonUrl<Models.Internal.IssuesCollection>(url);

            return result == null ? null : result.issues;
        }


        public IEnumerable<Models.Issue> List(
         string RepositoryName,
         string Username,
         Models.IssueState State)
        {
            string state = State == Models.IssueState.open ? "open" : "closed";
            LogProvider.LogMessage(string.Format("Issues.List - RepositoryName : '{0}', Username : '{1}', State : '{2}'", RepositoryName, Username, state));

            var url = string.Format("issues/list/{0}/{1}/{2}",
                Username,
                RepositoryName,
                state);

            var result = ConsumeJsonUrl<Models.Internal.IssuesCollection>(url);

            return result == null ? null : result.issues;
        }

        public Models.Issue View(
            string RepositoryName,
            string Username,
            int Id)
        {
            LogProvider.LogMessage(string.Format("Issues.View - RepositoryName: '{0}', Username : '{1}', Id : '{2}'", RepositoryName, Username, Id));

            var url = string.Format("issues/show/{0}/{1}/{2}",
                Username,
                RepositoryName,
                Id);

            var result = ConsumeJsonUrl<Models.Internal.IssueContainer>(url);

            return result != null ? result.issue : null;
        }

        public Models.Issue Open(string RepositoryName, string Username, string Title, string Body)
        {
            LogProvider.LogMessage(string.Format("Issues.Open - RepositoryName: '{0}', Username : '{1}', Title : '{2}'", RepositoryName, Username, Title));

            Authenticate();

            var url = string.Format("issues/open/{0}/{1}",
               Username,
               RepositoryName);

            var formValues = new NameValueCollection();
            formValues.Add("title", Title);
            formValues.Add("body", Body);

            var result = ConsumeJsonUrlAndPostData<Models.Internal.IssueContainer>(url, formValues);

            return result != null ? result.issue : null;
        }

        public Models.Issue ReOpen(string RepositoryName, string Username, int Id)
        {
            LogProvider.LogMessage(string.Format("Issues.ReOpen - RepositoryName: '{0}', Username : '{1}', Id : '{2}'", RepositoryName, Username, Id));

            Authenticate();

            var url = string.Format("issues/reopen/{0}/{1}/{2}",
               Username,
               RepositoryName,
               Id);

            var formValues = new NameValueCollection();

            var result = ConsumeJsonUrlAndPostData<Models.Internal.IssueContainer>(url, formValues);

            return result != null ? result.issue : null;
        }

        public Models.Issue Close(string RepositoryName, string Username, int Id)
        {
            LogProvider.LogMessage(string.Format("Issues.Close - RepositoryName: '{0}', Username : '{1}', Id : '{2}'", RepositoryName, Username, Id));

            Authenticate();

            var url = string.Format("issues/close/{0}/{1}/{2}",
               Username,
               RepositoryName,
               Id);

            var formValues = new NameValueCollection();

            var result = ConsumeJsonUrlAndPostData<Models.Internal.IssueContainer>(url, formValues);

            return result != null ? result.issue : null;
        }


        public Models.Issue Edit(string RepositoryName, string Username, int Id, string Title, string Body)
        {
            LogProvider.LogMessage(string.Format("Issues.Open - RepositoryName: '{0}', Username : '{1}', Title : '{2}', Id : '{3}'", RepositoryName, Username, Title, Id));

            Authenticate();

            var url = string.Format("issues/edit/{0}/{1}/{2}",
               Username,
               RepositoryName,
               Id);

            var formValues = new NameValueCollection();
            formValues.Add("title", Title);
            formValues.Add("body", Body);

            var result = ConsumeJsonUrlAndPostData<Models.Internal.IssueContainer>(url, formValues);

            return result != null ? result.issue : null;
        }

        public string[] Labels(string RepositoryName, string Username)
        {
            LogProvider.LogMessage(string.Format("Issues.List - Labels : RepositoryName '{0}', Username : '{1}'", RepositoryName, Username));

            var url = string.Format("issues/labels/{0}/{1} ",
                Username,
                RepositoryName);

            var result = ConsumeJsonUrl<Models.Internal.LabelsCollection>(url);

            return result != null ? result.labels : null;
        }

        public string[] AddLabel(string RepositoryName, string Username, int Id, string Label)
        {
            LogProvider.LogMessage(string.Format("Issues.AddLabel - RepositoryName: '{0}', Username : '{1}', Label : '{2}', Id : '{3}'", RepositoryName, Username, Label, Id));

            Authenticate();

            var url = string.Format("issues/label/add/{0}/{1}/{2}/{3}",
               Username,
               RepositoryName,
               Label,
               Id);

            var formValues = new NameValueCollection();

            var result = ConsumeJsonUrlAndPostData<Models.Internal.LabelsCollection>(url, formValues);

            return result != null ? result.labels : null;
        }

        public string[] RemoveLabel(string RepositoryName, string Username, int Id, string Label)
        {
            LogProvider.LogMessage(string.Format("Issues.RemoveLabel - RepositoryName: '{0}', Username : '{1}', Label : '{2}', Id : '{3}'", RepositoryName, Username, Label, Id));

            Authenticate();

            var url = string.Format("issues/label/remove/{0}/{1}/{2}/{3}",
               Username,
               RepositoryName,
               Label,
               Id);

            var formValues = new NameValueCollection();

            var result = ConsumeJsonUrlAndPostData<Models.Internal.LabelsCollection>(url, formValues);

            return result != null ? result.labels : null;
        }

        public IEnumerable<Models.Comment> Comments(string RepositoryName, string Username, int Id)
        {
            LogProvider.LogMessage(string.Format("Issues.Comments - RepositoryName: '{0}', Username : '{1}', Id : '{2}'", RepositoryName, Username, Id));

            var url = string.Format("issues/comments/{0}/{1}/{2}",
                Username,
                RepositoryName,
                Id);

            var result = ConsumeJsonUrl<Models.Internal.CommentsCollection>(url);

            return result != null ? result.comments : null;
        }

        public bool CommentOnIssue(string RepositoryName, string Username, int Id, string Comment)
        {
            LogProvider.LogMessage(string.Format("Issues.CommentOnIssue - RepositoryName: '{0}', Username : '{1}', Id : '{2}'", RepositoryName, Username, Id));

            Authenticate();

            var url = string.Format("issues/comment/{0}/{1}/{2}",
               Username,
               RepositoryName,
               Id);

            var formValues = new NameValueCollection();
            formValues.Add("comment", Comment);

            var result = ConsumeJsonUrlAndPostData<Models.Internal.CommentSavedContainer>(url, formValues);

            return result != null && result.comment != null ? result.comment.status == "saved" : false;
        }
    }
}

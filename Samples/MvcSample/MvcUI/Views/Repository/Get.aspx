<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<GithubSharp.Samples.MvcSample.MvcApplication.Models.ViewModels.BaseViewModel<GithubSharp.Core.Models.Repository>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Get
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Repository Details</h2>
    <p>
        <%=Html.ActionLink("Back to Search", "Index") %>
        <%= Html.If(Model.CurrentUser != null && Model.ModelParameter.owner == Model.CurrentUser.Name, ()=> 
    string.Format(" | {0} | {1} ", 
        Html.ActionLink("Delete", "Delete", new { RepositoryName = Model.ModelParameter.name, Username = Model.ModelParameter.owner }) ,
        Html.ActionLink("Edit", "Edit", new { /* id=Model.ModelParameter.PrimaryKey */ })), ()=> Html.ActionLink("Fork", "Fork", new {RepositoryName = Model.ModelParameter.name , Username = Model.ModelParameter.owner})) %>
    </p>
    <fieldset>
        <legend>Fields</legend>
        <p>
            url:
            <%= Html.Encode(Model.ModelParameter.url) %>
        </p>
        <p>
            description:
            <%= Html.Encode(Model.ModelParameter.description) %>
        </p>
        <p>
            homepage:
            <%= Html.Encode(Model.ModelParameter.homepage) %>
        </p>
        <p>
            name:
            <%= Html.Encode(Model.ModelParameter.name) %>
        </p>
        <p>
            owner:
            <%= Html.Encode(Model.ModelParameter.owner) %>
        </p>
        <p>
            fork:
            <%= Html.Encode(Model.ModelParameter.fork) %>
        </p>
        <p>
            private:
            <%= Html.Encode(Model.ModelParameter.@private) %>
        </p>
        <p>
            open_issues:
            <%= Html.Encode(Model.ModelParameter.open_issues) %>
        </p>
        <p>
            watchers:
            <%= Html.Encode(Model.ModelParameter.watchers) %>
        </p>
        <p>
            forks:
            <%= Html.Encode(Model.ModelParameter.forks) %>
        </p>
        <p>
            WatchersURL:
            <%= Html.Encode(Model.ModelParameter.WatchersURL) %>
        </p>
        <p>
            DownloadURL:
            <%= Html.Encode(Model.ModelParameter.DownloadURL) %>
        </p>
        <p>
            ForksURL:
            <%= Html.Encode(Model.ModelParameter.ForksURL) %>
        </p>
        <p>
            IssuesURL:
            <%= Html.Encode(Model.ModelParameter.IssuesURL) %>
        </p>
        <p>
            WikiURL:
            <%= Html.Encode(Model.ModelParameter.WikiURL) %>
        </p>
        <p>
            GraphsURL:
            <%= Html.Encode(Model.ModelParameter.GraphsURL) %>
        </p>
        <p>
            ForkQuoueURL:
            <%= Html.Encode(Model.ModelParameter.ForkQuoueURL) %>
        </p>
        <p>
            GitCloneURL:
            <%= Html.Encode(Model.ModelParameter.GitCloneURL) %>
        </p>
        <p>
            HttpCloneURL:
            <%= Html.Encode(Model.ModelParameter.HttpCloneURL) %>
        </p>
        <p>
            ForkURL:
            <%= Html.Encode(Model.ModelParameter.ForkURL) %>
        </p>
        <p>
            WatchURL:
            <%= Html.Encode(Model.ModelParameter.WatchURL) %>
        </p>
    </fieldset>
</asp:Content>

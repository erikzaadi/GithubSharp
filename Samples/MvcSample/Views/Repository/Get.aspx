<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GithubSharp.Core.Models.Repository>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Get
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Get</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            url:
            <%= Html.Encode(Model.url) %>
        </p>
        <p>
            description:
            <%= Html.Encode(Model.description) %>
        </p>
        <p>
            homepage:
            <%= Html.Encode(Model.homepage) %>
        </p>
        <p>
            name:
            <%= Html.Encode(Model.name) %>
        </p>
        <p>
            owner:
            <%= Html.Encode(Model.owner) %>
        </p>
        <p>
            fork:
            <%= Html.Encode(Model.fork) %>
        </p>
        <p>
            private:
            <%= Html.Encode(Model.@private) %>
        </p>
        <p>
            open_issues:
            <%= Html.Encode(Model.open_issues) %>
        </p>
        <p>
            watchers:
            <%= Html.Encode(Model.watchers) %>
        </p>
        <p>
            forks:
            <%= Html.Encode(Model.forks) %>
        </p>
        <p>
            WatchersURL:
            <%= Html.Encode(Model.WatchersURL) %>
        </p>
        <p>
            DownloadURL:
            <%= Html.Encode(Model.DownloadURL) %>
        </p>
        <p>
            ForksURL:
            <%= Html.Encode(Model.ForksURL) %>
        </p>
        <p>
            IssuesURL:
            <%= Html.Encode(Model.IssuesURL) %>
        </p>
        <p>
            WikiURL:
            <%= Html.Encode(Model.WikiURL) %>
        </p>
        <p>
            GraphsURL:
            <%= Html.Encode(Model.GraphsURL) %>
        </p>
        <p>
            ForkQuoueURL:
            <%= Html.Encode(Model.ForkQuoueURL) %>
        </p>
        <p>
            GitCloneURL:
            <%= Html.Encode(Model.GitCloneURL) %>
        </p>
        <p>
            HttpCloneURL:
            <%= Html.Encode(Model.HttpCloneURL) %>
        </p>
        <p>
            ForkURL:
            <%= Html.Encode(Model.ForkURL) %>
        </p>
        <p>
            WatchURL:
            <%= Html.Encode(Model.WatchURL) %>
        </p>
    </fieldset>
    <p>
        <%=Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>


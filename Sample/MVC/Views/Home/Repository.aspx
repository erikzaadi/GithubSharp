<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<GithubSharp.Domain.Models.Repository>" MasterPageFile="~/Views/Shared/Site.master" %>
<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" ID="MainContentContent" runat="server">
<%= Html.ActionLink("Back to list", "List") %>
<h2><%= Model.Name %></h2>
<h4><a href="<%= Model.Url %>">Url at Github</a> <%= Html.ActionLink("Browse Files", "Tree", new {id =Model.Name}) %> <%= Html.ActionLink("Show Commits", "Commits", new {id=Model.Name} ) %></h4> 
<div>Description : <%= Model.Description %></div>
<div>Homepage : <%= Model.Homepage %></div>
<div>Owner : <%= Model.Owner %></div>
<div>Fork : <%= Model.Fork %></div>
<div>IsPrivate : <%= Model.IsPrivate %></div>
<div>OpenIssues : <%= Model.OpenIssues %></div>
<div>Watchers : <%= Model.Watchers %></div>
<div>Forks : <%= Model.Forks %></div>
<div>WatchersURL : <%= Model.WatchersURL %></div>
<div>DownloadURL : <%= Model.DownloadURL %></div>
<div>ForksURL : <%= Model.ForksURL %></div>
<div>IssuesURL : <%= Model.IssuesURL %></div>
<div>WikiURL : <%= Model.WikiURL %></div>
<div>GraphsURL : <%= Model.GraphsURL %></div>
<div>ForkQuoueURL : <%= Model.ForkQuoueURL %></div>
<div>GitCloneURL : <%= Model.GitCloneURL %></div>
<div>HttpCloneURL : <%= Model.HttpCloneURL %></div>
<div>ForkURL : <%= Model.ForkURL %></div>
<div>WatchURL : <%= Model.WatchURL %></div>
</asp:Content>


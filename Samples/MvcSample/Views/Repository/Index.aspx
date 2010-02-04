<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<GithubSharp.Core.Models.RepositoryFromSearch>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Search
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Search</h2>
    <% using (Html.BeginForm(new { action = "Search" }))
       { %>
    <%= Html.TextBox("id")%>
    <button type="submit">
        GO</button>
    <%} %>
    <hr />
    <% if (Model != null && Model.Count() > 0)
       {
           Model.ToList().ForEach(repo =>
           { %>
    <h3>
        <%= repo.name %></h3>
    <p>
        <%= repo.description%></p>
    <h4>
        <%= Html.ActionLink(repo.username, "List", new {id=repo.username})%></h4>
    <div>
        <%= Html.ActionLink("Details", "Get", new {RepositoryName = repo.name, Username=repo.username}) %></div>
    <%});
       } %>
</asp:Content>

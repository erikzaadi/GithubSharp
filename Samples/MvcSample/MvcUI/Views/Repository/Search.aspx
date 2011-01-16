<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<GithubSharp.MvcSample.MvcApplication.Models.ViewModels.BaseViewModel<System.Collections.Generic.IEnumerable<GithubSharp.Core.Models.RepositoryFromSearch>>>" %>

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
    <div>
        <%= Html.ActionLink("Create New","Create") %></div>
    <%} %>
    <hr />
    <% if (Model.ModelParameter != null && Model.ModelParameter.Count() > 0)
       {
           Model.ModelParameter.ToList().ForEach(repo =>
           { %>
    <h3>
        <%= repo.Name %></h3>
    <p>
        <%= repo.Description%></p>
    <h4>
        <%= Html.ActionLink(repo.Username, "List", new {id=repo.Username})%></h4>
    <div>
        <%= Html.ActionLink("Details", "Get", new {RepositoryName = repo.Name, Username=repo.Username}) %></div>
    <%});
       } %>
</asp:Content>

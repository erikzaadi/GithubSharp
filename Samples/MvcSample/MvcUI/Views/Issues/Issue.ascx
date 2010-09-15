<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GithubSharp.Core.Models.Issue>" %>
<div class="issue">
    <h5>
        <%= Html.Encode(Model.Title) %>
        <em>#<%= Model.Number%></em></h5>
    <div>
        <%= Html.Encode(Model.Body)%></div>
    <div>
        Created :
        <%= Model.CreatedAt%>
        , State :
        <%= Model.State == GithubSharp.Core.Models.IssueState.Closed ? "closed" : "open"%></div>
</div>

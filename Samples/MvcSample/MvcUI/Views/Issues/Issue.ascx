<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GithubSharp.Core.Models.Issue>" %>
<div class="issue">
    <h5>
        <%= Html.Encode(Model.title) %>
        <em>#<%= Model.number%></em></h5>
    <div>
        <%= Html.Encode(Model.body)%></div>
    <div>
        Created :
        <%= Model.created_at%>
        , State :
        <%= Model.state == GithubSharp.Core.Models.IssueState.closed ? "closed" : "open"%></div>
</div>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GithubSharp.Samples.MvcSample.MvcApplication.Models.ViewModels.BaseViewModel<IEnumerable<GithubSharp.Core.Models.Comment>>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Comments
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Comments</h2>
    <% if (Model.ModelParameter != null && Model.ModelParameter.Count() > 0)
       { %>
    <ul>
        <% foreach (var comment in Model.ModelParameter)
           { %>
        <li>
            <div class="comment">
                <h5>
                    <em>#<%= comment.id%></em></h5>
                <div>
                    <%= Html.Encode(comment.body)%></div>
                <div>
                    Created :
                    <%= comment.created_at%>
                    by :
                    <%= comment.user%></div>
            </div>
        </li>
        <%} %>
    </ul>
    <%}
       else
       { %>
    <h4>
        No comments found</h4>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsIncludes" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="DocumentReadies" runat="server">
</asp:Content>

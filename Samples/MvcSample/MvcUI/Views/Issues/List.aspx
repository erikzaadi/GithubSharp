<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GithubSharp.MvcSample.MvcApplication.Models.ViewModels.BaseViewModel<System.Collections.Generic.IEnumerable<GithubSharp.Core.Models.Issue>>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        List</h2>
    <% if (Model.ModelParameter != null && Model.ModelParameter.Count() > 0)
       {%>
    <ul>
        <%
            foreach (var issue in Model.ModelParameter)
            {
        %>
        <li>
            <% Html.RenderPartial("Issue", issue); %>
        </li>
        <%} %>
    </ul>
    <%
        }
       else
       { %>
    <h4>
        No issues found</h4>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsIncludes" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="DocumentReadies" runat="server">
</asp:Content>

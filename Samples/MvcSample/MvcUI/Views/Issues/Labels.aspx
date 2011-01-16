<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GithubSharp.MvcSample.MvcApplication.Models.ViewModels.BaseViewModel<System.String[]>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Labels
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Labels</h2>
    <% if (Model.ModelParameter != null && Model.ModelParameter.Count() > 0)
       { %>
    <ul>
        <% foreach (var label in Model.ModelParameter)
           { %>
        <li>
            <%= label %>
        </li>
        <%} %>
    </ul>
    <%}
       else
       { %>
    <h4>
        No labels found</h4>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsIncludes" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="DocumentReadies" runat="server">
</asp:Content>

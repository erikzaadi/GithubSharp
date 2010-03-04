<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GithubSharp.Samples.MvcSample.MvcApplication.Models.ViewModels.BaseViewModel<IEnumerable<GithubSharp.Core.Models.Language>>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Languages
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Languages</h2>
    <ul>
        <% foreach (var lang in Model.ModelParameter)
           { %>
        <li>
            <div>
                Name:<%= lang.Name %></div>
            <div>
                CalculatedBytes:<%= lang.CalculatedBytes %></div>
        </li>
        <%} %>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsIncludes" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="DocumentReadies" runat="server">
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GithubSharp.MvcSample.MvcApplication.Models.ViewModels.BaseViewModel<System.Collections.Generic.IEnumerable<GithubSharp.Core.Models.TagOrBranch>>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Branches
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Branches</h2>
    <ul>
        <% foreach (var lang in Model.ModelParameter)
           { %>
        <li>
            <div>
                Name:<%= lang.Name %></div>
            <div>
                Sha:<%= lang.Sha %></div>
        </li>
        <%} %>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsIncludes" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="DocumentReadies" runat="server">
</asp:Content>

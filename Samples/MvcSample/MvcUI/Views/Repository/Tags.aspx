<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GithubSharp.Samples.MvcSample.MvcApplication.Models.ViewModels.BaseViewModel<IEnumerable<GithubSharp.Core.Models.TagOrBranch>>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Tags
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Tags</h2>
    <% 
        if (Model.ModelParameter != null && Model.ModelParameter.Count() > 0)
        { %>
    <ul>
        <%
            foreach (var lang in Model.ModelParameter)
            { %>
        <li>
            <div>
                Name:<%= lang.Name%></div>
            <div>
                Sha:<%= lang.Sha%></div>
        </li>
        <%}%>
    </ul>
    <%
        }
        else
        {%>
    <h4>
        No tags found..</h4>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsIncludes" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="DocumentReadies" runat="server">
</asp:Content>

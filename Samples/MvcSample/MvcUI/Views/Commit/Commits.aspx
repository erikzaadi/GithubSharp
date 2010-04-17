<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GithubSharp.Samples.MvcSample.MvcApplication.Models.ViewModels.BaseViewModel<IEnumerable<GithubSharp.Core.Models.Commit>>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Commits
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Commits</h2>
    <% if (Model != null && Model.ModelParameter != null)
       {
           Model.ModelParameter.ToList().ForEach(commit =>
           { %>
    <hr />
    <div>
        <% Html.RenderPartial("CommitRenderer", commit); %>
    </div>
    <%});
       }
       else
       { %>
    No commits found..
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsIncludes" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="DocumentReadies" runat="server">
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GithubSharp.Samples.MvcSample.MvcApplication.Models.ViewModels.BaseViewModel<GithubSharp.Core.Models.SingleFileCommit>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Commit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Commit</h2>
    <% if (Model != null && Model.ModelParameter != null)
       {
           Html.RenderPartial("CommitRenderer", Model.ModelParameter);
       }
       else
       { %>
    No commit found..
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsIncludes" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="DocumentReadies" runat="server">
</asp:Content>

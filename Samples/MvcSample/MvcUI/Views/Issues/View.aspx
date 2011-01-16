<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GithubSharp.MvcSample.MvcApplication.Models.ViewModels.BaseViewModel<GithubSharp.Core.Models.Issue>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    View
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        View</h2>
    <% Html.RenderPartial("Issue", Model.ModelParameter); %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsIncludes" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="DocumentReadies" runat="server">
</asp:Content>

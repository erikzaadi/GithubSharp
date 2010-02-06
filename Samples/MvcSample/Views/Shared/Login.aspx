<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<GithubSharp.Samples.MvcSample.Models.ViewModels.BaseViewModel<GithubSharp.Samples.MvcSample.Models.ViewModels.LoginViewModel>>"
    MasterPageFile="~/Views/Shared/Site.master" %>

<asp:Content runat="server" ID="main" ContentPlaceHolderID="MainContent">
    <% Html.RenderPartial("LoginControl", Model.ModelParameter); %>
</asp:Content>

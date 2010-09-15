<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<GithubSharp.MvcSample.MvcApplication.Models.ViewModels.BaseViewModel<GithubSharp.Samples.MvcSample.MvcApplication.Models.ViewModels.LoginViewModel>"
    MasterPageFile="~/Views/Shared/Site.master" %>

<asp:Content runat="server" ID="main" ContentPlaceHolderID="MainContent">
    <% Html.RenderPartial("LoginControl", Model.ModelParameter); %>
</asp:Content>

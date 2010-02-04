<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<GithubSharp.Samples.MvcSample.Models.ViewModels.BaseViewModel<string>>" MasterPageFile="~/Views/Shared/Site.master" %>
<asp:Content runat="server" id="main" ContentPlaceHolderID="MainContent">
<%= Model.ModelParameter %>  
<% using(Html.BeginForm()){ %>
<div>User : <%= Html.TextBox("user") %></div>
<div>APIToken : <%= Html.TextBox("apitoken") %></div>
<button type="submit">GO</button>
<% } %>
</asp:Content>

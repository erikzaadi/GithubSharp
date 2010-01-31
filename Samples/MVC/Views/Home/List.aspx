<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<IList<GithubSharp.Domain.Models.Repository>>" MasterPageFile="~/Views/Shared/Site.master" %>
<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" ID="MainContentContent" runat="server">
<ul>
<% Model.ToList().ForEach(rep => { %>

<li><%= Html.ActionLink(rep.Name, "Repository", new { id = rep.Name}) %></li>

<%}); %>
</ul>
</asp:Content>


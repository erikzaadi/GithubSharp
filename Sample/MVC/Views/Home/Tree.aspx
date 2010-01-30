<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<GithubSharp.Domain.Models.Tree>" MasterPageFile="~/Views/Shared/Site.master" %>
<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" ID="MainContentContent" runat="server">
<h2><%= Model.Sha %></h2>
<ul>

<% Model.BlobItems.ToList().ForEach(blobItem => { %>
<li>
<% if (blobItem.Type == GithubSharp.Domain.Models.BlobItemType.Tree) { %>
<%= Html.ActionLink(blobItem.Name, "Tree", new { sha= blobItem.Sha, id=Model.RepositoryName }) %> 
<%}
else
 { %>
 <%= Html.ActionLink(blobItem.Name, "Blob", new { sha= blobItem.Sha, id=Model.RepositoryName }) %>
 <%} %>
</li>

<%}); %>
</ul>
</asp:Content>


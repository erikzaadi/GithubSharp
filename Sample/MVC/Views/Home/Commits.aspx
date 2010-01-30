<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<IList<GithubSharp.Domain.Models.Commit>>" MasterPageFile="~/Views/Shared/Site.master" %>
<asp:Content ContentPlaceHolderID="head" ID="headContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" ID="MainContentContent" runat="server">
<% if (Model != null) { %>
<ul>
<% Model.ToList().ForEach(commit=>{ %>
<li>
<h3><%= commit.ID%> </h3>
<div>
<%= commit.Message %>
</div>
<h5>Committed : <%= commit.Tree %> <em> - <%= commit.Committed %></em></h5>
</li>
<%}); %>
</ul>
<%} 
	else { %>
	<h2>No commits</h2>
	<%}%>
</asp:Content>


<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<string>" MasterPageFile="~/Views/Shared/Site.master" %>
<asp:Content runat="server" id="titleContent" ContentPlaceHolderID="head">
<title>Title</title>
</asp:Content>
<asp:Content runat="server" id="bodyContent" ContentPlaceHolderID="MainContent">
<h2>Sample</h2>
<h3><%= Model %><h3>
<% Html.BeginForm("SetUser", "Home", FormMethod.Post); %>
<input type="text" name="id" />
<input type="submit" value="Submit" />
<% Html.EndForm(); %>
</asp:Content>

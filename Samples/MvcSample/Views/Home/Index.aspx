<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
    </h2>
    <p>
        <%= Html.ActionLink("Repositories", "Index","Repository") %>
    </p>
</asp:Content>

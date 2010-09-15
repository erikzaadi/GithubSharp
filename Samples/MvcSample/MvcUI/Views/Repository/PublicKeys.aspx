<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GithubSharp.MvcSample.MvcApplication.Models.ViewModels.BaseViewModel<System.Collections.Generic.IEnumerable<GithubSharp.Core.Models.PublicKey>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    PublicKeys
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        PublicKeys</h2>
    <% if (Model.ModelParameter != null && Model.ModelParameter.Count() > 0)
       { %>
    <table>
        <tr>
            <th>
            </th>
            <th>
                title
            </th>
            <th>
                id
            </th>
            <th>
                key
            </th>
        </tr>
        <% foreach (var item in Model.ModelParameter)
           { %>
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "EditPublicKey", new { id = item.Id })%>
                |
            </td>
            <td>
                <%= Html.Encode(item.Title)%>
            </td>
            <td>
                <%= Html.Encode(item.Id)%>
            </td>
            <td>
                <%= Html.Encode(item.Key)%>
            </td>
        </tr>
        <% } %>
    </table>
    <%}
       else
       { %>
    <div class="notice">
        No public keys available</div>
    <%} %>
    <p>
        <%= Html.ActionLink("Create New Public Key", "CreatePublicKey") %>
    </p>
</asp:Content>

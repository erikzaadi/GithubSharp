<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<GithubSharp.Core.Models.Repository>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>List</h2>

    <table>
        <tr>
            <th></th>
            <th>
                url
            </th>
            <th>
                description
            </th>
            <th>
                homepage
            </th>
            <th>
                name
            </th>
            <th>
                owner
            </th>
            <th>
                fork
            </th>
            <th>
                private
            </th>
            <th>
                open_issues
            </th>
            <th>
                watchers
            </th>
            <th>
                forks
            </th>
            <th>
                WatchersURL
            </th>
            <th>
                DownloadURL
            </th>
            <th>
                ForksURL
            </th>
            <th>
                IssuesURL
            </th>
            <th>
                WikiURL
            </th>
            <th>
                GraphsURL
            </th>
            <th>
                ForkQuoueURL
            </th>
            <th>
                GitCloneURL
            </th>
            <th>
                HttpCloneURL
            </th>
            <th>
                ForkURL
            </th>
            <th>
                WatchURL
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }) %> |
                <%= Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ })%>
            </td>
            <td>
                <%= Html.Encode(item.url) %>
            </td>
            <td>
                <%= Html.Encode(item.description) %>
            </td>
            <td>
                <%= Html.Encode(item.homepage) %>
            </td>
            <td>
                <%= Html.Encode(item.name) %>
            </td>
            <td>
                <%= Html.Encode(item.owner) %>
            </td>
            <td>
                <%= Html.Encode(item.fork) %>
            </td>
            <td>
                <%= Html.Encode(item.@private) %>
            </td>
            <td>
                <%= Html.Encode(item.open_issues) %>
            </td>
            <td>
                <%= Html.Encode(item.watchers) %>
            </td>
            <td>
                <%= Html.Encode(item.forks) %>
            </td>
            <td>
                <%= Html.Encode(item.WatchersURL) %>
            </td>
            <td>
                <%= Html.Encode(item.DownloadURL) %>
            </td>
            <td>
                <%= Html.Encode(item.ForksURL) %>
            </td>
            <td>
                <%= Html.Encode(item.IssuesURL) %>
            </td>
            <td>
                <%= Html.Encode(item.WikiURL) %>
            </td>
            <td>
                <%= Html.Encode(item.GraphsURL) %>
            </td>
            <td>
                <%= Html.Encode(item.ForkQuoueURL) %>
            </td>
            <td>
                <%= Html.Encode(item.GitCloneURL) %>
            </td>
            <td>
                <%= Html.Encode(item.HttpCloneURL) %>
            </td>
            <td>
                <%= Html.Encode(item.ForkURL) %>
            </td>
            <td>
                <%= Html.Encode(item.WatchURL) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<GithubSharp.MvcSample.MvcApplication.Models.ViewModels.BaseViewModel<System.Collections.Generic.IEnumerable<GithubSharp.Core.Models.Repository>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        User repositories
    </h2>
    <p>
        <%=Html.ActionLink("Back to Search", "Index") %>
    </p>
    <table>
        <tr>
            <th>
            </th>
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
        <% foreach (var item in Model.ModelParameter)
           { %>
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }) %>
                |
                <%= Html.ActionLink("Details", "Get", new { RepositoryName = item.Name, Username = item.Owner })%>
                <%= Html.If(Model.CurrentUser != null && item.Owner == Model.CurrentUser.Name, ()=> Html.ActionLink("Delete", "Delete", new { RepositoryName = item.Name, Username = item.Owner }))%>
            </td>
            <td>
                <%= Html.Encode(item.URL) %>
            </td>
            <td>
                <%= Html.Encode(item.Description) %>
            </td>
            <td>
                <%= Html.Encode(item.Homepage) %>
            </td>
            <td>
                <%= Html.Encode(item.Name) %>
            </td>
            <td>
                <%= Html.Encode(item.Owner) %>
            </td>
            <td>
                <%= Html.Encode(item.Fork) %>
            </td>
            <td>
                <%= Html.Encode(item.Private) %>
            </td>
            <td>
                <%= Html.Encode(item.OpenIssues) %>
            </td>
            <td>
                <%= Html.Encode(item.Watchers) %>
            </td>
            <td>
                <%= Html.Encode(item.Forks) %>
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
</asp:Content>

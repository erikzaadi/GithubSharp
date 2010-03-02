<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GithubSharp.Samples.MvcSample.MvcApplication.Models.ViewModels.BaseViewModel<string>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create Repository
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Create</h2>
    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
    <% using (Html.BeginForm())
       {%>
    <fieldset>
        <legend>Fields</legend>
        <p>
            <label for="RepositoryName">
                Name:</label>
            <%= Html.TextBox("RepositoryName")%>
            <%= Html.ValidationMessage("RepositoryName", "*")%>
        </p>
        <p>
            <label for="Description">
                Description:</label>
            <%= Html.TextArea("Description")%>
        </p>
        <p>
            <label for="HomePage">
                HomePage:</label>
            <%= Html.TextBox("HomePage")%>
        </p>
        <p>
            <label for="HomePage">
                Public:</label>
            <%= Html.CheckBox("Public")%>
        </p>
        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
    <%--= Html.AntiForgeryToken() Doesn't work on mono :( --%>
    <% } %>
    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>

<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GithubSharp.Core.Models.Commit>" %>
<fieldset>
    <legend>Fields</legend>
    <div class="display-label">
        url</div>
    <div class="display-field">
        <%= Html.Encode(Model.url) %></div>
    <div class="display-label">
        id</div>
    <div class="display-field">
        <%= Html.Encode(Model.id) %></div>
    <div class="display-label">
        committed_date</div>
    <div class="display-field">
        <%= Html.Encode(String.Format("{0:g}", Model.committed_date)) %></div>
    <div class="display-label">
        authored_date</div>
    <div class="display-field">
        <%= Html.Encode(String.Format("{0:g}", Model.authored_date)) %></div>
    <div class="display-label">
        message</div>
    <div class="display-field">
        <%= Html.Encode(Model.message) %></div>
    <div class="display-label">
        tree</div>
    <div class="display-field">
        <%= Html.Encode(Model.tree) %></div>
    <% if (Model is GithubSharp.Core.Models.SingleFileCommit)
       {
           var single = Model as GithubSharp.Core.Models.SingleFileCommit;
    %>
    <div>
        <h3>
            File information :
        </h3>
        <div>
            <h4>
                Added:</h4>
            <%
                single.added.ToList().ForEach(added =>
                 Html.RenderPartial("SingleFileCommitRenderer", added)); %>
        </div>
        <div>
            <h4>
                Removed:</h4>
            <%
                single.removed.ToList().ForEach(removed =>
                 Html.RenderPartial("SingleFileCommitRenderer", removed)); %>
        </div>
        <div>
            <h4>
                Modified:</h4>
            <%
                single.modified.ToList().ForEach(modified =>
                 Html.RenderPartial("SingleFileCommitRenderer", modified)); %>
        </div>
    </div>
    <%
        }
       else
       {
    %>
    <div>
        <%= Html.ActionLink("Commit details", "CommitForSingleFile", "Commit", new { Username = Model.committer.login, RepositoryName = Request["RepositoryName"], Sha = Model.id }, null)%>
    </div>
    <%
        } %>
</fieldset>

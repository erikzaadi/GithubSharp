<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GithubSharp.Core.Models.Commit>" %>
<fieldset>
    <legend>Fields</legend>
    <div class="display-label">
        url</div>
    <div class="display-field">
        <%= Html.Encode(Model.URL) %></div>
    <div class="display-label">
        id</div>
    <div class="display-field">
        <%= Html.Encode(Model.Id) %></div>
    <div class="display-label">
        committed_date</div>
    <div class="display-field">
        <%= Html.Encode(String.Format("{0:g}", Model.CommittedDate)) %></div>
    <div class="display-label">
        authored_date</div>
    <div class="display-field">
        <%= Html.Encode(String.Format("{0:g}", Model.AuthoredDate)) %></div>
    <div class="display-label">
        message</div>
    <div class="display-field">
        <%= Html.Encode(Model.Message) %></div>
    <div class="display-label">
        tree</div>
    <div class="display-field">
        <%= Html.Encode(Model.Tree) %></div>
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
                single.Added.ToList().ForEach(added =>
                 Html.RenderPartial("SingleFileCommitRenderer", added)); %>
        </div>
        <div>
            <h4>
                Removed:</h4>
            <%
                single.Removed.ToList().ForEach(removed =>
                 Html.RenderPartial("SingleFileCommitRenderer", removed)); %>
        </div>
        <div>
            <h4>
                Modified:</h4>
            <%
                single.Modified.ToList().ForEach(modified =>
                 Html.RenderPartial("SingleFileCommitRenderer", modified)); %>
        </div>
    </div>
    <%
        }
       else
       {
    %>
    <div>
        <%= Html.ActionLink("Commit details", "CommitForSingleFile", "Commit", new { Username = Model.Committer.Login, RepositoryName = Request["RepositoryName"], Sha = Model.Id }, null)%>
    </div>
    <%
        } %>
</fieldset>

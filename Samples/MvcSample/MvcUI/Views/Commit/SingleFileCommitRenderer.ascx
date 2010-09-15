<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GithubSharp.Core.Models.SingleFileCommitFileReference>" %>
<div>
    filename :
    <%= Html.Encode(Model.Filename) %>
</div>

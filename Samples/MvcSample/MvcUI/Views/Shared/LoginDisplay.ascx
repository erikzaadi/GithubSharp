<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GithubSharp.Samples.MvcSample.MvcApplication.Models.ViewModels.IBaseViewModel>" %>
<div id="logindisplay">
    &nbsp;
    <%= Html.If(ViewContext.RouteData.GetRequiredString("action") != "Login", () =>
    Html.If(Model.CurrentUser == null,
        () => Html.ActionLink("Login", "Login", "Home"),
        () => MvcHtmlString.Create(string.Format("{0} {1}", Model.CurrentUser.Name, Html.ActionLink("Change", "Login", "Home")))
        )
    )%>
</div>

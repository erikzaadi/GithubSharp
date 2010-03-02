<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GithubSharp.Samples.MvcSample.Models.ViewModels.LoginViewModel>" %>
<div class="login">
    <% using (Html.BeginForm("Login", "Home"))
       { %>
    <fieldset>
        <legend>Login</legend>
        <div>
            <span>User : </span>
            <%= Html.TextBox("user") %>
        </div>
        <div>
            <span>APIToken : </span>
            <%= Html.TextBox("apitoken") %>
        </div>
        <%= Html.Hidden("returnURL", Model.ReturnURL) %>
        <%= Html.AntiForgeryToken() %>
 		<div>
            <span>&nbsp;</span>
            <input type="submit" value="GO" />
        </div>
        <div id="errormessage">
            <% Html.If(!string.IsNullOrEmpty(Model.Message), () =>
               { %>
            <div class="error span-8">
                <%=Model.Message%></div>
            <%}); %>
        </div>
    </fieldset>
    <% } %>
</div>

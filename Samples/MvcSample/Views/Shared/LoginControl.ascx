<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GithubSharp.Samples.MvcSample.Models.ViewModels.LoginViewModel>" %>
<div class="login">
	<% using(Html.BeginForm("Login", "Home")){ %>
		<fieldset>
			<legend>Login</legend>
			<div>
				<label for="user">User : </label><%= Html.TextBox("user") %>
			</div>
			<div>
				<label for="apitoken">APIToken : </label><%= Html.TextBox("apitoken") %>
			</div>
			<%= Html.Hidden("returnURL", Model.ReturnURL) %>
			<label class="error" id="errormessage"><%= Model.Message %>&nbsp;</label><button type="submit">GO</button>
		</fieldset>
	<% } %>
</div>
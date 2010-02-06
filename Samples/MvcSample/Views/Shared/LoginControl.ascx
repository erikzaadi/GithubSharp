<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GithubSharp.Samples.MvcSample.Models.ViewModels.LoginViewModel>" %>
<div class="login">
	<div class="error"><%= Model.Message %></div>  
	<% using(Html.BeginForm("Login", "Home")){ %>
		<fieldset>
			<legend><h3>Login</h3></legend>
			<div>
				<label for="user">User : </label><%= Html.TextBox("user") %>
			</div>
			<div>
				<label for="apitoken">APIToken : </label><%= Html.TextBox("apitoken") %>
			</div>
			<%= Html.Hidden("returnURL", Model.ReturnURL) %>
			<button type="submit">GO</button>
		</fieldset>
	<% } %>
</div>
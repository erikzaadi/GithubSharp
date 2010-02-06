<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" ContentType="text/javascript" %>
var UrlHelper = 
{
    LoginURL : '<%= Url.Action("Login", "Home") %>'
};

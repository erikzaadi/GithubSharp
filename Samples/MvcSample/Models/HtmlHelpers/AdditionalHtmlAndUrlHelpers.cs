using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace GithubSharp.Samples.MvcSample.Models.HtmlHelpers
{
    public static class AdditionalHtmlAndUrlHelpers
    {
        public static void If(this HtmlHelper helper, bool condition, Action trueAction)
        {
            If(helper, condition, trueAction, null);
        }

        public static void If(this HtmlHelper helper, bool condition, Action trueAction, Action elseAction)
        {
            if (condition)
                trueAction();
            else if (elseAction != null)
                elseAction();
        }

        public static string If(this HtmlHelper helper, bool condition, Func<string> trueAction)
        {
            return If(condition, trueAction, null);
        }

        public static string If(this HtmlHelper helper, bool condition, Func<string> trueAction, Func<string> elseAction)
        {
            return If(condition, trueAction, elseAction);
        }

        private static string If(bool condition, Func<string> trueAction, Func<string> elseAction)
        {
            if (condition)
                return trueAction();
            if (elseAction == null)
                return string.Empty;
            return elseAction();
        }

        public static string RenderScripts(this HtmlHelper helper, ViewModels.IBaseViewModel BaseModel)
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);  
  
            var sb = new StringBuilder();
            if (DebugMode)
            {
                BaseModel.DebugScripts.ForEach(p => sb.AppendFormat("\n<script type=\"text/javascript\" src=\"{0}\"></script>", urlHelper.Content(p.CDN ?? p.Source)));
            }
            else
            {
                BaseModel.ReleaseScripts.ForEach(p => sb.AppendFormat("\n<script type=\"text/javascript\" src=\"{0}\"></script>", urlHelper.Content(p.CDN ?? p.Source)));
            }
            if (BaseModel.DocumentReadies.Count > 0)
            {
                sb.AppendLine("<script type=\"text/javascript\">");
                sb.AppendLine("$(document).ready(function(){");
                BaseModel.DocumentReadies.ForEach(p => sb.AppendFormat("\n{0}", p));
                sb.AppendLine("});</script>");
            }
            return sb.ToString();
        }

        public static string RenderStyleSheets(this HtmlHelper helper, ViewModels.IBaseViewModel BaseModel)
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);

            var sb = new StringBuilder();
            if (DebugMode)
            {
                BaseModel.DebugStyleSheets.ForEach(p => sb.AppendFormat("\n<link rel=\"stylesheet\" href=\"{0}\"/>", urlHelper.Content(p.CDN ?? p.Source)));
            }
            else
            {
                BaseModel.ReleaseStyleSheets.ForEach(p => sb.AppendFormat("\n<link rel=\"stylesheet\" href=\"{0}\"/>", urlHelper.Content(p.CDN ?? p.Source)));
            }
            return sb.ToString();
        }

        private static bool DebugMode
        {
            get
            {
                return HttpContext.Current == null || HttpContext.Current.IsDebuggingEnabled;
            }
        }
    }
}

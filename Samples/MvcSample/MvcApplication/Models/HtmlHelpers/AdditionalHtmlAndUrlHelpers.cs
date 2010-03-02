using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace GithubSharp.Samples.MvcSample.MvcApplication.Models.HtmlHelpers
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

        public static MvcHtmlString If(this HtmlHelper helper, bool condition, Func<MvcHtmlString> trueAction)
        {
            return If(condition, trueAction, null);
        }

        public static MvcHtmlString If(this HtmlHelper helper, bool condition, Func<MvcHtmlString> trueAction, Func<MvcHtmlString> elseAction)
        {
            return If(condition, trueAction, elseAction);
        }

        private static MvcHtmlString If(bool condition, Func<MvcHtmlString> trueAction, Func<MvcHtmlString> elseAction)
        {
            if (condition)
                return trueAction();
            if (elseAction == null)
                return MvcHtmlString.Empty;
            return elseAction();
        }

        public static MvcHtmlString RenderScripts(this HtmlHelper helper, ViewModels.IBaseViewModel BaseModel)
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
            return MvcHtmlString.Create(sb.ToString());
        }

        public static MvcHtmlString RenderStyleSheets(this HtmlHelper helper, ViewModels.IBaseViewModel BaseModel)
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
            return MvcHtmlString.Create(sb.ToString());
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

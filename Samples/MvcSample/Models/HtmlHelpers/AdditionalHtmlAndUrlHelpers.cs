using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GithubSharp.Samples.MvcSample.Models.HtmlHelpers
{
    public static class AdditionalHtmlAndUrlHelpers
    {
        public delegate string HtmlHelperAction(HtmlHelper helper);
        public delegate string UrlHelperAction(UrlHelper helper);

        public static string If(this HtmlHelper helper, bool condition, string trueString)
        {
            return If(condition, trueString, "");
        }
        public static string If(this HtmlHelper helper, bool condition, HtmlHelperAction action)
        {
            return If(helper, condition, action, "");
        }

        public static string If(this HtmlHelper helper, bool condition, HtmlHelperAction action, HtmlHelperAction elseAction)
        {
            return If(helper, condition, action, elseAction(helper));
        }

        public static string If(this HtmlHelper helper, bool condition, string trueString, HtmlHelperAction elseAction)
        {
            return If(condition, trueString, elseAction(helper));

        }
        public static string If(this HtmlHelper helper, bool condition, HtmlHelperAction action, string elseString)
        {
            return If(condition, action(helper), elseString);
        }

        public static string If(bool condition, string trueString, string elseString)
        {
            return condition ? trueString : elseString;
        }

        public static string If(this UrlHelper helper, bool condition, UrlHelperAction action)
        {
            return If(helper, condition, action, null);
        }
        public static string If(this UrlHelper helper, bool condition, UrlHelperAction action, UrlHelperAction elseAction)
        {
            if (condition)
                return action(helper);
            if (elseAction == null)
                return string.Empty;
            return elseAction(helper);
        }
    }
}

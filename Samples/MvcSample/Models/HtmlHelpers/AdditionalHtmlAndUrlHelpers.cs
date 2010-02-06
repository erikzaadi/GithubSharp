using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}

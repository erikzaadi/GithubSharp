using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Web.WebPages;

namespace GithubSharp.Samples.MvcSample.MvcApplication.Models.HtmlHelpers
{
	public static class AdditionalHtmlAndUrlHelpers
	{

		public static MvcHtmlString If (this HtmlHelper helper, bool condition, Func<string> trueAction)
		{
			return If (condition, () => MvcHtmlString.Create (trueAction ()), null);
		}

		public static MvcHtmlString If (this HtmlHelper helper, bool condition, Func<MvcHtmlString> trueAction)
		{
			return If (condition, trueAction, null);
		}

		public static MvcHtmlString If (this HtmlHelper helper, bool condition, Func<MvcHtmlString> trueAction, Func<string> elseAction)
		{
			return If (condition, trueAction, () => elseAction == null ? MvcHtmlString.Empty : MvcHtmlString.Create (elseAction ()));
		}
		public static MvcHtmlString If (this HtmlHelper helper, bool condition, Func<MvcHtmlString> trueAction, Func<MvcHtmlString> elseAction)
		{
			return If (condition, trueAction, elseAction);
		}
		public static MvcHtmlString If (this HtmlHelper helper, bool condition, Func<string> trueAction, Func<MvcHtmlString> elseAction)
		{
			return If (condition, () => MvcHtmlString.Create (trueAction ()), elseAction);
		}
		public static MvcHtmlString If (this HtmlHelper helper, bool condition, Func<string> trueAction, Func<string> elseAction)
		{
			return If (condition, () => MvcHtmlString.Create (trueAction ()), () => elseAction == null ? MvcHtmlString.Empty : MvcHtmlString.Create (elseAction ()));
		}


		private static MvcHtmlString If (bool condition, Func<MvcHtmlString> trueAction, Func<MvcHtmlString> elseAction)
		{
			if (condition)
				return trueAction ();
			if (elseAction == null)
				return MvcHtmlString.Empty;
			return elseAction ();
		}

		private static readonly object _o = new object ();
		public static HelperResult RenderSection (this WebPageBase page, string sectionName, Func<object, HelperResult> defaultContent)
		{
			if (page.IsSectionDefined (sectionName)) {
				return page.RenderSection (sectionName);
			} else {
				return defaultContent (_o);
			}
		}
	}
}

using System;

namespace GithubSharp.Core.Base
{
    public enum GithubSharpHttpVerbs
    {
        Get,
        Post,
        Patch,
        Delete,
        Put,
        Head,
        Options
    }

    public enum GithubSharpMimeTypes
    {
        Raw,
        Text,
        Html,
        Full,
        Json
    }

    public static class EnumHelper
    {
        public static string ToString(this GithubSharpHttpVerbs verb)
        {
            switch (verb)
            {
                case GithubSharpHttpVerbs.Get: return "GET";
                case GithubSharpHttpVerbs.Post: return "POST";
                case GithubSharpHttpVerbs.Patch: return "PATCH";
                case GithubSharpHttpVerbs.Delete: return "DELETE";
                case GithubSharpHttpVerbs.Put: return "PUT";
                case GithubSharpHttpVerbs.Head: return "HEAD";
                default: return "OPTIONS";
            }
        }

        public static string ToString(this GithubSharpMimeTypes mime)
        {
            const string mimeBase = "application/vnd.github.{0}+json";
            switch (mime)
            {
                case GithubSharpMimeTypes.Raw: return string.Format(mimeBase, "raw");
                case GithubSharpMimeTypes.Text: return string.Format(mimeBase, "text");
                case GithubSharpMimeTypes.Html: return string.Format(mimeBase, "html");
                case GithubSharpMimeTypes.Full: return string.Format(mimeBase, "full");
                default: return "application/vnd.github.json";
            }
        }
    }
}


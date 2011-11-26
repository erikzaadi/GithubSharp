using System;

namespace GithubSharp.Core.Models
{
    [Serializable]
    public class Comment
    {
        public string id { get; set; }
        public string url { get; set; }
        public string body { get; set; }
        public string body_text { get; set; }
        public string body_html { get; set; }
        public BasicUser user { get; set; }
        public DateTime created_at { get; set; }
    }

    [Serializable]
    public class CommentForCreationOrEdit
    {
        public string body { get; set; }
    }
}


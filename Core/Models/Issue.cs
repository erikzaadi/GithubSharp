using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GithubSharp.Core.Models
{
    public class Issue
    {
        public int number { get; set; }
        public int votes { get; set; }
        public DateTime created_at { get; set; }
        public string body { get; set; }
        public string title { get; set; }
        public DateTime closed_at { get; set; }
        public string user { get; set; }
        public string[] labels { get; set; }
        public IssueState state { get; set; }
    }

    public enum IssueState
    {
        open,
        closed
    }

    public class Comment
    {
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string body { get; set; }
        public int id { get; set; }
        public string user { get; set; }
    }
}

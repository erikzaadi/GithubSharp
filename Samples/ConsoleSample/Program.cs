using System;
using GithubSharp.Core.API;
using GithubSharp.Plugins.LogProviders.SimpleLogProvider;
using GithubSharp.Core.Services;

namespace ConsoleSample
{
    class Program
    {
        static void Main()
        {
            var user = new User(new BasicCacher.BasicCacher(), new SimpleLogProvider());
            var u = user.Get("rumpl");
            Console.WriteLine(u.Blog);
            u = user.Get("rumpl");
            Console.WriteLine(u.Blog);

            var issuesAPI = new Issues(new BasicCacher.BasicCacher(), new SimpleLogProvider());

            var closedIssues = issuesAPI.List("GithubSharp", "erikzaadi", GithubSharp.Core.Models.IssueState.Closed);
            var openIssues = issuesAPI.List("GithubSharp", "erikzaadi", GithubSharp.Core.Models.IssueState.Open);

            //TestPullRequest();

            Console.ReadKey();
        }

        private static void TestPullRequest()
        {
            var cocytusUser = new GithubSharp.Core.Models.GithubUser { Name = "cocytus", APIToken = "XXXXXXXXXXXXXXXXXXXXXXXXXXXX" };
            PullRequest pullApi = new PullRequest(new BasicCacher.BasicCacher(), new ConsoleLogger());
            var pulls = pullApi.List("cocytus", "gitextensions");
            foreach (var pull in pulls)
            {
                Console.WriteLine("Pull from {1}: {0}\r\nVotes: {2}\r\nBody: {3}\r\nGravatar ID: {4}", pull.Title, pull.User.Login, pull.Votes, pull.Body, pull.User.GravatarId);
                Console.WriteLine("Created: {0} Updated: {1} Issue updated: {2}", pull.Created, pull.Updated, pull.IssueUpdated);
                Console.WriteLine("Base: Owner: {0} Name: {1} Ref: {2} Sha: {3}", pull.Base.Repository.Owner, pull.Base.Repository.Name, pull.Base.Ref, pull.Base.Sha);
                Console.WriteLine("Head: Owner: {0} Name: {1} Ref: {2} Sha: {3}", pull.Head.Repository.Owner, pull.Head.Repository.Name, pull.Head.Ref, pull.Head.Sha);

                Console.WriteLine("Diff URL: {0}\r\nPatch: {1}", pull.DiffUrl, pull.PatchUrl);
                Console.WriteLine("Labels: {0}", string.Join(",", pull.Labels));
                Console.WriteLine("Position: {0} Number: {1}", pull.Position, pull.Number);
            }

            var pull2 = pullApi.GetById("cocytus", "gitextensions", "1");
            Console.WriteLine("Pull from {1}: {0}\r\nVotes: {2}\r\nBody: {3}\r\nGravatar ID: {4}", pull2.Title, pull2.User.Login, pull2.Votes, pull2.Body, pull2.User.GravatarId);
            foreach (var d in pull2.Discussion)
            {
                Console.WriteLine("Discussion: From {0} At: {1} Type: {2}", d.User.Login, d.Created, d.Type);
                if (d.Type.ToLowerInvariant() == "commit")
                {
                    Console.WriteLine("SHA: {0} Subject: {1}", d.Sha, d.Subject);
                }
                else if (d.Type.ToLowerInvariant() == "issuecomment")
                {
                    Console.WriteLine("Body: {0}", d.Body);
                }
                else
                    Console.WriteLine("WHAT? " + d.Type);
            }
        }
    }

    class ConsoleLogger : ILogProvider
    {
        public bool DebugMode { get { return true; } set{} }

        public void LogMessage(string Message, params object[] Arguments)
        {
            Console.WriteLine(Message, Arguments);
        }

        public bool HandleAndReturnIfToThrowError(Exception error)
        {
            LogMessage("Exception: " + error.Message);
            return false;
        }
    }
}

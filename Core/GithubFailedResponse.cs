namespace GithubSharp.Core
{
    public class GithubFailedResponse : GithubResponse
    {
        public GithubFailedResponse(string uri)
        {
            FailedUri = uri;
        }

        public string FailedUri
        {
            get;
            set;
        }
    }
}


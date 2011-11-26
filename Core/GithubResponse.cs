namespace GithubSharp.Core
{
    public interface IGithubResponse
    {
        int RateLimitLimit { get; set; }
        int RateLimitRemaining { get; set; }
        string Response { get; set; }
        string LinkNext { get; set; }
        string LinkPrevious { get; set; }
        string LinkFirst { get; set; }
        string LinkLast { get; set; }
        int? StatusCode { get; set; }
        string StatusText { get; set; }
    }

    public interface IGithubResponseWithReturnType<TResultType> : IGithubResponse
        where TResultType : class
    {
        TResultType Result { get; set; }
    }

    public class GithubResponse : IGithubResponse
    {
        public int RateLimitLimit { get; set; }
        public int RateLimitRemaining { get; set; }
        public string Response { get; set; }
        public string LinkNext { get; set; }
        public string LinkPrevious { get; set; }
        public string LinkFirst { get; set; }
        public string LinkLast { get; set; }
        public int? StatusCode { get; set; }
        public string StatusText { get; set; }
    }

    public class GithubResponseWithReturnType<TResultType> : GithubResponse, IGithubResponseWithReturnType<TResultType>
        where TResultType : class
    {
        public TResultType Result
        {
            get;
            set;
        }
    }
}


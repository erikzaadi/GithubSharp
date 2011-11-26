namespace GithubSharp.Core.Services
{
    public interface IAuthProvider
    {
        IAuthResponse Login();
        IAuthResponse Logout();
        IAuthPreRequestResponse PreRequestAuth(
            IGithubRequest githubRequest,
            System.Net.HttpWebRequest webRequest);
        string PrepareUri(string uri);
        string GetToken();
        void RestoreFromToken(string token);
        bool IsAuthenticated { get; set; }
        string Username { get; set; }
    }

    public interface IAuthResponse
    {
        bool Success { get; set; }
        string Message { get; set; }
    }

    public class AuthResponse : IAuthResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public interface IAuthPreRequestResponse : IAuthResponse
    {
        System.Net.HttpWebRequest WebRequest
        {
            get;
            set;
        }
    }

    public class AuthPreRequestResponse : AuthResponse, IAuthPreRequestResponse
    {
        public System.Net.HttpWebRequest WebRequest
        {
            get;
            set;
        }
    }
}


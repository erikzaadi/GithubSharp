using GithubSharp.Core.Services;
using GithubSharp.Core.Base;

namespace GithubSharp.Core
{
    public class GithubRequestWithInputAndReturnType<TInputType, TReturnType> : GithubRequestWithReturnType<TReturnType>
        where TReturnType : class
    {
        public GithubRequestWithInputAndReturnType(
            ILogProvider logProvider,
            ICacheProvider cacheProvider,
            IAuthProvider authProvider,
            string path,
            TInputType input)
            : base(logProvider,
                cacheProvider,
                authProvider,
                path)
        {
            ModelToSend = input;
        }
        public GithubRequestWithInputAndReturnType(
            ILogProvider logProvider,
            ICacheProvider cacheProvider,
            IAuthProvider authProvider,
            string path,
            GithubSharpHttpVerbs method,
            TInputType input)
            : base(logProvider,
                cacheProvider,
                authProvider,
                path,
                method)
        {
            ModelToSend = input;
        }

        public TInputType ModelToSend { get; set; }


        public override System.Net.HttpWebRequest PrepareWebRequest(System.Net.HttpWebRequest webRequest)
        {
            webRequest = base.PrepareWebRequest(webRequest);
            webRequest.ContentType = "application/json"; //Get from MimeType?
            webRequest.MediaType = "UTF-8";
            var bytes = ModelToSend.ToJsonBytes();

            webRequest.ContentLength = bytes.Length;
            var stream = webRequest.GetRequestStream();
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();

            return webRequest;
        }
    }
}

